using CDShared.Parsing;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Items.SocketSystem
{
    public class SocketOption
    {
        public byte AttrOptionIndex;
        public ushort SocketItemCode;
        public string Name;
        public uint NCode;
        public AttrValueKind NumericType;
        public int[] Value= new int[(int) SocketLevel.SOCKETLV_MAX];

        public SocketOption(SocketItemOption socketItemOption)
        {
            AttrOptionIndex = socketItemOption.AttrOptionIndex;
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
        public byte AttrOptionIndex;
        public string Name;
        public uint NCode;
        public SocketLevel Level;
        public AttrValueKind NumericType;
        public byte Value;
        public SocketItemOption(string[] info)
        {
            var sb = new StringBuffer(info);

            SocketItemCode = sb.ReadUshort();
            AttrOptionIndex =  sb.ReadByte();
            Name = sb.ReadString();
            NCode = sb.ReadUint();
            Level = (SocketLevel)sb.ReadByte();
            NumericType = (AttrValueKind) sb.ReadByte();
            Value = sb.ReadByte();

        }
    }
}