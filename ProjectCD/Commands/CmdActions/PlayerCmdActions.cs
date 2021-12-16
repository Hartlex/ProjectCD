using ProjectCD.GlobalManagers.DB;
using ProjectCD.Objects.NetObjects;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.Packets.GameServerPackets.Item;

namespace ProjectCD.Commands.CmdActions
{
    public static class PlayerCmdActions
    {
        public static void AddItem(List<string> paramList, User user)
        {
            var itemId = ushort.Parse(paramList[0]);
            var amount = int.Parse(paramList[1]);

            user.Player.GetInventory().InsertItem(itemId, amount, out var itemSlotInfos);
            
            var outInfo = new AckItemPickupInfo(itemSlotInfos);
            var outPacket = new AckItemPickup(outInfo);
            user.SendPacket(outPacket);
        }

        public static void Save(List<string> paramList, User user)
        {
            Database.Instance.UpdateFullCharacter(user.Player);
        }
        //public static void SpawnMob(List<string> paramList, User user)
        //{
        //    var monsterId = ushort.Parse(paramList[0]);
        //    user.SelectedPlayer.CurrentMap.SpawnMobAtPlayer(user.GetUserId(),monsterId);
        //}

        //public static void AddStatus(List<string> paramList, User user)
        //{
        //    var targetId = uint.Parse(paramList[0]);
        //    var sateId = ushort.Parse(paramList[1]);
        //    var sateTime = ushort.Parse(paramList[2]);

        //}
    }
}
