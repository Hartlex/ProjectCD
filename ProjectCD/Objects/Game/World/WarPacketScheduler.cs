using System.Timers;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Sync.Server.WarPacket;
using SunStructs.Packets.GameServerPackets.Sync;
using Timer = System.Timers.Timer;

namespace ProjectCD.Objects.Game.World
{
    internal class WarPacketScheduler
    {
        private readonly Timer _timer;
        private readonly List<WarPacketInfo> _warPacketQueue;
        private readonly Field _field;
        private bool _active;

        public WarPacketScheduler(Field field)
        {
            _field = field;
            _warPacketQueue = new List<WarPacketInfo>(1000);
            _timer = new (Const.MAX_PACKET_DELAY_TIME);
            _timer.AutoReset = true;
            _timer.Elapsed += BroadCast;
            _timer.Start();
        }

        private void BroadCast(object? sender, ElapsedEventArgs e)
        {
            if (_warPacketQueue.Count == 0)
            {
                Deactivate();
                return;
            }
            ComposeWarPacketInfo info;
            lock (_warPacketQueue)
            {
#if DEBUG
                Logger.Instance.Log($"Field[{_field}] broadcasts:{_warPacketQueue.Count} packets!");
#endif
                info = new ComposeWarPacketInfo(_warPacketQueue.ToArray());
                _warPacketQueue.Clear();

            }
            _field.SendToAll(new ComposeWarPacket(info));

        }

        private void Deactivate()
        {
            _timer.Stop();
            _active = false;
        }

        private void Activate()
        {
            _active = true;
            _timer.Start();
        }
        public void AddInfo(WarPacketInfo info)
        {
            if (!_active)
            {
                Activate();
            }
            try
            {
                _warPacketQueue.Add(info);
            }
            catch (Exception e)
            {
                Logger.Instance.Log($"Field[{_field}] packageOverload. LOOSING PACKETS!",LogType.ERROR);
            }
        }
    }
}
