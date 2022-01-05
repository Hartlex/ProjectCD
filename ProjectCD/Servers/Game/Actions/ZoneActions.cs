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
using SunStructs.PacketInfos.Game.Zone.Client;
using SunStructs.PacketInfos.Game.Zone.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Zone;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Servers.Game.Actions
{
    internal class ZoneActions
    {
        private int _count;
        public ZoneActions()
        {
            RegisterZoneAction(204, AskUserPortal);


            Logger.Instance.LogOnLine($"[GAME][ZONE] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterZoneAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.ZONE, subType, action);
            _count++;
        }

        private void AskUserPortal(ByteBuffer buffer, Connection connection)
        {
            var info = new AskZoneMoveInfo(ref buffer);
            SunVector newPos =null;
            if (PortalDB.Instance.TryFindPortal(info.PortalID, out var portal))
            {
                var fromField = connection.User.GetConnectedGameServer().GetField(portal.FromField);
                if (fromField == null) return;
                var toField = connection.User.GetConnectedGameServer().GetField(portal.ToField);
                if(toField == null) return;

                if (!fromField.LeaveField(connection.User.Player)) return;


                if (!AreaDB.Instance.TryGetAreaPosition(portal.ToField, portal.ToArea, out newPos))
                {
                    newPos = ExtraNPCInfoDB.Instance.GetRandomNPCPosOnMap(portal.ToField);
                    if (newPos == null)
                    {
                        Logger.Instance.Log("No Random Npc found!",LogType.ERROR);
                        return;
                    }
                }
                //if (!connection.User.Player.EnterField(toField,newPos)) return;
                connection.User.Player.SetNewFieldAndPos(portal.ToField,newPos);

                var outInfo = new AckZoneMoveInfo(portal.PortalId);
                var outPacket = new AckZoneMove(outInfo);
                connection.Send(outPacket);
            }

        }
    }
}
