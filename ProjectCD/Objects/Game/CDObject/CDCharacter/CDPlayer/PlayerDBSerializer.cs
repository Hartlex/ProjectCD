using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    public partial class Player
    {
        public void AddDBParams(ref SqlCommand cmd)
        {
            cmd.Parameters.Add("@charId", SqlDbType.Int).Value = _general.CharacterId;
            cmd.Parameters.Add("@userID", SqlDbType.Int).Value = _user.UserID;
            cmd.Parameters.Add("@charSlot", SqlDbType.Int).Value = _general.CharSlot;
            cmd.Parameters.Add("@ClassCode", SqlDbType.Int).Value = _general.ClassCode;
            cmd.Parameters.Add("@CharName", SqlDbType.VarChar).Value = _general.Name;
            cmd.Parameters.Add("@HeightCode", SqlDbType.Int).Value = _general.HeightCode;
            cmd.Parameters.Add("@FaceCode", SqlDbType.Int).Value = _general.FaceCode;
            cmd.Parameters.Add("@HairCode", SqlDbType.Int).Value = _general.HairCode;
            cmd.Parameters.Add("@Level", SqlDbType.SmallInt).Value = _general.Level;
            cmd.Parameters.Add("@Strength", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_STR);
            cmd.Parameters.Add("@Agility", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_DEX);

            cmd.Parameters.Add("@Vitality", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_VIT);
            cmd.Parameters.Add("@Intelligence", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_INT);
            cmd.Parameters.Add("@Spirit", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_SPR);
            cmd.Parameters.Add("@SkillStat1", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_EXPERTY1);
            cmd.Parameters.Add("@SkillStat2", SqlDbType.SmallInt).Value = _attributes.GetValue16(AttrType.ATTR_EXPERTY2);
            cmd.Parameters.Add("@UserPoint", SqlDbType.Int).Value = _guild.UpPoints;
            cmd.Parameters.Add("@Experience", SqlDbType.BigInt).Value = _general.Experience;
            cmd.Parameters.Add("@MaxHp", SqlDbType.Real).Value = _attributes.GetValue16(AttrType.ATTR_MAX_HP);
            cmd.Parameters.Add("@Hp", SqlDbType.Real).Value = GetHP();
            cmd.Parameters.Add("@MaxMp", SqlDbType.Real).Value = _attributes.GetValue16(AttrType.ATTR_MAX_MP);

            cmd.Parameters.Add("@Mp", SqlDbType.Real).Value = GetMP();
            cmd.Parameters.Add("@Money", SqlDbType.BigInt).Value = GetMoney();
            cmd.Parameters.Add("@RemainStat", SqlDbType.Int).Value = GetStatPoints();
            cmd.Parameters.Add("@RemainSkill", SqlDbType.Int).Value = GetSkillPoints();
            cmd.Parameters.Add("@PkState", SqlDbType.TinyInt).Value = 0;
            cmd.Parameters.Add("@CharState", SqlDbType.TinyInt).Value = 0;
            cmd.Parameters.Add("@StateTime", SqlDbType.TinyInt).Value = 0;
            cmd.Parameters.Add("@Region", SqlDbType.Int).Value = GetCurrentMapCode();
            cmd.Parameters.Add("@LocationX", SqlDbType.SmallInt).Value = (short) GetPos().GetX();
            cmd.Parameters.Add("@LocationY", SqlDbType.SmallInt).Value = (short) GetPos().GetY();

            cmd.Parameters.Add("@LocationZ", SqlDbType.SmallInt).Value = (short)GetPos().GetZ();
            cmd.Parameters.Add("@TitleID", SqlDbType.Int).Value = 0;
            cmd.Parameters.Add("@TitleTime", SqlDbType.BigInt).Value = 0;
            cmd.Parameters.Add("@InvisOpt", SqlDbType.TinyInt).Value = 0;
            cmd.Parameters.Add("@InventoryLock", SqlDbType.TinyInt).Value = 0;
            cmd.Parameters.Add("@InventoryItem", SqlDbType.VarBinary).Value = _inventory.Serialize();
            cmd.Parameters.Add("@TmpInventoryItem", SqlDbType.VarBinary).Value = new byte[1];
            cmd.Parameters.Add("@EquipItem", SqlDbType.VarBinary).Value = _equipment.Serialize();
            cmd.Parameters.Add("@Skill", SqlDbType.VarBinary).Value = _skillContainer.Serialize();
            cmd.Parameters.Add("@QuickSkill", SqlDbType.VarBinary).Value = _quickSlots.Serialize();
            cmd.Parameters.Add("@Style", SqlDbType.VarBinary).Value = new byte[1];

            cmd.Parameters.Add("@Quest", SqlDbType.VarBinary).Value = new byte[1];
            cmd.Parameters.Add("@Mission", SqlDbType.VarBinary).Value = new byte[1];
            cmd.Parameters.Add("@PlayLimitedTime", SqlDbType.BigInt).Value = 0;
            cmd.Parameters.Add("@PVPPoint", SqlDbType.Int).Value = _pvp.PVPPoint;
            cmd.Parameters.Add("@PVPScore", SqlDbType.Int).Value = _pvp.PVPScore;
            cmd.Parameters.Add("@PVPGrade", SqlDbType.TinyInt).Value = _pvp.PVPGrade;
            cmd.Parameters.Add("@PVPDraw", SqlDbType.Int).Value = _pvp.PVPTotalDraw;
            cmd.Parameters.Add("@PVPSeries", SqlDbType.Int).Value = _pvp.PVPMaxSeries;
            cmd.Parameters.Add("@PVPKill", SqlDbType.Int).Value = _pvp.PVPTotalKill;
            cmd.Parameters.Add("@PVPDeath", SqlDbType.Int).Value = _pvp.PVPTotalDeaths;

            cmd.Parameters.Add("@PVPMaxKill", SqlDbType.Int).Value = _pvp.PVPMaxKill;
            cmd.Parameters.Add("@PVPMaxDeath", SqlDbType.Int).Value = _pvp.PVPMaxDeath;
            cmd.Parameters.Add("@GuildID", SqlDbType.Int).Value = _guild.GuildId;
            cmd.Parameters.Add("@GuildPosition", SqlDbType.TinyInt).Value = _guild.GuildPosition;
            cmd.Parameters.Add("@GuildUserPoint", SqlDbType.Int).Value = _guild.UpPoints;
            cmd.Parameters.Add("@GuildNickName", SqlDbType.VarChar).Value = _guild.GuildName;
            //cmd.Parameters.Add("@CreatonDate", SqlDbType.SmallDateTime).Value = player.CreationDate;
            cmd.Parameters.Add("@ModifiedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
            //cmd.Parameters.Add("@LastDate", SqlDbType.SmallDateTime).Value = player.LastLoginDate;
            cmd.Parameters.Add("@DeleteCheck", SqlDbType.TinyInt).Value = 0;
        }
    }
}
