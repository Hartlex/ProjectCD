using System.Data.SqlClient;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Object.Character.Player
{
    public class ClientCharacterPart : ServerPacketInfo
    {
        public readonly byte Slot;
        public readonly byte Size;
        public readonly byte[] CharName;
        public readonly byte HeightCode;
        public readonly byte FaceCode;
        public readonly byte HairCode;
        public readonly byte ClassCode;
        public readonly byte[] Level;
        public readonly byte[] Region;
        public readonly byte[] PosX;
        public readonly byte[] PosY;
        public readonly byte[] PosZ;
        public readonly byte EquipNumber;
        public readonly byte[] EquipInfo;
        public readonly byte WaitForDelete;
        public readonly byte[] Unk2;
        public readonly byte[] Unk3;
        public readonly byte[] Unk4;

        public ClientCharacterPart(byte slot, byte size, string charName, byte heightCode, byte faceCode, byte hairCode, byte classCode, ushort level, uint region, float posX, float posY, float posZ, byte equipNumber, byte[] equipInfo, byte waitForDelete, byte[] unk2, byte[] unk3, byte[] unk4)
        {
            Slot = slot;
            Size = size;
            CharName = ByteUtils.ToByteArray(charName, 16);
            HeightCode = heightCode;
            FaceCode = faceCode;
            HairCode = hairCode;
            ClassCode = classCode;
            Level = BitConverter.GetBytes(level);
            Region = BitConverter.GetBytes(region);
            PosX = BitConverter.GetBytes((short) posX);
            PosY = BitConverter.GetBytes((short) posY);
            PosZ = BitConverter.GetBytes((short) posZ);
            EquipNumber = equipNumber;
            EquipInfo = equipInfo;
            WaitForDelete = waitForDelete;
            Unk2 = unk2;
            Unk3 = unk3;
            Unk4 = unk4;
        }

        public ClientCharacterPart(ref SqlDataReader reader)
        {
            Slot = reader.GetByte(2);
            Size = 16;
            CharName = ByteUtils.ToByteArray(reader.GetString(4),16);
            HeightCode = reader.GetByte(5);
            FaceCode = reader.GetByte(6);
            HairCode = reader.GetByte(7);
            ClassCode = reader.GetByte(3);
            Level = BitConverter.GetBytes(reader.GetInt16(8));
            Region = BitConverter.GetBytes(reader.GetInt32(29));
            PosX = BitConverter.GetBytes((ushort)reader.GetFloat(30));
            PosY = BitConverter.GetBytes((ushort)reader.GetFloat(31));
            PosZ = BitConverter.GetBytes((ushort)reader.GetFloat(32));
            EquipNumber = 0;
            EquipInfo =(byte[]) reader[40];
            WaitForDelete = 0; //Waiting for Delete
            Unk2 = ByteUtils.ToByteArray("Hello", 32);
            Unk3 = new byte[] { 0, 0, 0 };
            Unk4 = new byte[] { 0, 0, 0, 0 };

        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Slot);
            buffer.WriteByte(Size);
            buffer.WriteBlock(CharName);
            buffer.WriteByte(HeightCode);
            buffer.WriteByte(FaceCode);
            buffer.WriteByte(HairCode);
            buffer.WriteByte(ClassCode);
            buffer.WriteBlock(Level);
            buffer.WriteBlock(Region);
            buffer.WriteBlock(PosX);
            buffer.WriteBlock(PosY);
            buffer.WriteBlock(PosZ);
            buffer.WriteByte(EquipNumber);
            buffer.WriteBlock(EquipInfo);
            buffer.WriteByte(WaitForDelete);
            if (WaitForDelete != 0)
            {
                buffer.WriteByte(16);
                buffer.WriteBlock(new byte[16]);
            }
            buffer.WriteBlock(Unk2);
            buffer.WriteBlock(Unk3);
            buffer.WriteBlock(Unk4);

        }
    }
}
