using System.Data;
using System.Data.SqlClient;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.GlobalManagers.Config;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using ProjectCD.Objects.NetObjects;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Auth.Client;
using SunStructs.PacketInfos.Game.Object.Character.Player;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.Character.Player;

namespace ProjectCD.GlobalManagers.DB
{
    public class Database : Singleton<Database>
    {
        private string _connectionString;
        public bool Initialize()
        {
            GetConfig();
            return TestConnection();
        }
        private bool TestConnection()
        {
            using var connection = new SqlConnection(_connectionString);
            try
            {
                connection.Open();
                Logger.Instance.Log("Database Connection established!",LogType.SUCCESS);
                return true;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return false;
            }
        }
        private void GetConfig()
        {
            _connectionString =ConfigManager.Instance.GetDbConfig().GetConnectionString();
        }
        public bool AddUser(string username, string password,string email, out int userId)
        {
            userId = -1;
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand("INSERT INTO [dbo].[User] " +
                                     "([Username],[Password],[Email],[RegistrationDate]) " +
                                     "VALUES " +
                                     "(@username,@password,@email,@regDate) " +
                                     "SELECT CAST(scope_identity() AS int);",
                connection
            );
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@regDate", DateTime.Now);

            var scalar = cmd.ExecuteScalar();
            if (scalar == null) return false;
            userId = (int)scalar;
            return true;
        }
        public AuthResultType CheckLoginInfo(AskLoginInfo loginInformation, out uint userId)
        {
            userId = 0;
            var username = loginInformation.UserName;
            var password = loginInformation.Password;
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            var cmd = new SqlCommand(
                "SELECT [Id] " +
                "FROM [dbo].[User]" +
                "WHERE [Username] = '" + username + "'" +
                "AND [Password] = '" + password + "'",
                connection
            );
            var scalar = cmd.ExecuteScalar();
            if (scalar == null) return AuthResultType.AUTH_RESULT_INVALID_PASSWORD;
            userId = unchecked ((uint)(int) scalar);
            return AuthResultType.AUTH_RESULT_OK;
        }
        public bool IsCharNameFree(string name)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Character] WHERE [CharName]='" + name + "' AND" +
                                                "[DeleteCheck] ='0'",
                    connection);
                var reader = cmd.ExecuteReader();
                return !reader.HasRows;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e.ToString(), LogType.ERROR);
                return false;
            }
        }
        public bool TryGetCharSlot(uint userId,out int slot)
        {
            slot =-1;
            try
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                var filledSlots = new List<byte>();
                connection.Open();
                var cmd = new SqlCommand("SELECT [CharSlot] " +
                                         "FROM [dbo].[Character] " +
                                         "WHERE [UserID] = '" + userId + "' AND" +
                                         "[DeleteCheck] ='0'",
                    connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    filledSlots.Add(reader.GetByte(0));
                }
                reader.Close();
                byte maxSlots=0;
                cmd = new SqlCommand("SELECT [CharacterSlots] " +
                                     "FROM [dbo].[User] " +
                                     "WHERE [Id] ='" + userId + "'", connection);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    maxSlots = reader.GetByte(0);
                }

                if (!(filledSlots.Count < maxSlots)) return false;
                    
                for (byte i = 0; i < maxSlots; i++)
                {
                    var slotFree = true;
                    foreach (var filledSlot in filledSlots)
                    {
                        if (filledSlot == i)
                        {
                            slotFree = false;
                        }
                    }

                    if (slotFree)
                    {
                        slot = i;
                        return true;
                    }
                        
                }
                return false;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return false;
            }
        }
        public ClientCharacterPart[] GetCharactersForCharSelect(uint userId)
        {
            //return new ClientCharacterPart[]
            //{
            //    new ClientCharacterPart(0, 16, "TestChar1", 1, 1, 1, 1, 100, 10001, 0, 0, 0, 0, new byte[1], 0,
            //        new byte[32], new byte[3], new byte[4])
            //};
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Character] WHERE [UserID] ='" + userId + "' AND " +
                                                "[DeleteCheck] ='0'",
                    connection);
                var reader = cmd.ExecuteReader();
                var result = new List<ClientCharacterPart>();
                while (reader.Read())
                {
                    var clientChar = new ClientCharacterPart(ref reader);
                    result.Add(clientChar);
                }

                return result.ToArray();
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e);
                return null;
            }
        }
        public bool GetCharacterForCharSelect(uint userId, uint charId, out ClientCharacterPart characterPart)
        {
            characterPart = null;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[Character] " +
                                                "WHERE [UserID] ='" + userId + "' AND " +
                                                "[CharID] = '"+charId+"' AND " +
                                                "[DeleteCheck] ='0'",
                    connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                     characterPart = new ClientCharacterPart(ref reader);
                     return true;
                }

                return false;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e);
                return false;
            }
        }
        private bool GetInitCharInfo(byte classCode,out InitCharInfo info)
        {
            info = null;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [dbo].[CharacterSet] WHERE [ClassCode]='" + classCode + "'",
                    connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    info = new InitCharInfo(ref reader);
                    return true;
                }

                return false;

            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e.ToString(), LogType.ERROR);
                return false;
            }
        }
        private bool InsertNewChar(uint userId,byte slot, string name, BaseCharacterRenderInfo renderInfo,
            InitCharInfo initCharInfo,out uint charId)
        {
            charId = uint.MaxValue;
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO [dbo].[Character] " +
                                                DatabaseHelper.NewCharacterTableColumns()+" " + 
                                                "VALUES (" +
                                                "@userID," +
                                                "@charSlot," +
                                                "@ClassCode," +
                                                "@CharName," +
                                                "@HeightCode," +
                                                "@FaceCode," +
                                                "@HairCode," +
                                                "@Level," +
                                                "@Strength," +
                                                "@Vitality," +
                                                "@Dexterity," +
                                                "@Intelligence," +
                                                "@Spirit," +
                                                "@SkillStat1," +
                                                "@SkillStat2," +
                                                "@UserPoint," +
                                                "@Experience," +
                                                "@MaxHp," +
                                                "@Hp," +
                                                "@MaxMp," +
                                                "@Mp," +
                                                "@Money," +
                                                "@RemainStat," +
                                                "@RemainSkill," +
                                                "@SelectedStyle," +
                                                "@Region," +
                                                "@LocationX," +
                                                "@LocationY," +
                                                "@LocationZ," +
                                                "@InventoryItem," +
                                                "@TmpInventoryItem," +
                                                "@EquipItem," +
                                                "@Skill," +
                                                "@QuickSkill," +
                                                "@Style," +
                                                "@Quest," +
                                                "@Mission," +
                                                "@CreationDate," +
                                                "@ModifiedDate," +
                                                "@LastDate) " +
                                                "select scope_identity()",
                    connection);
                    cmd.Parameters.Add("@userID", SqlDbType.Int).Value = userId;
                    cmd.Parameters.Add("@charSlot", SqlDbType.TinyInt).Value = slot;
                    cmd.Parameters.Add("@ClassCode", SqlDbType.Int).Value = initCharInfo.ClassCode;
                    cmd.Parameters.Add("@CharName", SqlDbType.VarChar).Value = name;
                    
                    cmd.Parameters.Add("@HeightCode", SqlDbType.TinyInt).Value =renderInfo.HeightCode;
                    cmd.Parameters.Add("@FaceCode", SqlDbType.TinyInt).Value = renderInfo.FaceCode;
                    cmd.Parameters.Add("@HairCode", SqlDbType.TinyInt).Value = renderInfo.HairCode;
                    
                    cmd.Parameters.Add("@Level", SqlDbType.SmallInt).Value = initCharInfo.Level;
                    cmd.Parameters.Add("@Strength", SqlDbType.SmallInt).Value = initCharInfo.Strength;
                    cmd.Parameters.Add("@Dexterity", SqlDbType.SmallInt).Value = initCharInfo.Dexterity;
                    cmd.Parameters.Add("@Vitality", SqlDbType.SmallInt).Value = initCharInfo.Vitality;
                    cmd.Parameters.Add("@Intelligence", SqlDbType.SmallInt).Value = initCharInfo.Intelligence;
                    cmd.Parameters.Add("@Spirit", SqlDbType.SmallInt).Value = initCharInfo.Spirit;
                    cmd.Parameters.Add("@SkillStat1", SqlDbType.SmallInt).Value = initCharInfo.SkillStat1;
                    cmd.Parameters.Add("@SkillStat2", SqlDbType.SmallInt).Value = initCharInfo.SkillStat2;
                    
                    cmd.Parameters.Add("@UserPoint", SqlDbType.Int).Value = initCharInfo.UserPoint;
                    cmd.Parameters.Add("@Experience", SqlDbType.BigInt).Value = initCharInfo.Exp;
                    
                    cmd.Parameters.Add("@MaxHp", SqlDbType.BigInt).Value = initCharInfo.MaxHp;
                    cmd.Parameters.Add("@Hp", SqlDbType.BigInt).Value = initCharInfo.MaxHp;
                    cmd.Parameters.Add("@MaxMp", SqlDbType.BigInt).Value = initCharInfo.MaxMp;
                    cmd.Parameters.Add("@Mp", SqlDbType.BigInt).Value = initCharInfo.MaxMp;
                    cmd.Parameters.Add("@Money", SqlDbType.BigInt).Value = initCharInfo.Money;
                    cmd.Parameters.Add("@RemainStat", SqlDbType.Int).Value = initCharInfo.RemainStat;
                    cmd.Parameters.Add("@RemainSkill", SqlDbType.Int).Value = initCharInfo.RemainSkill;
                    cmd.Parameters.Add("@SelectedStyle", SqlDbType.Int).Value = initCharInfo.SelectedStyle;
                    
                    
                    cmd.Parameters.Add("@Region", SqlDbType.Int).Value = initCharInfo.Region;
                    cmd.Parameters.Add("@LocationX", SqlDbType.Real).Value = initCharInfo.LocationX;
                    cmd.Parameters.Add("@LocationY", SqlDbType.Real).Value = initCharInfo.LocationY;
                    cmd.Parameters.Add("@LocationZ", SqlDbType.Real).Value = initCharInfo.LocationZ;
                    
                    cmd.Parameters.Add("@InventoryItem", SqlDbType.VarBinary).Value = initCharInfo.InventoryItem;
                    cmd.Parameters.Add("@TmpInventoryItem", SqlDbType.VarBinary).Value = initCharInfo.TmpInventoryItem;
                    cmd.Parameters.Add("@EquipItem", SqlDbType.VarBinary).Value = initCharInfo.Equipment;
                    cmd.Parameters.Add("@Skill", SqlDbType.VarBinary).Value = initCharInfo.Skill;
                    cmd.Parameters.Add("@QuickSkill", SqlDbType.VarBinary).Value = initCharInfo.Quick;
                    cmd.Parameters.Add("@Style", SqlDbType.VarBinary).Value = initCharInfo.Style;
                    cmd.Parameters.Add("@Quest", SqlDbType.VarBinary).Value = initCharInfo.Quest;
                    cmd.Parameters.Add("@Mission", SqlDbType.VarBinary).Value = initCharInfo.Mission;

                    cmd.Parameters.Add("@CreationDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@ModifiedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                    cmd.Parameters.Add("@LastDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
                    charId = Convert.ToUInt32(cmd.ExecuteScalar());
                    return true;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e.ToString(), LogType.ERROR);
                return false;
            }
        }
        public CharCreateResult CreateCharacter(uint userId, byte classCode, string charName, BaseCharacterRenderInfo renderInfo,
            out ClientCharacterPart characterPart)
        {
            characterPart = null;
            if (!IsCharNameFree(charName)) return CharCreateResult.RC_CHAR_CREATE_DBCHAR_ALREADY_CREATED;
            if (!TryGetCharSlot(userId, out int slot)) return CharCreateResult.RC_CHAR_CREATE_SLOT_FULL;
            if (!GetInitCharInfo(classCode, out var initCharInfo)) return CharCreateResult.RC_CHAR_CREATE_TRANSACTION_ERROR;
            if (!InsertNewChar(userId, (byte) slot, charName, renderInfo, initCharInfo, out var charId))
                return CharCreateResult.RC_CHAR_CREATE_TRANSACTION_ERROR;
            return GetCharacterForCharSelect(userId, charId, out characterPart)
                ? CharCreateResult.RC_CHAR_CREATE_SUCCESS
                : CharCreateResult.RC_CHAR_CREATE_TRANSACTION_ERROR;

        }
        public CharDestroyResult DeleteCharacter(uint userId, byte slot)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var cmd = new SqlCommand("UPDATE [dbo].[Character] " +
                                         "SET [DeleteCheck] = 1 " +
                                         "WHERE [UserID]='" + userId + "' AND " +
                                         "[charSlot] = '" + slot + "'",
                    connection);
                var rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected != 0) return CharDestroyResult.RC_CHAR_DESTROY_SUCCESS;
                return CharDestroyResult.RC_CHAR_DESTROY_FAILED;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e);
                return CharDestroyResult.RC_CHAR_DESTROY_FAILED;
            }
        }
        public Player CreatePlayerFromDB(User user, byte charSlot)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var cmd = new SqlCommand("SELECT * FROM [dbo].[Character] " +
                                         "WHERE [UserID] ='" + user.UserID + "' AND " +
                                         "[charSlot] = '" + charSlot + "' AND " +
                                         "[DeleteCheck] = '0'"
                    , connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    return new Player(ref reader,user);
                }

                return null;
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e);
                return null;
            }

        }
        public void UpdatePlayerPosition(uint userId, uint charId, SunVector position)
        {
            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();
                var cmd = new SqlCommand("UPDATE [dbo].[Character] SET " +
                                         "[LocationX] = '" + (int)position.GetX() + "'," +
                                         "[LocationY] = '" + (int)position.GetY() + "'," +
                                         "[LocationZ] = '" + (int)position.GetZ() + "'" +
                                         "WHERE [UserID] = '" + userId + "' AND" +
                                         "[charID] = +'" + charId + "'",
                    connection);
                var rows = cmd.ExecuteNonQuery();
                if(rows ==0) Logger.Instance.Log("Failed to Update Player position no Char found with ["+userId +",["+charId+"]");
            }
            catch (SqlException e)
            {
                Logger.Instance.Log(e);
            }
        }
        //public bool UpdateFullCharacter(Player player)
        //{
        //    //player.Inventory.DeserializeInventoryToByteStream();
        //    try
        //    {
        //        using SqlConnection conn = new SqlConnection(_connectionString);
        //        conn.Open();
        //        SqlCommand cmd = new SqlCommand(
        //            "UPDATE dbo.[Character] SET " +
        //            "[Level] = @Level," +
        //            "[Strength] = @Strength," +
        //            "[Agility]= @Agility," +
        //            "[Vitality]= @Vitality," +
        //            "[Intelligence] = @Intelligence," +
        //            "[Spirit] = @Spirit," +
        //            "[SkillStat1] = @SkillStat1," +
        //            "[SkillStat2] = @SkillStat2," +
        //            "[UserPoint] =@UserPoint," +
        //            "[Experience] =@Experience," +
        //            "[MaxHp] = @MaxHp," +
        //            "[Hp] = @Hp," +
        //            "[MaxMp]=@MaxMp," +
        //            "[Mp]=@Mp," +
        //            "[Money] = @Money," +
        //            "[RemainStat] = @RemainStat," +
        //            "[RemainSkill] = @RemainSkill," +
        //            "[PkState] =@PkState," +
        //            "[CharState] =@CharState," +
        //            "[StateTime] =@StateTime," +
        //            "[Region] =@Region," +
        //            "[LocationX] =@LocationX," +
        //            "[LocationY] = @LocationY," +
        //            "[LocationZ] = @LocationZ," +
        //            "[TitleID] = @TitleID," +
        //            "[TitleTime] =@TitleTime," +
        //            "[InvisOpt] =@InvisOpt," +
        //            "[InventoryLock] = @InventoryLock," +
        //            "[InventoryItem] = @InventoryItem," +
        //            "[TmpInventoryItem] =@TmpInventoryItem," +
        //            "[EquipItem] = @EquipItem," +
        //            "[Skill] = @Skill," +
        //            "[QuickSkill] = @QuickSkill," +
        //            "[Style] = @Style," +
        //            "[Quest] = @Quest," +
        //            "[Mission] =@Mission," +
        //            "[PlayLimitedTime] =@PlayLimitedTime," +
        //            "[PVPPoint] = @PVPPoint," +
        //            "[PVPScore]=@PVPScore," +
        //            "[PVPGrade] =@PVPGrade," +
        //            "[PVPDraw] =@PVPDraw," +
        //            "[PVPSeries] =@PVPSeries," +
        //            "[PVPKill] =@PVPKill," +
        //            "[PVPDeath] =@PVPDeath," +
        //            "[PVPMaxKill] =@PVPMaxKill," +
        //            "[PVPMaxDeath] =@PVPMaxDeath," +
        //            "[GuildID] = @GuildId," +
        //            "[GuildPosition] =@GuildPosition," +
        //            "[GuildUserPoint] =@GuildUserPoint," +
        //            "[GuildNickName]=@GuildNickName," +
        //            //"[CreationDate]=@CreationDate," +
        //            "[ModifiedDate]=@ModifiedDate," +
        //            //"[LastDate]=@LastDate," +
        //            "[DeleteCheck] =@DeleteCheck" +
        //            " WHERE [charID]=@charID",conn
        //        );
        //        #region params

        //        cmd.Parameters.Add("@charId", SqlDbType.Int).Value = player.BaseInfo.CharacterId;
        //        cmd.Parameters.Add("@userID", SqlDbType.Int).Value = player.BaseInfo.UserId;
        //        cmd.Parameters.Add("@charSlot", SqlDbType.Int).Value = player.BaseInfo.CharSlot;
        //        cmd.Parameters.Add("@ClassCode", SqlDbType.Int).Value = player.BaseInfo.ClassCode;
        //        cmd.Parameters.Add("@CharName", SqlDbType.VarChar).Value = player.BaseInfo.GeneralInfo.Name;
        //        cmd.Parameters.Add("@HeightCode", SqlDbType.Int).Value = player.BaseInfo.BaseRenderInfo.HeightCode;
        //        cmd.Parameters.Add("@FaceCode", SqlDbType.Int).Value = player.BaseInfo.BaseRenderInfo.FaceCode;
        //        cmd.Parameters.Add("@HairCode", SqlDbType.Int).Value = player.BaseInfo.BaseRenderInfo.HairCode;
        //        cmd.Parameters.Add("@Level", SqlDbType.SmallInt).Value = player.BaseInfo.GeneralInfo.Level;
        //        cmd.Parameters.Add("@Strength", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.Strength;
        //        cmd.Parameters.Add("@Agility", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.Agility;

        //        cmd.Parameters.Add("@Vitality", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.Vitality;
        //        cmd.Parameters.Add("@Intelligence", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.Intelligence;
        //        cmd.Parameters.Add("@Spirit", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.Spirit;
        //        cmd.Parameters.Add("@SkillStat1", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.SkillStat1;
        //        cmd.Parameters.Add("@SkillStat2", SqlDbType.SmallInt).Value = player.BaseInfo.BaseStats.SkillStat2;
        //        cmd.Parameters.Add("@UserPoint", SqlDbType.Int).Value = player.BaseInfo.UpPoints;
        //        cmd.Parameters.Add("@Experience", SqlDbType.BigInt).Value = player.BaseInfo.GeneralInfo.Experience;
        //        cmd.Parameters.Add("@MaxHp", SqlDbType.Real).Value = player.BaseInfo.GeneralInfo.MaxHP;
        //        cmd.Parameters.Add("@Hp", SqlDbType.Real).Value = player.BaseInfo.GeneralInfo.HP;
        //        cmd.Parameters.Add("@MaxMp", SqlDbType.Real).Value = player.BaseInfo.GeneralInfo.MaxMP;

        //        cmd.Parameters.Add("@Mp", SqlDbType.Real).Value = player.BaseInfo.GeneralInfo.MP;
        //        cmd.Parameters.Add("@Money", SqlDbType.BigInt).Value = player.BaseInfo.Money;
        //        cmd.Parameters.Add("@RemainStat", SqlDbType.Int).Value = player.BaseInfo.RemainStat;
        //        cmd.Parameters.Add("@RemainSkill", SqlDbType.Int).Value = player.BaseInfo.RemainSkill;
        //        cmd.Parameters.Add("@PkState", SqlDbType.TinyInt).Value = player.BaseInfo.PkState;
        //        cmd.Parameters.Add("@CharState", SqlDbType.TinyInt).Value = player.BaseInfo.CharState;
        //        cmd.Parameters.Add("@StateTime", SqlDbType.TinyInt).Value = player.BaseInfo.StateTime;
        //        cmd.Parameters.Add("@Region", SqlDbType.Int).Value = player.BaseInfo.Location.Region;
        //        cmd.Parameters.Add("@LocationX", SqlDbType.SmallInt).Value = (short)player.BaseInfo.Location.Position.GetX();
        //        cmd.Parameters.Add("@LocationY", SqlDbType.SmallInt).Value = (short)player.BaseInfo.Location.Position.GetY();

        //        cmd.Parameters.Add("@LocationZ", SqlDbType.SmallInt).Value = (short)player.BaseInfo.Location.Position.GetZ();
        //        cmd.Parameters.Add("@TitleID", SqlDbType.Int).Value = player.BaseInfo.TitleId;
        //        cmd.Parameters.Add("@TitleTime", SqlDbType.BigInt).Value = player.BaseInfo.TitleTime;
        //        cmd.Parameters.Add("@InvisOpt", SqlDbType.TinyInt).Value = player.BaseInfo.InvisibleFlag;
        //        cmd.Parameters.Add("@InventoryLock", SqlDbType.TinyInt).Value = player.BaseInfo.InvLock;
        //        cmd.Parameters.Add("@InventoryItem", SqlDbType.VarBinary).Value = player.GetFullInventoryBytes();
        //        cmd.Parameters.Add("@TmpInventoryItem", SqlDbType.VarBinary).Value = player.GetTmpInventoryBytes();
        //        cmd.Parameters.Add("@EquipItem", SqlDbType.VarBinary).Value = player.GetEquipmentBytes();
        //        cmd.Parameters.Add("@Skill", SqlDbType.VarBinary).Value = player.GetSkillBytes();
        //        cmd.Parameters.Add("@QuickSkill", SqlDbType.VarBinary).Value = player.GetQuickBytes();
        //        cmd.Parameters.Add("@Style", SqlDbType.VarBinary).Value = player.GetStyleBytes();

        //        cmd.Parameters.Add("@Quest", SqlDbType.VarBinary).Value = player.GetQuestBytes();
        //        cmd.Parameters.Add("@Mission", SqlDbType.VarBinary).Value = player.GetMissionBytes();
        //        cmd.Parameters.Add("@PlayLimitedTime", SqlDbType.BigInt).Value = player.BaseInfo.PlayerLimitedTime;
        //        cmd.Parameters.Add("@PVPPoint", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPPoint;
        //        cmd.Parameters.Add("@PVPScore", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPScore;
        //        cmd.Parameters.Add("@PVPGrade", SqlDbType.TinyInt).Value = player.BaseInfo.PVPInfo.PVPGrade;
        //        cmd.Parameters.Add("@PVPDraw", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPTotalDraw;
        //        cmd.Parameters.Add("@PVPSeries", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPMaxSeries;
        //        cmd.Parameters.Add("@PVPKill", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPTotalKill;
        //        cmd.Parameters.Add("@PVPDeath", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPTotalDeaths;

        //        cmd.Parameters.Add("@PVPMaxKill", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPMaxKill;
        //        cmd.Parameters.Add("@PVPMaxDeath", SqlDbType.Int).Value = player.BaseInfo.PVPInfo.PVPMaxDie;
        //        cmd.Parameters.Add("@GuildID", SqlDbType.Int).Value = player.BaseInfo.GuildInfo.GuildId;
        //        cmd.Parameters.Add("@GuildPosition", SqlDbType.TinyInt).Value = player.BaseInfo.GuildInfo.GuildPosition;
        //        cmd.Parameters.Add("@GuildUserPoint", SqlDbType.Int).Value = 0;
        //        cmd.Parameters.Add("@GuildNickName", SqlDbType.VarChar).Value = "";
        //        //cmd.Parameters.Add("@CreatonDate", SqlDbType.SmallDateTime).Value = player.CreationDate;
        //        cmd.Parameters.Add("@ModifiedDate", SqlDbType.SmallDateTime).Value = DateTime.Now;
        //        //cmd.Parameters.Add("@LastDate", SqlDbType.SmallDateTime).Value = player.LastLoginDate;
        //        cmd.Parameters.Add("@DeleteCheck", SqlDbType.TinyInt).Value = 0;
        //        #endregion

        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {

        //        }

        //        return true;
        //    }
        //    catch (SqlException e)
        //    {
        //        Logger.Instance.Log(e.ToString(),LogType.ERROR);
        //    }

        //    return false;
        //}

        //public Warehouse GetWarehouse(Player player)
        //{
        //    try
        //    {
        //        using var connection = new SqlConnection(_connectionString);
        //        connection.Open();
        //        var cmd = new SqlCommand("SELECT * FROM [dbo].[Storage] " +
        //                                 "WHERE [UserID] ='" + player.GetObjectKey() + "'"
        //            , connection);
        //        var reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var b = new byte[8];
        //            var money = (ulong)reader.GetInt64(2);
        //            var bytes = (byte[])reader[3];
        //            return new Warehouse(money, bytes, player);
        //        }

        //        return null;
        //    }
        //    catch (SqlException e)
        //    {
        //        Logger.Instance.Log(e);
        //        return null;
        //    }
        //}

        //public bool SaveWarehouse(Warehouse warehouse)
        //{
        //    try
        //    {
        //        using var connection = new SqlConnection(_connectionString);
        //        connection.Open();
        //        var cmd = new SqlCommand("UPDATE [dbo].[Storage] SET " +
        //                                 "[Money] = @Money," +
        //                                 "[Items] = @Items " +
        //                                 "WHERE [UserID] ='"+warehouse.Owner.GetObjectKey()+"'",
        //            connection);
        //        cmd.Parameters.Add("@Money", SqlDbType.BigInt).Value = (long) warehouse.GetMoney();
        //        cmd.Parameters.Add("@Items", SqlDbType.VarBinary).Value = warehouse.Serialize();
        //        var reader = cmd.ExecuteReader();
        //        if (reader.RecordsAffected > 0)
        //            return true;

        //        return false;
        //    }
        //    catch (SqlException e)
        //    {
        //        Logger.Instance.Log(e);
        //        return false;
        //    }
        //}
    }
    
    
}
