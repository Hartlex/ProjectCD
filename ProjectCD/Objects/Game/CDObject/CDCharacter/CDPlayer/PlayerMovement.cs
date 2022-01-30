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
        public void PlayerMovementInit(ref SqlDataReader reader)
        {
            var posX = reader.GetFloat(30);
            var posY = reader.GetFloat(31);
            var posZ = reader.GetFloat(32);

            MoveStateControl = new MoveStateControl(this, CharMoveState.CMS_RUN);

            var fieldCode = unchecked((uint)reader.GetInt32(29));
            var angle = Convert.ToUInt16(reader.GetFloat(33));

            MoveStateControl.SetFieldCode(fieldCode);
            MoveStateControl.SetAngle(angle);

            SetPos(new SunVector(posX, posY, posZ));
        }

        public void OnKeyboardMove(KeyBoardMoveInfo info)
        {
            SetPos(info.CurrentPosition);
            MoveStateControl.SetAngle(info.Angle);
            MoveStateControl.SetTileID(info.TileIndex);
            MoveStateControl.SetMoveState((CharMoveState)info.MoveState);
            GetCurrentField()?.QueueWarPacketInfo(new KeyboardMoveBrdInfo((ushort)GetKey(), info));
        }

        public void OnMouseMove(MouseMoveInfo info)
        {
            SetPos(info.CurrentPosition);

            GetCurrentField()?.QueueWarPacketInfo(new MoveBrd(
                GetKey(),
                (byte) MoveStateControl.GetMoveState(),
                1,
                info.CurrentPosition,
                info.DestinationPosition
                ));

        }

        public void OnMoveStop(MoveStopInfo info)
        {
            SetPos(info.CurrentPosition);

            GetCurrentField()?.QueueWarPacketInfo(new MoveStopBrd(GetKey(),info.CurrentPosition));
        }

        public void OnJump(JumpInfo info)
        {
            SetPos(info.LandPosition);
            GetCurrentField()?.QueueWarPacketInfo(new PlayerJumpBrd(GetKey(), info));

            GetCurrentField()?.SpawnMonsterEx(2,info.LandPosition);

            var b = new ByteBuffer();
            b.WriteUInt32(GetKey());
            b.WriteUInt16((ushort)Style.STYLE_DRAGON_PUNCH);
            b.WriteUInt16((ushort)Style.STYLE_ONEHANDSWORD_NORMAL);
            var testPacket = new TestPacket((byte)GamePacketType.STYLE, 95, new TestPacketInfo(b.GetData()));
            GetCurrentField()?.SendToAll(testPacket);

            //GetCurrentField()?.QueueWarPacketInfo(new StatusAddBrd(GetKey(),CharStateType.CHAR_STATE_STUN));
            //var addBuffer = new ByteBuffer();
            //addBuffer.WriteUInt16(100);
            //addBuffer.WriteByte((byte)WarProtocol.STATUS_ADD);
            //addBuffer.WriteUInt32(GetKey());
            //addBuffer.WriteUInt16((ushort)CharStateType.CHAR_STATE_STUN);
            //addBuffer.WriteByte((byte)WarProtocol.STATUS_ADD);
            //addBuffer.WriteUInt32(GetKey());
            //addBuffer.WriteUInt16((ushort)CharStateType.CHAR_STATE_FROZEN);
            //var addStatusPacket = new TestPacket((byte)GamePacketType.SYNC, (byte)SyncProtocol.WAR_MESSAGE,
            //    new TestPacketInfo(addBuffer.GetData()));
            //GetCurrentField()?.SendToAll(addStatusPacket);

            //for (int i = 160; i < 255; i++)
            //{
            //    var buffer = new ByteBuffer();
            //    buffer.WriteUInt16(1);
            //    buffer.WriteByte(i);
            //    buffer.WriteUInt32(GetKey());
            //    buffer.WriteUInt16((ushort)CharStateType.CHAR_STATE_STUN);

            //    Logger.Instance.Log(i);


            //    var testPacket = new TestPacket((byte)GamePacketType.SYNC, (byte)SyncProtocol.WAR_MESSAGE,
            //        new TestPacketInfo(buffer.GetData()));
            //    GetCurrentField()?.SendToAll(testPacket);
            //    Thread.Sleep(2000);
            //}
        }

        public void OnAfterJump(AfterJumpInfo info)
        {
            SetPos(info.CurrentPosition);
        }

        public uint GetCurrentMapCode()
        {
            return MoveStateControl.GetCurrentMapCode();
        }

        public void SetNewFieldAndPos(uint fieldCode, SunVector pos)
        {
            MoveStateControl.SetFieldCode(fieldCode);
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

        public void OnTargetMove(TargetMoveInfo info)
        {
            SetPos(info.CurrentPosition);

            GetCurrentField()?.QueueWarPacketInfo(new TargetMoveBrd((ushort)GetKey(),info));
        }

        public void OnSectorChange(uint sectorID, uint mapID)
        {
            if (mapID != MoveStateControl.GetCurrentMapCode())
            {
                Logger.Instance.Log($"Player[{GetKey()}] wrong sector change. ServerMap[{MoveStateControl.GetCurrentMapCode()}] ReceivedMap[{mapID}]");
            }

            MoveStateControl.SetSectorID(sectorID);
        }

        public override bool ExecuteThrust(bool forced, SunVector destPos, ref SunVector posAfterThrust, float moveDistance,
            bool downAfterThrust)
        {
            if (GetCurrentField() == null) return false;

            if (destPos.GetX() == 0 && destPos.GetY() == 0)
            {
                destPos.SetX(1);

            }

            posAfterThrust += destPos;
            SetPos(posAfterThrust);
            SetMoveState(CharMoveState.CMS_SWIPE);
            return true;
        }
    }
}
