using System.Text;
using CDShared.Logging;

namespace CDShared.ByteLevel
{
    public static class ByteUtils
    {
        public static string GetPrintableBits(byte b)
        {
            var b7 = BitManip.Get7(b);
            var b6 = BitManip.Get6(b);
            var b5 = BitManip.Get5(b);
            var b4 = BitManip.Get4(b);
            var b3 = BitManip.Get3(b);
            var b2 = BitManip.Get2(b);
            var b1 = BitManip.Get1(b);
            var b0 = BitManip.Get0(b);
            return "" + b7 + b6 + b5 + b4 + b3 + b2 + b1 + b0;
        }

        public static void Print(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(b + "|");
            }
            Logger.Instance.Log(sb.ToString());
        }
        public static string GetPrintableBits(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                sb.Append(GetPrintableBits(b)+" ");
            }

            return sb.ToString();
        }

        public static void PrintTest(byte[] bytes)
        {
            var part1 = BitManip.Get0to3(bytes[2]);
            var part2 = bytes[3];
            var part3 = bytes[4];
            var part4 = bytes[5];
            var part5 = BitManip.Get4to7(bytes[6]);
            
            Logger.Instance.Log(part1);
            Logger.Instance.Log(part2);
            Logger.Instance.Log(part3);
            Logger.Instance.Log(part4);
            Logger.Instance.Log(part5);
        }
        public static void PrintPossibleUints(byte[] bytes)
        {
            int i = 0;
            while (i + 3 < bytes.Length)
            {
                var partBytes = new byte[4];
                Buffer.BlockCopy(bytes,i,partBytes,0,4);
                Logger.Instance.Log(BitConverter.ToUInt32(partBytes));
                i++;
            }
        }
        public static uint[] GetPossibleUints(byte[] bytes)
        {
            int i = 0;
            var result = new List<uint>();
            while (i + 3 < bytes.Length)
            {
                var partBytes = new byte[4];
                Buffer.BlockCopy(bytes,i,partBytes,0,4);
                result.Add(BitConverter.ToUInt32(partBytes));
                i++;
            }

            return result.ToArray();
        }

        public static uint[] GetPossibleUints(ulong input)
        {
            int i = 0;
            var result = new List<uint>();
            
            result.Add(BitManip.Get0to31(input));
            result.Add(BitManip.Get1to32(input));
            result.Add(BitManip.Get2to33(input));
            result.Add(BitManip.Get3to34(input));
            result.Add(BitManip.Get4to35(input));
            result.Add(BitManip.Get5to36(input));
            result.Add(BitManip.Get6to37(input));
            result.Add(BitManip.Get7to38(input));
            result.Add(BitManip.Get8to39(input));
            result.Add(BitManip.Get9to40(input));
            result.Add(BitManip.Get10to41(input));
            result.Add(BitManip.Get11to42(input));
            result.Add(BitManip.Get12to43(input));
            result.Add(BitManip.Get13to44(input));
            result.Add(BitManip.Get14to45(input));
            result.Add(BitManip.Get15to46(input));
            result.Add(BitManip.Get16to47(input));
            result.Add(BitManip.Get17to48(input));
            result.Add(BitManip.Get18to49(input));
            result.Add(BitManip.Get19to50(input));
            result.Add(BitManip.Get20to51(input));
            result.Add(BitManip.Get21to52(input));
            result.Add(BitManip.Get22to53(input));
            result.Add(BitManip.Get23to54(input));
            result.Add(BitManip.Get24to55(input));
            result.Add(BitManip.Get25to56(input));
            result.Add(BitManip.Get26to57(input));
            result.Add(BitManip.Get27to58(input));
            result.Add(BitManip.Get28to59(input));
            result.Add(BitManip.Get29to60(input));
            result.Add(BitManip.Get30to61(input));
            result.Add(BitManip.Get31to62(input));
            result.Add(BitManip.Get32to63(input));

            return result.ToArray();
        }

        public static ushort[] GetPossibleUshorts(ulong input)
        {
            var result = new List<ushort>();
            result.Add(BitManip.Get0to15(input));
            result.Add(BitManip.Get1to16(input));
            result.Add(BitManip.Get2to17(input));
            result.Add(BitManip.Get3to18(input));
            result.Add(BitManip.Get4to19(input));
            result.Add(BitManip.Get5to20(input));
            result.Add(BitManip.Get6to21(input));
            result.Add(BitManip.Get7to22(input));
            result.Add(BitManip.Get8to23(input));
            result.Add(BitManip.Get9to24(input));
            result.Add(BitManip.Get10to25(input));
            result.Add(BitManip.Get11to26(input));
            result.Add(BitManip.Get12to27(input));
            result.Add(BitManip.Get13to28(input));
            result.Add(BitManip.Get14to29(input));//this
            result.Add(BitManip.Get15to30(input));
            result.Add(BitManip.Get16to31(input));
            result.Add(BitManip.Get17to32(input));
            result.Add(BitManip.Get18to33(input));
            result.Add(BitManip.Get19to34(input));
            result.Add(BitManip.Get20to35(input));
            result.Add(BitManip.Get21to36(input));
            result.Add(BitManip.Get22to37(input));
            result.Add(BitManip.Get23to38(input));
            result.Add(BitManip.Get24to39(input));
            result.Add(BitManip.Get25to40(input));
            result.Add(BitManip.Get26to41(input));
            result.Add(BitManip.Get27to42(input));
            result.Add(BitManip.Get28to43(input));
            result.Add(BitManip.Get29to44(input));
            result.Add(BitManip.Get30to45(input));
            result.Add(BitManip.Get31to46(input));
            result.Add(BitManip.Get32to47(input));
            result.Add(BitManip.Get33to48(input));
            result.Add(BitManip.Get34to49(input));
            result.Add(BitManip.Get35to50(input));
            result.Add(BitManip.Get36to51(input));
            result.Add(BitManip.Get37to52(input));
            result.Add(BitManip.Get38to53(input));
            result.Add(BitManip.Get39to54(input));
            result.Add(BitManip.Get40to55(input));
            result.Add(BitManip.Get41to56(input));
            result.Add(BitManip.Get42to57(input));
            result.Add(BitManip.Get43to58(input));
            result.Add(BitManip.Get44to59(input));
            result.Add(BitManip.Get45to60(input));
            result.Add(BitManip.Get46to61(input));
            result.Add(BitManip.Get47to62(input));
            result.Add(BitManip.Get48to63(input));

            return result.ToArray();
        }

        public static ulong[] GetPossibleUlongs(uint input)
        {
            var result = new List<ulong>();
            ulong llong = 0; 
            result.Add(BitManip.Set0to31(llong,input));
            result.Add(BitManip.Set1to32(llong,input));
            result.Add(BitManip.Set2to33(llong,input));
            result.Add(BitManip.Set3to34(llong,input));
            result.Add(BitManip.Set4to35(llong,input));
            result.Add(BitManip.Set5to36(llong,input));
            result.Add(BitManip.Set6to37(llong,input));
            result.Add(BitManip.Set7to38(llong,input));
            result.Add(BitManip.Set8to39(llong,input));
            result.Add(BitManip.Set9to40(llong,input));
            result.Add(BitManip.Set10to41(llong,input));
            result.Add(BitManip.Set11to42(llong,input));
            result.Add(BitManip.Set12to43(llong,input));
            result.Add(BitManip.Set13to44(llong,input));
            result.Add(BitManip.Set14to45(llong,input));//outKey 2147483650
            result.Add(BitManip.Set15to46(llong,input));
            result.Add(BitManip.Set16to47(llong,input));
            result.Add(BitManip.Set17to48(llong,input));
            result.Add(BitManip.Set18to49(llong,input));
            result.Add(BitManip.Set19to50(llong,input));
            result.Add(BitManip.Set20to51(llong,input));
            result.Add(BitManip.Set21to52(llong,input));
            result.Add(BitManip.Set22to53(llong,input));
            result.Add(BitManip.Set23to54(llong,input));
            result.Add(BitManip.Set24to55(llong,input));
            result.Add(BitManip.Set25to56(llong,input));
            result.Add(BitManip.Set26to57(llong,input));
            result.Add(BitManip.Set27to58(llong,input));
            result.Add(BitManip.Set28to59(llong,input));
            result.Add(BitManip.Set29to60(llong,input));
            result.Add(BitManip.Set30to61(llong,input));
            result.Add(BitManip.Set31to62(llong,input));
            result.Add(BitManip.Set32to63(llong,input));

            return result.ToArray();
        }
        public static byte[] ToByteArray(int i, int size)
         {
            byte[] newbytes = new byte[size];
            var intbytes = BitConverter.GetBytes(i);
            var count = intbytes.Length > size ? size : intbytes.Length;
            Buffer.BlockCopy(intbytes, 0, newbytes, 0, count);
            return newbytes;
        }

        public static byte[] ToByteArray(string str, int size)
        {
            byte[] ret = new byte[size];
            Array.Copy(Encoding.ASCII.GetBytes(str), ret, str.Length);
            return ret;
        }

        public static byte[] ToByteArray(string str)
        {
            List<byte> newBytes = new List<byte>();
            for (int i = 1; i < str.Length; i++)
            {
                if (i % 2 == 0)
                {
                    var substr = str.Substring(i - 2, 2);
                    var j = Int32.Parse(substr, System.Globalization.NumberStyles.HexNumber);
                    newBytes.Add((byte)j);
                }
            }
            return newBytes.ToArray();

        }
        public static byte[] ToByteArray(float f, int size)
        {
            var newBytes = new byte[size];
            var fbytes = BitConverter.GetBytes(f);
            var count = fbytes.Length > size ? size : fbytes.Length;
            Buffer.BlockCopy(fbytes,0,newBytes,0,count);
            return newBytes;
        }
        public static int ToInt(byte[] bytes)
        {
            return Convert.ToInt32(bytes);
        }

        public static int ToInt(byte b)
        {
            return Convert.ToInt32(b);
        }

        public static byte[] SlicedBytes(byte[] bytes, int from, int to)
        {
            var newBytes = new byte[to - from];
            var j = 0;
            for (var i = from; i < to; i++, j++)
            {
                if (i >= bytes.Length) break;
                newBytes[j] = bytes[i];
            }

            return newBytes;

        }

        public static sbyte[] SlicedSbytes(sbyte[] bytes, int from, int to)
        {
            var newBytes = new sbyte[to - from];
            var j = 0;
            for (var i = from; i < to; i++, j++)
            {
                if (i >= bytes.Length) break;
                newBytes[j] = bytes[i];
            }

            return newBytes;
        } 
        public static byte[] CutTail(byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 0x00)
                {
                    byte[] newBytes = new byte[i];
                    Buffer.BlockCopy(bytes, 0, newBytes, 0, i);
                    return newBytes;
                }
            }
            return bytes;
        }
        public static sbyte[] CutTail(sbyte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] == 00)
                {
                    sbyte[] newBytes = new sbyte[i];
                    Buffer.BlockCopy(bytes, 0, newBytes, 0, i);
                    return newBytes;
                }
            }
            return bytes;
        }
        public static byte[] uintToByteArray(UInt32 v0, UInt32 v1)
        {
            var v0bytes = BitConverter.GetBytes(v0);
            var v1bytes = BitConverter.GetBytes(v1);
            var result = new byte[8];
            Buffer.BlockCopy(v0bytes, 0, result, 0, 4);
            Buffer.BlockCopy(v1bytes, 0, result, 4, 4);
            return result;
        }

        public static sbyte[] ToSbytes(byte[] bytes)
        {
            sbyte[] result = new sbyte[bytes.Length];
            Buffer.BlockCopy(bytes, 0, result, 0, bytes.Length);
            return result;
        }


        public static byte[] ToByteArray(sbyte[] sbytes)
        {
            byte[] result = new byte[sbytes.Length];
            Buffer.BlockCopy(sbytes, 0, result, 0, sbytes.Length);
            return result;
        }
        public static sbyte[] uintToSByteArray(UInt32 v0, UInt32 v1)
        {
            var v0bytes = BitConverter.GetBytes(v0);
            var v1bytes = BitConverter.GetBytes(v1);
            var result = new sbyte[8];
            Buffer.BlockCopy(v0bytes, 0, result, 0, 4);
            Buffer.BlockCopy(v1bytes, 0, result, 4, 4);
            return result;
        }

        public static byte[] PacketLength(List<byte> packet)
        {
            int len = packet.Count;
            return ToByteArray(len,2);
            
        }
    }



}
