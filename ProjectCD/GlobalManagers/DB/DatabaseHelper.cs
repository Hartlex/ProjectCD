namespace ProjectCD.GlobalManagers.DB
{
    internal static class DatabaseHelper
    {
        internal static string CharacterTableColumns()
        {
            return "(" +
                      "UserID," +
                      "charSlot," +
                      "ClassCode," +
                      "CharName," +
                      "HeightCode," +
                      "FaceCode," +
                      "HairCode," +
                      "Level," +
                      "Strength," +
                      "Vitality," +
                      "Agility," +
                      "Intelligence," +
                      "Spirit," +
                      "SkillStat1," +
                      "SkillStat2," +
                      "UserPoint," +
                      "Experience," +
                      "MaxHp," +
                      "Hp," +
                      "MaxMp," +
                      "Mp," +
                      "Money," +
                      "RemainStat," +
                      "RemainSkill," +
                      "SelectedStyle" +
                      "PkState," +
                      "CharState," +
                      "StateTime," +
                      "Region," +
                      "LocationX," +
                      "LocationY," +
                      "LocationZ," +
                      "TitleID," +
                      "TitleTime," +
                      "InvisOpt," +
                      "InventoryLock," +
                      "InventoryItem," +
                      "TmpInventoryItem," +
                      "EquipItem," +
                      "Skill," +
                      "QuickSkill," +
                      "Style," +
                      "Quest," +
                      "Mission," +
                      "PlayLimitedTime," +
                      "PVPPoint," +
                      "PVPScore," +
                      "PVPGrade," +
                      "PVPDraw," +
                      "PVPSeries," +
                      "PVPKill," +
                      "PVPDeath," +
                      "PVPMaxKill," +
                      "PVPMaxDeath," +
                      "GuildID," +
                      "GuildPosition," +
                      "GuildUserPoint," +
                      "GuildNickName," +
                      "CreationDate," +
                      "ModifiedDate," +
                      "LastDate," +
                      "DeleteCheck)";
        }

        internal static string NewCharacterTableColumns()
        {
            return "(" +
                   "UserID," +
                   "charSlot," +
                   "ClassCode," +
                   "CharName," +
                   "HeightCode," +
                   "FaceCode," +
                   "HairCode," +
                   "Level," +
                   "Strength," +
                   "Vitality," +
                   "Agility," +
                   "Intelligence," +
                   "Spirit," +
                   "SkillStat1," +
                   "SkillStat2," +
                   "UserPoint," +
                   "Experience," +
                   "MaxHp," +
                   "Hp," +
                   "MaxMp," +
                   "Mp," +
                   "Money," +
                   "RemainStat," +
                   "RemainSkill," +
                   "SelectedStyle," +
                   "Region," +
                   "LocationX," +
                   "LocationY," +
                   "LocationZ," +
                   "InventoryItem," +
                   "TmpInventoryItem," +
                   "EquipItem," +
                   "Skill," +
                   "QuickSkill," +
                   "Style," +
                   "Quest," +
                   "Mission," +
                   "CreationDate," +
                   "ModifiedDate," +
                   "LastDate)";
        }
    }
}
