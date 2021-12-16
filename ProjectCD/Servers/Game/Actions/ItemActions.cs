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

    }
}
