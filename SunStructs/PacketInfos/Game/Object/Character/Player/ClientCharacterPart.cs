using System.Data.SqlClient;
using CDShared.ByteLevel;
using static SunStructs.Definitions.Const;

namespace SunStructs.PacketInfos.Game.Object.Character.Player
{
    public class ClientCharacterPart : ServerPacketInfo
    {
        public readonly byte Slot;
        public readonly string CharName;
        public readonly byte HeightCode;
        public readonly byte FaceCode;
        public readonly byte HairCode;
        public readonly byte ClassCode;
        public readonly ushort Level;
        public readonly uint Region;
        public readonly ushort PosX;
        public readonly ushort PosY;
        public readonly ushort PosZ;
        public readonly byte ChangeOfClassStep;
        public readonly byte[] EquipInfo;
        public readonly byte WaitForDelete;
        public readonly byte[] Unk2;
        public readonly byte[] Unk3;
        public readonly byte[] Unk4;

        //public ClientCharacterPart(byte slot, byte size, string charName, byte heightCode, byte faceCode, byte hairCode, byte classCode, ushort level, uint region, float posX, float posY, float posZ, byte equipNumber, byte[] equipInfo, byte waitForDelete, byte[] unk2, byte[] unk3, byte[] unk4)
        //{
        //    Slot = slot;
        //    Size = size;
        //    CharName = ByteUtils.ToByteArray(charName, 16);
        //    HeightCode = heightCode;
        //    FaceCode = faceCode;
        //    HairCode = hairCode;
        //    ClassCode = classCode;
        //    Level = BitConverter.GetBytes(level);
        //    Region = BitConverter.GetBytes(region);
        //    PosX = BitConverter.GetBytes((short) posX);
        //    PosY = BitConverter.GetBytes((short) posY);
        //    PosZ = BitConverter.GetBytes((short) posZ);
        //    EquipNumber = equipNumber;
        //    EquipInfo = equipInfo;
        //    WaitForDelete = waitForDelete;
        //    Unk2 = unk2;
        //    Unk3 = unk3;
        //    Unk4 = unk4;
        //}

        public ClientCharacterPart(ref SqlDataReader reader)
        {
            Slot = reader.GetByte(2);
            CharName = reader.GetString(4);
            HeightCode = reader.GetByte(5);
            FaceCode = reader.GetByte(6);
            HairCode = reader.GetByte(7);
            ClassCode = reader.GetByte(3);
            Level =(ushort) reader.GetInt16(8);
            Region = (uint) reader.GetInt32(29);
            PosX = (ushort)reader.GetFloat(30);
            PosY = (ushort)reader.GetFloat(31);
            PosZ = (ushort) reader.GetFloat(32);
            ChangeOfClassStep = 0;
            EquipInfo =(byte[]) reader[40];
            WaitForDelete = 0; //Waiting for Delete
            Unk2 = new byte[39];

        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Slot);
            buffer.WriteString(CharName,MAX_CHAR_NAME_LENGTH,true);
            buffer.WriteByte(HeightCode);
            buffer.WriteByte(FaceCode);
            buffer.WriteByte(HairCode);
            buffer.WriteByte(ClassCode);
            buffer.WriteUInt16(Level);
            buffer.WriteUInt32(Region);
            buffer.WriteUInt16(PosX);
            buffer.WriteUInt16(PosY);
            buffer.WriteUInt16(PosZ);
            buffer.WriteByte(ChangeOfClassStep);
            buffer.WriteBlock(EquipInfo);
            buffer.WriteByte(WaitForDelete);
            if (WaitForDelete != 0)
            {
                buffer.WriteString("2021-12-10 15:00",SHORT_DATE_LENGTH,true);
            }
            buffer.WriteBlock(Unk2);
        }
    }
}
