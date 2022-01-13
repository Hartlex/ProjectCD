using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Sync.Client;
using SunStructs.ServerInfos.General;
using static SunStructs.Packets.GameServerPackets.Sync.WarProtocol;

namespace SunStructs.PacketInfos.Game.Sync.Server.WarPacket
{
    public class KeyboardMoveBrdInfo : WarPacketInfo
    {
        public ushort PlayerKey;
        public SunVector CurrentPosition;
        public ushort TileIndex;
        public ushort Angle;
        public byte MoveState;
        public KeyboardMoveBrdInfo(ushort playerKey, KeyBoardMoveInfo info) : base(KBD_MOVE_BRD)
        {
            PlayerKey = playerKey;
            CurrentPosition = info.CurrentPosition;
            TileIndex = info.TileIndex;
            Angle = info.Angle;
            MoveState = info.MoveState;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            base.GetBytes(ref buffer);
            buffer.WriteUInt16(PlayerKey);
            CurrentPosition.GetBytes(ref buffer);
            buffer.WriteUInt16(TileIndex);
            buffer.WriteUInt16(Angle);
            buffer.WriteByte(MoveState);
        }
    }
}
