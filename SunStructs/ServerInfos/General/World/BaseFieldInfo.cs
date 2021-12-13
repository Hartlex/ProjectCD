using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.World
{
    public class BaseFieldInfo
    {
        public readonly uint MapCode;
        public readonly uint MapKind;
        public readonly string Name;
        public readonly uint NameCode;
        public readonly uint FNCode;
        public readonly uint DCode;
        public readonly uint ANCode;
        public readonly uint Guildent;
        public readonly uint GuildItem;
        public readonly uint TimeLim;
        public readonly uint MKind;
        public readonly byte MapType;
        public readonly byte MinUser;
        public readonly byte MaxUser;
        public readonly ushort MinLevel;
        public readonly ushort MaxLevel;
        public readonly ushort FreePassLvl;
        public readonly string StartId;
        public readonly string StartId2;
        public readonly byte EntCount;
        public readonly byte Class;
        public readonly byte FieldCount;
        public readonly ushort CompleteQCode;
        public readonly ushort CompleteMCode;
        public readonly byte ContinentCode;
        public readonly uint[] MissionMaps;
        public readonly uint[] PVPMaps;
        public readonly uint[] CMaps;

        public BaseFieldInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            MapCode = sb.ReadUint();
            MapKind = sb.ReadUint();
            Name = sb.ReadString();
            NameCode = sb.ReadUint();
            FNCode = sb.ReadUint();
            DCode = sb.ReadUint();
            ANCode = sb.ReadUint();
            Guildent = sb.ReadUint();
            GuildItem = sb.ReadUint();
            TimeLim = sb.ReadUint();
            MKind = sb.ReadUint();
            MapType = sb.ReadByte();
            MinUser = sb.ReadByte();
            MaxUser = sb.ReadByte();
            MinLevel = sb.ReadUshort();
            MaxLevel = sb.ReadUshort();
            FreePassLvl = sb.ReadUshort();
            StartId = sb.ReadString();
            StartId2 = sb.ReadString();
            EntCount = sb.ReadByte();
            Class = sb.ReadByte();
            FieldCount = sb.ReadByte();
            CompleteQCode = sb.ReadUshort();
            CompleteMCode = sb.ReadUshort();
            ContinentCode = sb.ReadByte();
            MissionMaps = new uint[6];
            for (int i = 0; i < 6; i++)
            {
                MissionMaps[i] = sb.ReadUint();
            }            
            PVPMaps = new uint[6];
            for (int i = 0; i < 6; i++)
            {
                PVPMaps[i] = sb.ReadUint();
            }
            CMaps = new uint[6];
            for (int i = 0; i < 6; i++)
            {
                CMaps[i] = sb.ReadUint();
            }
        }
    }
}
