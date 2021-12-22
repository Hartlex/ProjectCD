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
using ProjectCD.Objects.Game.Items;
using SunStructs.Definitions;
using SunStructs.Formulas.Item;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Item.Client;
using SunStructs.PacketInfos.Game.Item.Dual;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Item;
using SunStructs.RuntimeDB.Parsers;

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
            RegisterItemAction(31, OnAskMoveQuick);
            RegisterItemAction(149, OnAskBuyItem);
            RegisterItemAction(176, OnAskSellItem);
            RegisterItemAction(187, OnAskDeleteItem);
            RegisterItemAction(63, OnAskDropItem);

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
            var info = new AskBuyItemInfo(ref buffer);
            if (connection.User.Player.TryBuyItem(info, out var ackInfo))
            {
                var outPacket = new AckBuyItem((ackInfo!));
                connection.Send(outPacket);
            }
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
            var outPacket = new AckItemToQuick(info);
            connection.Send(outPacket);
        }
        private void OnAskUnbindQuick(ByteBuffer buffer, Connection connection)
        {
            var info = new UnbindQuickInfo(ref buffer);
            connection.User.Player.GetQuickSlotContainer().ClearSlot(info.Pos);
            var outPacket = new AckUnbindQuick(info);
            connection.Send(outPacket);
        }
        private void OnAskMoveQuick(ByteBuffer buffer, Connection connection)
        {
            var info = new MoveQuickInfo(ref buffer);
            connection.User.Player.GetQuickSlotContainer().MoveSlot(info.Pos1, info.Pos2);
            var outPacket = new AckMoveQuick(info);
            connection.Send(outPacket);
        }
        private void OnAskSellItem(ByteBuffer buffer, Connection connection)
        {
            var info = new AskSellItemInfo(ref buffer);
            var result = connection.User.Player.TrySellItem(info, out var ackInfo);
            switch (result)
            {
                case ItemResult.RC_ITEM_FAILED:
                    break;
                case ItemResult.RC_ITEM_SUCCESS:
                        var outPacket = new AckSellItem(ackInfo);
                        connection.Send(outPacket);
                    break;

            }
        }
        private void OnAskDeleteItem(ByteBuffer buffer, Connection connection)
        {
            var info = new AskDeleteItemInfo(ref buffer);

            var result = connection.User.Player.TryDeleteItem(info);

            switch (result)
            {
                case ItemResult.RC_ITEM_FAILED:
                    break;
                case ItemResult.RC_ITEM_SUCCESS:
                    var packet = new AckDeleteItem();
                    connection.Send(packet);
                    break;

            }



        }

        private void OnAskDropItem(ByteBuffer buffer, Connection connection)
        {
            var player = connection.User.Player;
            var info = new AskDropItemInfo(ref buffer);
            if (player.TryDropItem(info, out var droppedItem)== ItemResult.RC_ITEM_SUCCESS)
            {
                player.GetCurrentField().DropItemFromPlayer(player,droppedItem!);
            }
        }
    }
}
