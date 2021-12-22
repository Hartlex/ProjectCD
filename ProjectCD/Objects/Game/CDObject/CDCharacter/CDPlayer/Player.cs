using System.Data.SqlClient;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots;
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
        private readonly PlayerPVPInfo _pvp;
        private readonly PlayerGuildInfo _guild;
        private readonly PlayerStyleManager _styleManager;
        private readonly CharType _charType;
        private readonly User _user;
        public Player(ref SqlDataReader reader,User user) : base(unchecked((uint)reader.GetInt32(1)))
        {
            _user = user;
            _charType = (CharType) reader.GetByte(3);
            SetObjectType(ObjectType.PLAYER_OBJECT);
            _general = new (ref reader);
            _pvp = new(ref reader);
            _guild = new(ref reader);
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
                GetMoney(),
                _styleManager.GetSelectedStyleCode(),
                (ushort)GetMaxHP(),
                (ushort)GetMaxHP(),
                (ushort)GetMaxMP(),
                (ushort)GetMaxMP(),
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
                (ushort)GetMaxSD()
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

        public string GetName()
        {
            return _general.Name;
        }
    }
}
