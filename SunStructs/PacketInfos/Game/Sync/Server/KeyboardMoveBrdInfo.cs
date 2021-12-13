using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class KeyboardMoveBrdInfo : ServerPacketInfo
    {
        public readonly ushort PlayerID;
        public readonly SunVector CurrentPosition;
        public readonly ushort TileID;
        public readonly ushort Angle;
        public readonly byte MoveState;

        public KeyboardMoveBrdInfo(uint playerID, SunVector currentPosition, ushort tileID, ushort angle, byte moveState)
        {
            PlayerID = (ushort)playerID;
            CurrentPosition = currentPosition;
            TileID = tileID;
            Angle = angle;
            MoveState = moveState;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(PlayerID);
            CurrentPosition.GetBytes(ref buffer);
            buffer.WriteUInt16(TileID);
            buffer.WriteUInt16(Angle);
            buffer.WriteByte(MoveState);
        }
    }
}
