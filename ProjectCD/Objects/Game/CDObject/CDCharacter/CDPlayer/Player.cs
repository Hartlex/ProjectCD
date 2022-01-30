using System.Data.SqlClient;
using CDShared.Logging;
using ProjectCD.NetworkBase.Connections;
using ProjectCD.Objects.Game.CDObject.CDCharacter.AttributeSystem.AttributeChildren;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots;
using ProjectCD.Objects.Game.World;
using ProjectCD.Objects.NetObjects;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Object.Character.Player;
using SunStructs.PacketInfos.Game.Sync.Server;
using SunStructs.Packets;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General;
using ObjectType = SunStructs.Definitions.ObjectType;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player : Character
    {
        private readonly PlayerGeneral _general;
        private readonly PlayerPVPInfo _pvp;
        private readonly PlayerGuildInfo _guild;
        private readonly CharType _charType;
        private readonly User _user;

        private ulong _nextExp;

        public Player(ref SqlDataReader reader,User user) : base(unchecked((uint)reader.GetInt32(1)))
        {
            base.Initialize();
            _user = user;
            _charType = (CharType) reader.GetByte(3);
            SetObjectType(ObjectType.PLAYER_OBJECT);
            _general = new (ref reader);
            _pvp = new(ref reader);
            _guild = new(ref reader);


            PlayerAttributesInit(ref reader);
            PlayerMovementInit(ref reader);
            PlayerInventoryInit(ref reader);
            PlayerSkillInit(ref reader);
            
            SetNextExp();

            
        }

        public override bool Update(long currentTick)
        {
            if (_doingAction && _actionTimer.IsExpired())
                SetActionDelay(0);
            return base.Update(currentTick);
        }

        public void OnDisconnect(Connection connection)
        {
            LeaveField();
        }

        public bool LeaveField()
        {
           var field = GetCurrentField();
           return field != null && field.LeaveField(this);
        }

        public bool EnterField(Field field,SunVector pos)
        {
            var currentField = GetCurrentField();
            if (currentField != null) LeaveField();
            return field.EnterField(this, pos);
        }
        public FullCharInfoZone GetFullCharInfoZone()
        {
            return new FullCharInfoZone(new FullCharacterInfo(
                _general.Experience,
                GetSkillPoints(),
                GetStatPoints(),
                GetMoney(),
                (ushort) _skillManager.GetCurrentStyleCode(),
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

        public PlayerRenderInfo GetRenderInfo()
        {
            var info =new PlayerRenderInfo()
            {
                IsPlayerRenderInfo = 0,
                PlayerKey = (ushort)GetKey(),
                HP = (ushort) GetHP(),
                MaxHP = (ushort) GetMaxHP(),
                Level = GetLevel(),
                Name = GetName(),
                Position = GetPos(),
                SelectedStyleCode = (ushort) _skillManager.GetCurrentStyleCode(),
                MoveSpeedRatio = (ushort) GetMoveSpeedRatio(),
                AttackSpeedRatio = (ushort) GetAttSpeedRatio(),
            };
            info.SetCharType(GetCharType());
            info.SetFace(_general.FaceCode);
            info.SetHeight(_general.HeightCode);
            info.SetHair(_general.HairCode);
            info.HideHelm(0);
            return info;
        }
        public CharType GetCharType()
        {
            return _charType;
        }

        public override ushort GetLevel()
        {
            return _general.Level;
        }

        public override ushort GetDisplayLevel()
        {
            return GetLevel();
        }

        public void SendPacket(Packet packet)
        {
            _user.SendPacket(packet);
        }

        public void SendPackets(Packet[] packets)
        {
            foreach (var packet in packets)
            {
                SendPacket(packet);
            }
        }

        public string GetName()
        {
            return _general.Name;
        }

        #region Level

        public void SetNextExp() { _nextExp = GetAccumulatedExp((ushort) (GetLevel() + 1)); }
        public ulong GetAccumulatedExp(ushort level) { return ExpInfoDB.Instance.GetRequiredExp(level); }

        #endregion

        public int GetCurrentStyleCode()
        {
            return _skillManager.GetCurrentStyleCode();
        }
    }
}
