using CDShared.ByteLevel;
using SunStructs.ServerInfos.General;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class ItemRenderInfo : ServerPacketInfo
    {
        public readonly uint ObjectKey;
        public readonly uint OwnerKey;
        public readonly byte FieldItemType;
        public readonly ulong Money;
        public readonly byte[] ItemBytes;
        public readonly SunVector Position;

        public ItemRenderInfo(uint objectKey, uint ownerKey, byte fieldItemType, ulong money, byte[] itemBytes, SunVector position)
        {
            ObjectKey = objectKey;
            OwnerKey = ownerKey;
            FieldItemType = fieldItemType;
            Money = money;
            ItemBytes = itemBytes;
            Position = position;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt32(ObjectKey);
            buffer.WriteUInt32(OwnerKey);
            buffer.WriteByte(FieldItemType);
            buffer.WriteUInt64(Money);
            //if(FieldItemType ==1)
            //    buffer.WriteBlock(new byte[27]);
            //else
            buffer.WriteBlock(ItemBytes);
            Position.GetBytes(ref buffer);
        }
    }
}

