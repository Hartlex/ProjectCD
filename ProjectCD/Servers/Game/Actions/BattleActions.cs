using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos.Game.Battle.Client;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Battle;
using SunStructs.Packets.GameServerPackets.Sync;
using static SunStructs.Packets.GameServerPackets.Battle.BattleProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal class BattleActions
    {
        private int _count;
        public BattleActions()
        {
            RegisterBattleAction(ASK_PLAYER_ATTACK,OnAskPlayerAttack);
            Logger.Instance.LogOnLine($"[GAME][BATTLE] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterBattleAction(BattleProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.BATTLE, (byte)subType, action);
            _count++;
        }

        private void OnAskPlayerAttack(ByteBuffer buffer, Connection connection)
        {
            //ByteUtils.Print(buffer.GetData());
            var info = new AskPlayerAttackInfo(ref buffer);
            Logger.Instance.Log($"Attack[{info.ClientSerial}][{info.StyleRef}]");
            var outInfo = new ActionExpiredInfo(connection.User.UserID);
            var packet = new ActionExpiredCmd(outInfo);
            connection.Send(packet);
        }

    }

}
