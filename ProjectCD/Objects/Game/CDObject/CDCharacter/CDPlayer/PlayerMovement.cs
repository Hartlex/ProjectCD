using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Sync.Client;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.CharInfo;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private MoveStateControl _moveStateControl;
        private uint _fieldCode;
        private float _angle;
        private ushort _tileID;
        private byte _moveState;

        public void PlayerMovementInit(ref SqlDataReader reader)
        {
            _moveStateControl = new MoveStateControl(this, CharMoveState.CMS_RUN);
            var posX = reader.GetFloat(30);
            var posY = reader.GetFloat(31);
            var posZ = reader.GetFloat(32);
            _fieldCode = unchecked((uint)reader.GetInt32(29));
            _angle = Convert.ToUInt16(reader.GetFloat(33));
            SetPos(new SunVector(posX, posY, posZ));
        }

        public void OnKeyboardMove(KeyBoardMoveInfo info)
        {
            SetPos(info.CurrentPosition);
            _angle = info.Angle;
            _tileID = info.TileIndex;
            _moveState = info.MoveState;
               
            GetCurrentField()?.QueueWarPacketInfo(new KeyboardMoveBrdInfo((ushort)GetKey(), info));
        }

        public void OnMouseMove(MouseMoveInfo info)
        {
            SetPos(info.CurrentPosition);

            GetCurrentField()?.QueueWarPacketInfo(new MoveBrd(
                GetKey(),
                _moveState,
                1,
                info.CurrentPosition,
                info.DestinationPosition
                ));

        }

        public void OnMoveStop(MoveStopInfo info)
        {
            SetPos(info.CurrentPosition);

            GetCurrentField()?.QueueWarPacketInfo(new MoveStopBrd(GetKey(),info.CurrentPosition));

            //for (byte i = 138; i < 255; i++)
            //{

            //    var buffer = new ByteBuffer();
            //    buffer.WriteUInt16(1);
            //    buffer.WriteByte(i);
            //    buffer.WriteUInt32(GetKey());
            //    var pos = info.CurrentPosition + new SunVector(1, 0, 0);
            //    pos.GetBytes(ref buffer);
            //    var testPacket = new TestPacket((byte)GamePacketType.SYNC, 167, new TestPacketInfo(buffer.GetData()));

            //    GetCurrentField()?.SendToAll(testPacket);
            //    Logger.Instance.Log(i);
            //    Thread.Sleep(2000);

            //}
        }

        public void OnJump(JumpInfo info)
        {
            SetPos(info.LandPosition);
            GetCurrentField()?.QueueWarPacketInfo(new PlayerJumpBrd(GetKey(), info));

            GetCurrentField()?.SpawnMonsterEx(2,info.LandPosition);
            //var renderInfo = new MonsterRenderInfo(100, 2, GetPos(), 100, 100, 100, 100, 0);
            //var packet = new BrdMonsterEnter(new MonsterRenderInfos(renderInfo));
            //GetCurrentField()?.SendToAll(packet);
        }

        public void OnAfterJump(AfterJumpInfo info)
        {
            SetPos(info.CurrentPosition);
        }

        public uint GetCurrentMapCode()
        {
            return _fieldCode;
        }

        public void SetNewFieldAndPos(uint fieldCode, SunVector pos)
        {
            _fieldCode = fieldCode;
            SetPos(pos);
        }

        public override void OnEnterField(Field field, SunVector pos, ushort angle = 0)
        {
            base.OnEnterField(field, pos, angle);
            var playerRenderPacket = new AllPlayerRenderInfoCmd(new (new[] {GetRenderInfo()}));
            var equipPacket = new AllPlayersEquipInfoCmd(new (new[] {GetEquipRenderInfo()}));

            GetCurrentField()?.Broadcast(playerRenderPacket,equipPacket);
        }

        public override void OnLeaveField()
        {
            var outInfo = new PlayerLeaveFieldInfo(GetKey());
            var packet = new PlayerLeaveFieldBrd(outInfo);
            GetCurrentField()?.Broadcast(packet);

            base.OnLeaveField();
        }

        private void MapCoordinates()
        {
            var pos = GetPos();
            File.AppendAllLines($".//mapdata//{_fieldCode}.txt",new []{$"{_tileID};{pos.GetX()};{pos.GetY()};{pos.GetZ()}" });
        }

        public void OnTargetMove(TargetMoveInfo info)
        {
            SetPos(info.CurrentPosition);

            GetCurrentField()?.QueueWarPacketInfo(new TargetMoveBrd((ushort)GetKey(),info));
        }
    }
}
