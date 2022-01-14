using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Battle.Client
{
    public class AskPlayerAttackInfo : ClientPacketInfo
    {
        public readonly byte Unk1;
        public readonly byte Unk2;
        public readonly byte Unk3;
        public readonly byte Unk4;
        public readonly uint ClientSerial;

        public readonly byte StyleRef;
        public readonly uint TargetKey;
        public readonly SunVector CurrentPos;
        public readonly SunVector DestinationPos;

        public AskPlayerAttackInfo(ref ByteBuffer buffer) : base(ref buffer)
        {
            Unk1 = buffer.ReadByte();
            Unk2 = buffer.ReadByte();
            Unk3 = buffer.ReadByte();
            Unk4 = buffer.ReadByte();
            ClientSerial = buffer.ReadUInt32();

            StyleRef = (byte) (buffer.ReadByte()/4);
            TargetKey = buffer.ReadUInt32();
            CurrentPos = new SunVector(ref buffer);
            DestinationPos = new SunVector(ref buffer);

        }
    }
}
