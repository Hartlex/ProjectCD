using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.World
{
    public class BasePortalInfo
    {
        public readonly ushort PortalId;
        public readonly byte MapType;
        public readonly byte MoveType;
        public readonly ushort FromWorld;
        public readonly ushort FromField;
        public readonly string FromArea;
        public readonly ushort ToWorld;
        public readonly ushort ToField;
        public readonly string ToArea;
        public readonly byte MinLevel;
        public readonly byte MaxLevel;
        public readonly ushort MissionCode;
        public readonly ushort QuestCode;
        public readonly ushort ItemCode;
        public readonly byte ItemNum;
        public readonly uint WasteItem;
        public readonly uint HeimCost;

        public BasePortalInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            sb.Skip();
            PortalId = sb.ReadUshort();
            MapType= sb.ReadByte();
            MoveType= sb.ReadByte();
            FromWorld= sb.ReadUshort();
            FromField= sb.ReadUshort();
            FromArea = sb.ReadString();
            ToWorld= sb.ReadUshort();
            ToField= sb.ReadUshort();
            ToArea = sb.ReadString();
            MinLevel = sb.ReadByte();
            MaxLevel = sb.ReadByte();
            MissionCode= sb.ReadUshort();
            QuestCode= sb.ReadUshort();
            ItemCode= sb.ReadUshort();
            ItemNum= sb.ReadByte();
            WasteItem = sb.ReadUint();
            HeimCost = sb.ReadUint();
        }

    }
}
