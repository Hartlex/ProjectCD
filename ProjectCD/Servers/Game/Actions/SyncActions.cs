using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;
using CDShared.Logging;
using ProjectCD.GlobalManagers.PacketParsers;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.World;
using SunStructs.PacketInfos;
using SunStructs.PacketInfos.Game.Sync.Client;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.Packets.GameServerPackets.Sync;
using SunStructs.ServerInfos.General;
using static SunStructs.Packets.GameServerPackets.Sync.SyncProtocol;

namespace ProjectCD.Servers.Game.Actions
{
    internal class SyncActions
    {
        private int _count;
        public SyncActions()
        {
            RegisterSyncAction(ASK_ENTER_FIELD, AskEnterField);
            RegisterSyncAction(ON_KEYBOARD_MOVE, OnKeyboardMove);
            RegisterSyncAction(ON_JUMP, OnJump);
            RegisterSyncAction(ON_MOUSE_MOVE, OnMouseMove);
            RegisterSyncAction(ON_JUMP_END, OnJumpEnd);
            RegisterSyncAction(ON_MOVE_STOP, OnMoveStop);
            RegisterSyncAction(ON_TARGET_MOVE, OnTargetMove);

            Logger.Instance.LogOnLine($"[GAME][SYNC] {_count} actions registered!", LogType.SUCCESS);
            Logger.Instance.Log($"", LogType.SUCCESS);
        }
        private void RegisterSyncAction(SyncProtocol subType, Action<ByteBuffer, Connection> action)
        {
            GamePacketParser.Instance.RegisterAction((byte)GamePacketType.SYNC,(byte) subType, action);
            _count++;
        }

        private void AskEnterField(ByteBuffer buffer, Connection connection)
        {
            var checksum = buffer.ReadBlock(16);
            var player = connection.User.Player;
            var field = connection.User.GetConnectedGameServer().GetField(player.GetCurrentMapCode());
            if (!player.EnterField(field,player.GetPos()))
            {
                return;
            }
            var guildPacket = new AllPlayersGuildInfoCmd(new TestPacketInfo(new byte[1]));
            //var equipPacket = new AllPlayersEquipInfoCmd(new TestPacketInfo(new byte[1]));
            var enterPacket = new AckEnterWorld(new AckEnterWorldInfo(connection.User.Player.GetPos()));

            connection.Send(guildPacket, enterPacket);
        }

        private void OnKeyboardMove(ByteBuffer buffer, Connection connection)
        {
            var info = new KeyBoardMoveInfo(ref buffer);
            connection.User.Player.OnKeyboardMove(info);
            
        }

        private void OnJump(ByteBuffer buffer, Connection connection)
        {
            var info = new JumpInfo(ref buffer);
            connection.User.Player.OnJump(info);

        }

        private void OnMouseMove(ByteBuffer buffer, Connection connection)
        {
            var info = new MouseMoveInfo(ref buffer);
            connection.User.Player.OnMouseMove(info);

        }

        private void OnJumpEnd(ByteBuffer buffer, Connection connection)
        {
            var info = new AfterJumpInfo(ref buffer);
            connection.User.Player.OnAfterJump(info);
        }

        private void OnMoveStop(ByteBuffer buffer, Connection connection)
        {
            var info = new MoveStopInfo(ref buffer);
            connection.User.Player.OnMoveStop(info);
        }

        private void OnTargetMove(ByteBuffer buffer, Connection connection)
        {
            var info = new TargetMoveInfo(ref buffer);
            connection.User.Player.OnTargetMove(info);
        }

        private void Test(Connection connection)
        {
            var pos = connection.User.Player.GetPos();
            var b = new List<byte>();
            byte count = 10;
            int i = 1;

            b.Add(count);

            //BEGIN 1

            #region notRelevant

            var buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort) (34 + i));
            buffer.WriteUInt16((ushort) 100);
            buffer.WriteUInt16((ushort) 100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i*0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            var byte1_1 = (byte) 0;
            var byte1_2 = (byte) 0;
            var byte1_3 = (byte) 0;
            var byte1_4 = (byte) 0;

            var byte2_4 = (byte) 0;
            var byte2_3 = (byte) 0;
            var byte2_2 = (byte) 0;
            var byte2_1 = (byte) 0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);    
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 1); 
            byte2_1 = BitManip.Set1(byte2_1, 1); 
            byte2_1 = BitManip.Set2(byte2_1, 1); 
            byte2_1 = BitManip.Set3(byte2_1, 1); 
            byte2_1 = BitManip.Set4(byte2_1, 1); 
            byte2_1 = BitManip.Set5(byte2_1, 1); 
            byte2_1 = BitManip.Set6(byte2_1, 1); 
            byte2_1 = BitManip.Set7(byte2_1, 1);

            byte2_2 = BitManip.Set0(byte2_2, 0); 
            byte2_2 = BitManip.Set1(byte2_2, 0); 
            byte2_2 = BitManip.Set2(byte2_2, 0); 
            byte2_2 = BitManip.Set3(byte2_2, 0); 
            byte2_2 = BitManip.Set4(byte2_2, 0); 
            byte2_2 = BitManip.Set5(byte2_2, 0);  
            byte2_2 = BitManip.Set6(byte2_2, 0); 
            byte2_2 = BitManip.Set7(byte2_2, 0); 

            byte2_3 = BitManip.Set0(byte2_3, 0); 
            byte2_3 = BitManip.Set1(byte2_3, 0); 
            byte2_3 = BitManip.Set2(byte2_3, 0); 
            byte2_3 = BitManip.Set3(byte2_3, 0); 
            byte2_3 = BitManip.Set4(byte2_3, 0); 
            byte2_3 = BitManip.Set5(byte2_3, 0); 
            byte2_3 = BitManip.Set6(byte2_3, 0); 
            byte2_3 = BitManip.Set7(byte2_3, 0); 

            byte2_4 = BitManip.Set0(byte2_4, 0); 
            byte2_4 = BitManip.Set1(byte2_4, 0); 
            byte2_4 = BitManip.Set2(byte2_4, 0); 
            byte2_4 = BitManip.Set3(byte2_4, 0); 
            byte2_4 = BitManip.Set4(byte2_4, 0); 
            byte2_4 = BitManip.Set5(byte2_4, 0); 
            byte2_4 = BitManip.Set6(byte2_4, 0); 
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteUInt32(0); //specialEffects


            //pet??
            buffer.WriteByte(0); //hasPet
            //buffer.WriteUInt16(0x2b); //PetInfo
            //buffer.WriteByte(0x46);
            //buffer.WriteByte(0x03);
            //buffer.WriteString("PetTest",10,true);
            
            buffer.WriteByte(0); //unk Count 1byte
            //buffer.WriteBlock(new byte[2]);

            buffer.WriteByte(0); //unk

            buffer.WriteByte(0); //isRider
            //buffer.WriteBlock(new byte[27]); //riderRenderInfo

            buffer.WriteByte(0); //bool IscollectInfo 12bytes
            //
            //buffer.WriteBlock(new byte[] //Collect info??
            //{
            //    0,0,0,0,
            //    0,0,0,0,
            //    0,0,0,0
            //});

            //
            buffer.WriteByte(0); //?count 8Bytes 
            //buffer.WriteBlock(new byte[8]);

            buffer.WriteByte(0); //stateCount 6bytes (id:2 time:4)
            //buffer.WriteBlock(new byte[]
            //{
            //    1,0, //stateID
            //    0,0,3,0 //time
            //});
            //buffer.WriteBlock(new byte[]
            //{
            //    2,0, //stateID
            //    0,0,4,0 //time
            //});
            buffer.WriteByte(0);//count  1Byte
            //buffer.WriteByte(0);
            //buffer.WriteByte(0);


            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 2
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;
            
            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 1);
            byte2_2 = BitManip.Set1(byte2_2, 1);
            byte2_2 = BitManip.Set2(byte2_2, 1);
            byte2_2 = BitManip.Set3(byte2_2, 1);
            byte2_2 = BitManip.Set4(byte2_2, 1);
            byte2_2 = BitManip.Set5(byte2_2, 1);
            byte2_2 = BitManip.Set6(byte2_2, 1);
            byte2_2 = BitManip.Set7(byte2_2, 1);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 3
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 1);
            byte2_3 = BitManip.Set1(byte2_3, 1);
            byte2_3 = BitManip.Set2(byte2_3, 1);
            byte2_3 = BitManip.Set3(byte2_3, 1);
            byte2_3 = BitManip.Set4(byte2_3, 1);
            byte2_3 = BitManip.Set5(byte2_3, 1);
            byte2_3 = BitManip.Set6(byte2_3, 1);
            byte2_3 = BitManip.Set7(byte2_3, 1);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 4
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 1);
            byte2_4 = BitManip.Set1(byte2_4, 1);
            byte2_4 = BitManip.Set2(byte2_4, 1);
            byte2_4 = BitManip.Set3(byte2_4, 1);
            byte2_4 = BitManip.Set4(byte2_4, 1);
            byte2_4 = BitManip.Set5(byte2_4, 1);
            byte2_4 = BitManip.Set6(byte2_4, 1);
            byte2_4 = BitManip.Set7(byte2_4, 1);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 5
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 6
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 7
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END

            //BEGIN 8
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END


            //BEGIN 9
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            i++;
            //END


            //BEGIN 10
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion
            #region notRelevant

            buffer = new ByteBuffer();
            buffer.WriteByte(1);
            buffer.WriteUInt16((ushort)(34 + i));
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16((ushort)100);
            buffer.WriteUInt16(10);
            buffer.WriteString("Hyppoo" + i, 16, true);
            pos += new SunVector(i * 0.25f, 0, 0);
            pos.GetBytes(ref buffer);
            buffer.WriteUInt16(0);
            buffer.WriteUInt16(150);
            buffer.WriteUInt16(150);
            //buffer.WriteUInt32(0x14880500);
            byte1_1 = (byte)0;
            byte1_2 = (byte)0;
            byte1_3 = (byte)0;
            byte1_4 = (byte)0;

            byte2_4 = (byte)0;
            byte2_3 = (byte)0;
            byte2_2 = (byte)0;
            byte2_1 = (byte)0;

            #endregion

            #region byte1
            byte1_1 = BitManip.Set0(byte1_1, 0);
            byte1_1 = BitManip.Set1(byte1_1, 0);
            byte1_1 = BitManip.Set2(byte1_1, 0);
            byte1_1 = BitManip.Set3(byte1_1, 0);
            byte1_1 = BitManip.Set4(byte1_1, 0);
            byte1_1 = BitManip.Set5(byte1_1, 0);
            byte1_1 = BitManip.Set6(byte1_1, 0);
            byte1_1 = BitManip.Set7(byte1_1, 0);

            byte1_2 = BitManip.Set0(byte1_2, 1);
            byte1_2 = BitManip.Set1(byte1_2, 0);
            byte1_2 = BitManip.Set2(byte1_2, 0);
            byte1_2 = BitManip.Set3(byte1_2, 0);
            byte1_2 = BitManip.Set4(byte1_2, 0);
            byte1_2 = BitManip.Set5(byte1_2, 0);
            byte1_2 = BitManip.Set6(byte1_2, 0);
            byte1_2 = BitManip.Set7(byte1_2, 0);

            byte1_3 = BitManip.Set0(byte1_3, 0);
            byte1_3 = BitManip.Set1(byte1_3, 0);
            byte1_3 = BitManip.Set2(byte1_3, 0);
            byte1_3 = BitManip.Set3(byte1_3, 0);
            byte1_3 = BitManip.Set4(byte1_3, 0);
            byte1_3 = BitManip.Set5(byte1_3, 0);
            byte1_3 = BitManip.Set6(byte1_3, 0);
            byte1_3 = BitManip.Set7(byte1_3, 0);

            byte1_4 = BitManip.Set0(byte1_4, 0);
            byte1_4 = BitManip.Set1(byte1_4, 0);
            byte1_4 = BitManip.Set2(byte1_4, 0);
            byte1_4 = BitManip.Set3(byte1_4, 0);
            byte1_4 = BitManip.Set4(byte1_4, 0);
            byte1_4 = BitManip.Set5(byte1_4, 0);
            byte1_4 = BitManip.Set6(byte1_4, 0);
            byte1_4 = BitManip.Set7(byte1_4, 0);


            #endregion

            #region byte2


            byte2_1 = BitManip.Set0(byte2_1, 0);
            byte2_1 = BitManip.Set1(byte2_1, 0);
            byte2_1 = BitManip.Set2(byte2_1, 0);
            byte2_1 = BitManip.Set3(byte2_1, 0);
            byte2_1 = BitManip.Set4(byte2_1, 0);
            byte2_1 = BitManip.Set5(byte2_1, 0);
            byte2_1 = BitManip.Set6(byte2_1, 0);
            byte2_1 = BitManip.Set7(byte2_1, 0);

            byte2_2 = BitManip.Set0(byte2_2, 0);
            byte2_2 = BitManip.Set1(byte2_2, 0);
            byte2_2 = BitManip.Set2(byte2_2, 0);
            byte2_2 = BitManip.Set3(byte2_2, 0);
            byte2_2 = BitManip.Set4(byte2_2, 0);
            byte2_2 = BitManip.Set5(byte2_2, 0);
            byte2_2 = BitManip.Set6(byte2_2, 0);
            byte2_2 = BitManip.Set7(byte2_2, 0);

            byte2_3 = BitManip.Set0(byte2_3, 0);
            byte2_3 = BitManip.Set1(byte2_3, 0);
            byte2_3 = BitManip.Set2(byte2_3, 0);
            byte2_3 = BitManip.Set3(byte2_3, 0);
            byte2_3 = BitManip.Set4(byte2_3, 0);
            byte2_3 = BitManip.Set5(byte2_3, 0);
            byte2_3 = BitManip.Set6(byte2_3, 0);
            byte2_3 = BitManip.Set7(byte2_3, 0);

            byte2_4 = BitManip.Set0(byte2_4, 0);
            byte2_4 = BitManip.Set1(byte2_4, 0);
            byte2_4 = BitManip.Set2(byte2_4, 0);
            byte2_4 = BitManip.Set3(byte2_4, 0);
            byte2_4 = BitManip.Set4(byte2_4, 0);
            byte2_4 = BitManip.Set5(byte2_4, 0);
            byte2_4 = BitManip.Set6(byte2_4, 0);
            byte2_4 = BitManip.Set7(byte2_4, 0);
            #endregion
            #region notRelevant2

            buffer.WriteByte(byte1_1); //byte1
            buffer.WriteByte(byte1_2); //byte2
            buffer.WriteByte(byte1_3); //byte3
            buffer.WriteByte(byte1_4); //byte4

            buffer.WriteByte(byte2_1); //byte1
            buffer.WriteByte(byte2_2); //byte2
            buffer.WriteByte(byte2_3); //byte3
            buffer.WriteByte(byte2_4); //byte4
            buffer.WriteByte(0x01);
            buffer.WriteUInt16(0x2a);
            buffer.WriteByte(0x46);
            buffer.WriteByte(0x03);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0);
            buffer.WriteByte(0); //maybe start state info
            buffer.WriteByte(0);
            buffer.WriteByte(0);

            b.AddRange(buffer.GetData());

            #endregion

            //END


            var packet = new TestPacket((byte)GamePacketType.SYNC, 122, new TestPacketInfo(b.ToArray()));
            connection.Send(packet);
        }
    }
}
