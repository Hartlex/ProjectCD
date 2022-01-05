using System.Diagnostics;
using CDShared.ByteLevel;
using ProjectCD.Objects.Game.Slots.Items;

namespace ProjectCD.Objects.Game.Items
{
    internal class BitShifter
    {
        private static byte overShift;
        private static byte[] Shift2Right2(byte[] array, int timesAlreadyShifted)
        {
            var length = array.Length;
            int index = 0;
            while (length > 0)
            {
                var part1 = BitManip.Get0to1(array[index]);
                var part2 = BitManip.Get2to7(array[index]);

                array[index] = 0;

                array[index] = BitManip.Set6to7(array[index], overShift);
                
                array[index] = BitManip.Set0to5(array[index], part2);
                overShift = part1;
                index++;
                length--;
            }
            if (timesAlreadyShifted % 4 == 0)
            {
                var newArray = new byte[array.Length+1];
                overShift = BitManip.Set6to7(newArray[newArray.Length-1], overShift);
                Buffer.BlockCopy(array,0,newArray,0,array.Length);
                return newArray;

            }


            return array;
        }


        public static byte[] Shift(ItemSlotContainer container,bool withSize=true)
        {
            var result = new List<byte>();
            int shiftCount = 0;
            int itemCount = 0;
            for (int i = 0; i < container.GetMaxSlotNum(); i++)
            {
                var slot = container.GetSlot(i);
                if (slot.IsEmpty()) continue;
                byte[] orgBytes;
                Debug.Assert(slot != null, nameof(slot) + " != null");
                var hasOptions = slot.GetItem()!.HasOptions();
                if (!hasOptions)
                    orgBytes = slot.GetBytes(ItemByteType.MIN);
                else
                    orgBytes = slot.GetBytes(ItemByteType.TWENTY);
                if (shiftCount == 0)
                {
                    result.AddRange(orgBytes);
                    
                    itemCount++;
                    if (hasOptions)
                    {
                        shiftCount++;
                        result.Add(0);
                    }
                    continue;
                }
                
                byte[] shiftedBytes=orgBytes;
                for (int j = 0; j < shiftCount; j++)
                {
                    shiftedBytes = Shift2Right2(shiftedBytes,j);
                }

                int tmpShiftCount=shiftCount;
                if (shiftCount < 2) 
                {
                    tmpShiftCount = 2;
                }
                var mergeCount = ((tmpShiftCount-2)/4)+1;
                for (int k = 0; k < mergeCount; k++)
                {
                    result[^(mergeCount-k)] |= shiftedBytes[k];
                }
                var addBytes = new byte[shiftedBytes.Length - mergeCount];
                //var addBytes = shiftedBytes;
                Buffer.BlockCopy(shiftedBytes,mergeCount,addBytes,0,addBytes.Length);
                result.AddRange(addBytes);
                itemCount++;
                if (hasOptions)
                    shiftCount++;
            }
            result.Insert(0,(byte)itemCount);
            if(withSize)
                result.InsertRange(0,BitConverter.GetBytes((ushort)result.Count));
            return result.ToArray();
        }
    }
}
