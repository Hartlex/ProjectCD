using System.Data.SqlClient;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.World;
using ProjectCD.Objects.NetObjects;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Object.Character.Player;
using SunStructs.Packets;
using SunStructs.ServerInfos.General;
using ObjectType = SunStructs.Definitions.ObjectType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player : Character
    {
        private readonly PlayerGeneral _general;
        private readonly PlayerStyleManager _styleManager;
        private readonly CharType _charType;
        private readonly User _user;
        public Player(ref SqlDataReader reader,User user)
        {
            _user = user;
            _charType = (CharType) reader.GetByte(3);
            SetObjectType(ObjectType.PLAYER_OBJECT);
            var id = unchecked((uint)reader.GetInt32(1));
            SetID(id);
            _general = new (ref reader);
            _styleManager = new(unchecked((ushort) reader.GetInt32(25)));


            PlayerAttributesInit(ref reader);
            PlayerMovementInit(ref reader);
            PlayerInventoryInit(ref reader);
            
        }

        public void OnDisconnect(Connection connection)
        {
            GetCurrentField()?.LeaveField(this);
        }
        public FullCharInfoZone GetFullCharInfoZone()
        {
            return new FullCharInfoZone(new FullCharacterInfo(
                _general.Experience,
                _general.RemainSkillPoint,
                _general.RemainStatPoint,
                _general.Money,
                _styleManager.GetSelectedStyleCode(),
                (ushort)GetMaxHP(),
                (ushort)GetHP(),
                (ushort)GetMaxMP(),
                (ushort)GetMP(),
                0,
                0,
                0,
                "",
                0,
                0,
                GetSTR(),
                GetVIT(),
                GetDEX(),
                GetINT(),
                GetSPR(),
                GetExpert1(),
                GetExpert2(),
                11,
                new GMStateInfo(
                    0, 0, 0, 0, 0, 0
                ),
                0,
                new InvisFlagInfo(0, 0, 0),
                0,
                GuildDuty.GUILD_DUTY_NONE,
                "",
                ChaosState.CHAOS_STATE_NORMAL,
                new ExtraSlotInfo(_inventoryTabs, 0),
                0,
                0,
                0,
                new SummonedPetInfo(0, 0),
                0,
                0,
                0,
                0,
                (ushort)GetMaxSD(),
                (ushort)GetSD()
            ),_inventory.GetShiftedBytes());
        }

        public CharType GetCharType()
        {
            return _charType;
        }

        public ushort GetLevel()
        {
            return _general.Level;
        }
        public void SendPacket(Packet packet)
        {
            _user.SendPacket(packet);
        }
    }
}
