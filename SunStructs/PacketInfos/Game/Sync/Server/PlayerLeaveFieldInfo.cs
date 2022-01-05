using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Sync.Server
{
    public class PlayerLeaveFieldInfo : ServerPacketInfo
    {
        public readonly byte Count;
        public readonly ushort[] PlayerKeys;

        public PlayerLeaveFieldInfo(uint key)
        {
            Count = 1;
            PlayerKeys = new [] {(ushort) key};
        }

        public PlayerLeaveFieldInfo(ushort[] keys)
        {
            Count =(byte) keys.Length;
            PlayerKeys = keys;
        }
        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Count);
            foreach (var playerKey in PlayerKeys)
            {
                buffer.WriteUInt32(playerKey);
            }
        }
    }
}
