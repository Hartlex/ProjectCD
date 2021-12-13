using CDShared.ByteLevel;

namespace SunStructs.ServerInfos.General.Quest
{
    public class QuestProgress
    {
        private uint _unk1;
        private readonly byte[] _monsterKillNum= new byte[5];
        public QuestProgress(ref ByteBuffer buffer)
        {
            _unk1 = buffer.ReadUInt32();
            for (int i = 0; i < 5; i++)
            {
                _monsterKillNum[i] = buffer.ReadByte();
            }
        }

        public QuestProgress()
        {

        }
        public void GetBytes(ref ByteBuffer buffer)
        {

            //byte b1 = 0;
            //b1 = BitManip.Set0(b1, 1);
            //b1 = BitManip.Set1(b1, 1);
            //b1 = BitManip.Set2(b1, 1);
            //b1 = BitManip.Set3(b1, 1);
            //b1 = BitManip.Set4(b1, 1);
            //b1 = BitManip.Set5(b1, 1);
            //b1 = BitManip.Set6(b1, 1);
            //b1 = BitManip.Set7(b1, 1);

            //byte b2 = 0;
            //b2 = BitManip.Set0(b2, 1);
            //b2 = BitManip.Set1(b2, 1);
            //b2 = BitManip.Set2(b2, 1);
            //b2 = BitManip.Set3(b2, 1);
            //b2 = BitManip.Set4(b2, 1);
            //b2 = BitManip.Set5(b2, 1);
            //b2 = BitManip.Set6(b2, 1);
            //b2 = BitManip.Set7(b2, 1);

            //byte b3 = 0;
            //b3 = BitManip.Set0(b3, 1);
            //b3 = BitManip.Set1(b3, 1);
            //b3 = BitManip.Set2(b3, 1);
            //b3 = BitManip.Set3(b3, 1);
            //b3 = BitManip.Set4(b3, 1);
            //b3 = BitManip.Set5(b3, 1);
            //b3 = BitManip.Set6(b3, 1);
            //b3 = BitManip.Set7(b3, 1);

            //byte b4 = 0;
            //b4 = BitManip.Set0(b4, 1);
            //b4 = BitManip.Set1(b4, 1);
            //b4 = BitManip.Set2(b4, 1);
            //b4 = BitManip.Set3(b4, 1);
            //b4 = BitManip.Set4(b4, 1);
            //b4 = BitManip.Set5(b4, 1);
            //b4 = BitManip.Set6(b4, 1);
            //b4 = BitManip.Set7(b4, 1);
            //buffer.WriteBlock(new byte[]{b1,b2,b3,b4,b5,b6,b7,b8,b9});


            buffer.WriteUInt32(_unk1);
            buffer.WriteByte(_monsterKillNum[0]);
            buffer.WriteByte(_monsterKillNum[1]);
            buffer.WriteByte(_monsterKillNum[2]);
            buffer.WriteByte(_monsterKillNum[3]);
            buffer.WriteByte(_monsterKillNum[4]);

        }
        
        /// <summary>
        /// Returns the number of kill of certain mob from that quest (index 1-5)
        /// </summary>
        /// <param name="index">1 based index (1-5)</param>
        /// <returns></returns>
        public byte GetMonsterKillNum(byte index)
        {
            if (index > 5) return 0;
            return _monsterKillNum[index-1];
        }
        public void SetMonsterKillNum(byte index, byte num)
        {
            if (index > 5) return;
            _monsterKillNum[index - 1] = num;
        }
        public void IncreaseMonsterKillNum(byte index)
        {
            if (index > 5) return;
            _monsterKillNum[index]++;
        }

        public void IncreaseMonsterKillNum(ushort monsterCode)
        {

        }


    }
}