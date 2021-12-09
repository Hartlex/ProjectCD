﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Generics;
using NetworkCommsDotNet.Connections;

namespace ProjectCD.GlobalManagers.PacketParsers
{
    internal class WorldPacketParser : Singleton<WorldPacketParser>
    {
        public void ParsePacket(ByteBuffer buffer, Connection connection)
        {


        }
    }
    internal class GamePacketParser : Singleton<GamePacketParser>
    {
        public void ParsePacket(ByteBuffer buffer, Connection connection)
        {


        }
    }
    internal class AuthPacketParser : Singleton<AuthPacketParser>
    {
        public void ParsePacket(ByteBuffer buffer, Connection connection)
        {


        }
    }

}