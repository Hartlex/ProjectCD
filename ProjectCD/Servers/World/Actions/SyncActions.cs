using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.PacketInfos.World.Sync.Client;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Sync;

namespace ProjectCD.Servers.World.Actions
{
    internal class SyncActions
    {
        private int _count;
        public SyncActions()
        {
            RegisterSyncAction(96,OnChangeSector);
            Logger.Instance.LogOnLine($"[WORLD][SYNC] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterSyncAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            WorldPacketParser.Instance.RegisterAction((byte)WorldPacketType.SYNC, subType, action);
            _count++;
        }

        private void OnChangeSector(ByteBuffer buffer, Connection connection)
        {
            var info = new ChangeSectorInfo(ref buffer);
            connection.User.Player.OnSectorChange(info.SectorID,info.MapID);
        }
    }
}
