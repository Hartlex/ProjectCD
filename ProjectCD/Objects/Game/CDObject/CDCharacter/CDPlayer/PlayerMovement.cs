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
    }
}
