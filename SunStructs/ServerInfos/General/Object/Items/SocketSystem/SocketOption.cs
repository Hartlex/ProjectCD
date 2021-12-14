using CDShared.Parsing;
using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Items.SocketSystem
{
    public class SocketOption
    {
        public int AttrIndex;
        public ushort SocketItemCode;
        public string Name;
        public uint NCode;
        public NumericType NumericType;
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
        public int AttrIndex;
        public string Name;
        public uint NCode;
        public SocketLevel Level;
        public NumericType NumericType;
        public byte Value;
        public SocketItemOption(string[] info)
        {
            var sb = new StringBuffer(info);

            SocketItemCode = sb.ReadUshort();
            AttrIndex = sb.ReadInt();
            Name = sb.ReadString();
            NCode = sb.ReadUint();
            Level = (SocketLevel)sb.ReadByte();
            NumericType = (NumericType) sb.ReadByte();
            Value = sb.ReadByte();

        }
    }

    public class Socket
    {
        public readonly AttrType AttrType;
        public readonly NumericType NumericType;
        public readonly int Value;

        public Socket(AttrType attrType, NumericType numericType, int value)
        {
            AttrType = attrType;
            NumericType = numericType;
            Value = value;
        }
    }
}