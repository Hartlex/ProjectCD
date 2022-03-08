using ProjectCD.GlobalManagers.DB;
using ProjectCD.Objects.NetObjects;
using SunStructs.PacketInfos.Game.Item.Server;
using SunStructs.Packets.GameServerPackets.Item;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Commands.CmdActions
{
    internal static class PlayerCmdActions
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

        public static void SpawnMobs(List<string> paramList, User user)
        {
            var player = user.Player;
            var field = player.GetCurrentField();
            if (field == null) return;
            if (!ushort.TryParse(paramList[0], out var key)) return;
            if (!int.TryParse(paramList[1], out var amount)) return;
            var pos = player.GetPos();
            int j = 0;
            int k = 0;
            var sep = (int) MathF.Sqrt(amount);
            for (int i = 0; i < amount; i++)
            {
                field.SpawnMonsterEx(key,pos+new SunVector(2f*k,2f*j,0));
                k++;
                if (i % sep == 0)
                {
                    j++;
                    k = 0;
                }
            }
            
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
