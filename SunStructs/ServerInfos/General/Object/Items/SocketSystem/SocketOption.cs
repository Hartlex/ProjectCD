using CDShared.Parsing;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Items.SocketSystem
{
    public class SocketOption
    {
        public AttrType AttrIndex;
        public ushort SocketItemCode;
        public string Name;
        public uint NCode;
        public AttrValueKind NumericType;
        public int[] Value= new int[(int) SocketLevel.SOCKETLV_MAX];

        public SocketOption(SocketItemOption socketItemOption)
        {
            AttrIndex = socketItemOption.AttrIndex;
            SocketItemCode = socketItemOption.SocketItemCode;
            Name = socketItemOption.Name;
            NCode = socketItemOption.NCode;
            NumericType = socketItemOption.NumericType;
            Value[(int) socketItemOption.Level] = socketItemOption.Value;
        }
    }

    public class SocketItemOption
    {
        public ushort SocketItemCode;
        public AttrType AttrIndex;
        public string Name;
        public uint NCode;
        public SocketLevel Level;
        public AttrValueKind NumericType;
        public byte Value;
        public SocketItemOption(string[] info)
        {
            var sb = new StringBuffer(info);

            SocketItemCode = sb.ReadUshort();
            AttrIndex = (AttrType) sb.ReadInt();
            Name = sb.ReadString();
            NCode = sb.ReadUint();
            Level = (SocketLevel)sb.ReadByte();
            NumericType = (AttrValueKind) sb.ReadByte();
            Value = sb.ReadByte();

        }
    }
}