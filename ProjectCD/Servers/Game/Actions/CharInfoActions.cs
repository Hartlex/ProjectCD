using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.DB;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using SunStructs.Definitions;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Connection.Client;
using SunStructs.PacketInfos.Game.Connection.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.CharInfo;
using SunStructs.ServerInfos.General.Object.Character.Player;

namespace ProjectCD.Servers.Game.Actions
{
    internal class CharInfoActions
    {
        private int _count;
        public CharInfoActions()
        {
            RegisterCharInfoAction(81, OnAskDuplicateName);
            RegisterCharInfoAction(111, OnAskCreateCharacter);
            RegisterCharInfoAction(137, OnAskDeleteCharacter);
            Logger.Instance.LogOnLine($"[GAME][CHAR_INFO] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterCharInfoAction(byte subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.CHAR_INFO, subType, action);
            _count++;
        }
        private void OnAskDuplicateName(ByteBuffer buffer, Connection connection)
        {
            var charName = Encoding.ASCII.GetString(ByteUtils.CutTail(buffer.ReadBlock(16)));
            if (Database.Instance.IsCharNameFree(charName))
            {
                var ackPacket = new AckDuplicateName(new());
                connection.Send(ackPacket);
                return;
            }

            var nakPacket = new NakDuplicateName(new(CharIdCheckResult.RC_CHAR_IDCHECK_FAILED));
            connection.Send(nakPacket);
        }
        private void OnAskCreateCharacter(ByteBuffer buffer, Connection connection)
        {
            var info = new AskCreateCharInfo(ref buffer);
            var user = connection.User;
            var renderInfo = new BaseCharacterRenderInfo(info.HeightCode, info.FaceCode, info.HairCode);
            var resultCode = Database.Instance.CreateCharacter(user.UserID, info.ClassCode, info.CharName, renderInfo, out var characterPart);
            if (resultCode == CharCreateResult.RC_CHAR_CREATE_SUCCESS)
            {
                var ackPacket = new AckCreateCharacter(characterPart);
                connection.Send(ackPacket);
                return;
            }

            var nakPacket = new NakCreateCharacter(new(resultCode));
            connection.Send(nakPacket);
        }
        private void OnAskDeleteCharacter(ByteBuffer buffer, Connection connection)
        {
            var info = new AskDeleteCharInfo(ref buffer);
            CharDestroyResult resultCode = CharDestroyResult.RC_CHAR_DESTROY_FAILED;
            if (info.DelCheck == "Delete")
            {
                var user = connection.User;
                resultCode = Database.Instance.DeleteCharacter(user.UserID, info.Slot);
                if (resultCode == CharDestroyResult.RC_CHAR_DESTROY_SUCCESS)
                {
                    var ackPacket = new AckDeleteCharacter(new EmptyPacket());
                    connection.Send(ackPacket);
                    return;
                }


            }
            var nakPacket = new NakDeleteCharacter(new NakDeleteCharacterInfo(resultCode));
            connection.Send(nakPacket);

        }
    }
}
