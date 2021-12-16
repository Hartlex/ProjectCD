using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos.Game.Item.Dual;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Item;

namespace ProjectCD.Servers.Game.Actions
{
    internal class ItemActions
    {
        private int _count;
        public ItemActions()
        {
            RegisterItemAction(211,OnAskMoveItem);
            RegisterItemAction(190,OnAskBindItem);
            RegisterItemAction(192, OnAskBindSkillToQuick);
            RegisterItemAction(59, OnAskBindItemToQuick);
            RegisterItemAction(53, OnAskUnbindQuick);
            RegisterItemAction(31, OnC2SAskMoveQuick);

            Logger.Instance.LogOnLine($"[GAME][ITEM] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterItemAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.ITEM, subType, action);
            _count++;
        }

        private void OnAskBuyItem(ByteBuffer buffer, Connection connection)
        {

        }

        private void OnAskMoveItem(ByteBuffer buffer, Connection connection)
        {
            ItemMoveInfo itemMoveInfo = new(ref buffer);
            var user = connection.User;
            if (user.Player.ItemMove(itemMoveInfo))
            {
                var outPacket = new AckItemMove(itemMoveInfo);
                connection.Send(outPacket);
            }
        }

        private void OnAskBindItem(ByteBuffer buffer, Connection connection)
        {
            var pos = buffer.ReadByte();
            var player = connection.User.Player;
            var item = player.GetInventory().GetItem(pos);
            var toPos = (byte)item!.GetBaseInfo().EquipPosition;
            var b = new byte[]
            {
                1, 2,
                pos, toPos, 0
            };
            var buffer2 = new ByteBuffer(b);
            var askMoveItemInfo = new ItemMoveInfo(ref buffer2);
            player.ItemMove(askMoveItemInfo);
            var outPacket = new AckItemMove(askMoveItemInfo);
            connection.Send(outPacket);
        }

        private void OnAskBindSkillToQuick(ByteBuffer buffer, Connection connection)
        {
            var info = new BindSkillToQuickInfo(ref buffer);
            connection.User.Player.GetQuickSlotContainer().SetSkillRef(info.QuickPos, info.SkillCode);
            var outPacket = new AckSkillToQuick(info);
            connection.Send(outPacket);
        }

        private void OnAskBindItemToQuick(ByteBuffer buffer, Connection connection)
        {
            var info = new BindItemToQuickInfo(ref buffer);
            var itemId = connection.User.Player.GetInventory().GetItem(info.InvPos)!.GetItemId();
            connection.User.Player.GetQuickSlotContainer().SetItemRef(info.QuickPos,info.InvPos,itemId);
        }
        private void OnAskUnbindQuick(ByteBuffer buffer, Connection connection)
        {
            var info = new UnbindQuickInfo(ref buffer);
            connection.User.Player.GetQuickSlotContainer().ClearSlot(info.Pos);
            var outPacket = new AckUnbindQuick(info);
            connection.Send(outPacket);
        }
        private void OnC2SAskMoveQuick(ByteBuffer buffer, Connection connection)
        {
            var info = new MoveQuickInfo(ref buffer);
            connection.User.Player.GetQuickSlotContainer().MoveSlot(info.Pos1, info.Pos2);
            var outPacket = new AckMoveQuick(info);
            connection.Send(outPacket);
        }
    }
}
