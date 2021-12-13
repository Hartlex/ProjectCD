namespace CDShared.Parsing
{
    public class StringBuffer
    {
        private readonly string[] _infos;
        private int _pos;

        public StringBuffer(string[] infos)
        {
            _infos = infos;
            _pos = 0;
        }

        public void Skip()
        {
            _pos++;
        }

        public void Skip(int count)
        {
            _pos += count;
        }
        public byte ReadByte()
        {
            return byte.TryParse(Get(), out var b) ? b : (byte) 0;
        }

        public string ReadString()
        {
            return Get();
        }
        public ushort ReadUshort()
        {
            return ushort.Parse(Get());
        }

        public uint ReadUint()
        {
            return uint.TryParse(Get(),out uint result) ? result : (uint) 0;
        }
        public ulong ReadUlong()
        {
            //return Convert.ToUInt64(Get());
            var str = Get();
            if (str.Contains('.'))
            {
                var index = str.IndexOf('.');
                str = str.Substring(0, index);
            }
            return ulong.Parse(str);
        }

        public short ReadShort()
        {
            return short.Parse(Get());
        }
        public int ReadInt()
        {
            return int.Parse(Get());
        }

        public long ReadLong()
        {
            return long.Parse(Get());
        }

        public float ReadFloat()
        {
            return float.Parse(Get().Replace(".",","));
        }
        private string Get()
        {
            return _infos[_pos++];
        }
    }
}
