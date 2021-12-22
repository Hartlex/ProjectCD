using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter;
using ProjectCD.Objects.Game.Items;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject
{
    public class FieldItem : ObjectBase
    {
        private Character? _owner;
        private Item? _item;
        private ulong _money;
        private uint _fromMonsterKey;
        private FieldItemType _fieldItemType;

        public FieldItem(uint key) : base(key)
        {
            SetObjectType(ObjectType.ITEM_OBJECT);
            _fromMonsterKey = 0;
        }
        public void SetItem(Item item)
        {
            _fieldItemType = FieldItemType.ITEM;
            _item = item;
        }

        public void SetMoney(ulong money)
        {
            _fieldItemType = FieldItemType.MONEY;
            _money = money;
        }
        public void SetOwner(Character owner)
        {
            _owner = owner;
        }

        public override void OnEnterField(Field field, SunVector pos, ushort angle = 0)
        {
            base.OnEnterField(field, pos, angle);

            var outInfo = new ItemEnterFieldInfo(_fromMonsterKey, new ItemRenderInfo(
                GetKey(),
                _owner?.GetKey() ?? 0,
                (byte) _fieldItemType,
                _money,
                _item?.GetBytes() ?? new byte[27],
                pos
            ));

            var packet = new ItemEnterFieldBrd(outInfo);
            field.Broadcast(packet);
        }
    }

    enum FieldItemType
    {
        ITEM,
        MONEY
    }
}
