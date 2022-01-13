using System.Security.Cryptography;
using CDShared.ByteLevel;
using CDShared.Logging;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Client
{
    public class KeyBoardMoveInfo
    {
        public readonly SunVector CurrentPosition;
        public readonly ushort Angle;
        public readonly ushort TileIndex;
        public readonly byte  MoveState;
        public KeyBoardMoveInfo(ref ByteBuffer buffer)
        {
            CurrentPosition = new SunVector(ref buffer);
            Angle =  buffer.ReadUInt16();
            TileIndex = buffer.ReadUInt16();
            MoveState = buffer.ReadByte();
        }

        public override string ToString()
        {
            return CurrentPosition + "Angle:" + Angle;
        }
    }
    public class MouseMoveInfo
    {
        public readonly ushort Unk1;
        public readonly SunVector CurrentPosition;
        public readonly SunVector DestinationPosition;
        public readonly byte TileCount;
        public readonly ushort[] Tiles;
        public MouseMoveInfo(ref ByteBuffer buffer)
        {
            Unk1 = buffer.ReadUInt16(); //MoveState
            CurrentPosition = new SunVector(ref buffer);
            DestinationPosition = new SunVector(ref buffer);
            TileCount = BitManip.Get29to36(buffer.ReadUInt64());
            Tiles = new ushort[TileCount];
            for (int i = 0; i < TileCount; i++)
            {
                Tiles[i] = buffer.ReadUInt16();
            }

        }
    }
    public class MoveStopInfo
    {
        public readonly SunVector CurrentPosition;
        public MoveStopInfo(ref ByteBuffer buffer)
        {
            CurrentPosition = new SunVector(ref buffer);
        }
    }
    public class JumpInfo
    {
        public readonly SunVector LandPosition;
        public readonly int Direction;
        public JumpInfo(ref ByteBuffer buffer)
        {
            LandPosition = new SunVector(ref buffer);
            Direction = buffer.ReadInt32();
        }
    }
    public class AfterJumpInfo
    {
        public readonly SunVector CurrentPosition;
        public AfterJumpInfo(ref ByteBuffer buffer)
        {
            CurrentPosition = new SunVector(ref buffer);
        }
    }

    public class TargetMoveInfo : ClientPacketInfo
    {
        public readonly uint TargetKey;
        public readonly SunVector CurrentPosition;
        public readonly SunVector DestinationPosition;
        public readonly byte TileCount;
        public readonly ushort[] Tiles;

        public TargetMoveInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            TargetKey = buffer.ReadUInt32();
            CurrentPosition = new (ref buffer);
            DestinationPosition = new (ref buffer);
            TileCount = buffer.ReadByte();
            Tiles = new ushort[TileCount];
            for (int i = 0; i < TileCount; i++)
            {
                Tiles[i] = buffer.ReadUInt16();
            }
        }
    }


}
