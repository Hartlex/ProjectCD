using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
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
        public ItemActions()
        {
            RegisterItemAction(211,OnAskMoveItem);
        }
        private void RegisterItemAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.ITEM, subType, action);
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

    }
}
