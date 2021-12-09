using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.PacketInfos;

namespace SunStructs.Packets
{
    public abstract class Packet
    {
        private readonly byte _packetType;
        private readonly byte _packetSubType;
        private readonly byte[] _data;

        protected Packet(byte gamePacketType, byte packetSubType, ServerPacketInfo serverPacketStruct)
        {
            _packetType = gamePacketType;
            _packetSubType = packetSubType;
            _data = serverPacketStruct.GetBytes();
        }
        
        public byte[] GetBytes()
        {
            var length = _data.Length + 2;
            var result = new byte[length + 2];
            Buffer.BlockCopy(BitConverter.GetBytes((short)length), 0, result, 0, 2);
            result[2] = _packetType;
            result[3] = _packetSubType;
            Buffer.BlockCopy(_data, 0, result, 4, _data.Length);
            return result;
        }
    }

    public class GameServerPacket : Packet
    {
        public GameServerPacket(GamePacketType gamePacketType, byte packetSubType, ServerPacketInfo serverPacketStruct) : 
            base((byte)gamePacketType,packetSubType, serverPacketStruct) { }
    }
    public class WorldServerPacket : Packet
    {
        public WorldServerPacket(WorldPacketType worldPacketType, byte packetSubType, ServerPacketInfo serverPacketStruct) : 
            base((byte)worldPacketType, packetSubType, serverPacketStruct) { }
    }
    public class AuthServerPacket : Packet
    {
        public AuthServerPacket(AuthPacketType autPacketType, byte packetSubType, ServerPacketInfo serverPacketStruct) : 
            base((byte)autPacketType, packetSubType, serverPacketStruct) { }
    }
}
