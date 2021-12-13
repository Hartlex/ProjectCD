using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Logging;
using SunStructs.PacketInfos.Game.Sync.Client;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        private uint _fieldCode;
        private float _angle;
        private ushort _tileID;
        private byte _moveState;

        public void PlayerMovementInit(ref SqlDataReader reader)
        {
            var posX = reader.GetFloat(30);
            var posY = reader.GetFloat(31);
            var posZ = reader.GetFloat(32);
            _fieldCode = unchecked((uint)reader.GetInt32(29));
            _angle = Convert.ToUInt16(reader.GetFloat(33));
            SetPos(new SunVector(posX, posY, posZ));
        }

        public void OnKeyboardMove(KeyBoardMoveInfo info)
        {
            SetPos(info.CurrentPosition);
            _angle = info.Angle;
            _tileID = info.TileIndex;
            _moveState = info.MoveState;

            var brdInfo = new KeyboardMoveBrdInfo(GetID(), info.CurrentPosition, info.TileIndex, info.Angle,
                info.MoveState);
            var packet = new MoveSyncBrd(brdInfo);
            GetCurrentField()?.SendToAllBut(packet,this);
        }

        public void OnMouseMove(MouseMoveInfo info)
        {
            SetPos(info.CurrentPosition);
        }

        public void OnMoveStop(MoveStopInfo info)
        {
            SetPos(info.CurrentPosition);
        }

        public void OnJump(JumpInfo info)
        {
            SetPos(info.LandPosition);
            _moveState = info.MoveState;
        }

        public void OnAfterJump(AfterJumpInfo info)
        {
            SetPos(info.CurrentPosition);
        }

        public uint GetCurrentMapCode()
        {
            return _fieldCode;
        }
        private void MapCoordinates()
        {
            var pos = GetPos();
            File.AppendAllLines($".//mapdata//{_fieldCode}.txt",new []{$"{_tileID};{pos.GetX()};{pos.GetY()};{pos.GetZ()}" });
        }
    }
}
