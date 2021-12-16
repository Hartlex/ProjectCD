using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Quest
{
    public class QuestInfo
    {
        public ushort QuestCode { get; init; }
        public string QuestName{ get; init; }
        public QuestType QuestType{ get; init; }
        public uint QuestNameCode{ get; init; }
        public ushort QuestLevel{ get; init; }
        public byte QDisplay{ get; init; }
        public ushort ParentQuestCode{ get; init; }
        public byte QuestAcceptType { get; init; }
        public uint ACCode{ get; init; }
        public ACType ACType{ get; init; }
        public uint QuestGroupCode{ get; init; }
        public ushort ContinueQuestCode{ get; init; }
        public uint NPCCodeStart{ get; init; }
        public uint NPCCodeReward{ get; init; }
        public uint NPCRewardMapCode{ get; init; }
        public QuestAcquireConditionInfo AcquireConditionInfo { get; init; }
        public QuestAcquireActionInfo AcquireActionInfo { get; init; }
        public QuestCompleteConditionInfo CompleteConditionInfo { get; init; }
        public QuestCompleteActionInfo CompleteActionInfo { get; init; }

        public QuestInfo(string[] infos)
        {
            var sb = new StringBuffer(infos);
            sb.Skip();
            QuestCode = sb.ReadUshort();
            QuestName = sb.ReadString();
            QuestType = (QuestType)sb.ReadByte();
            QuestNameCode = sb.ReadUint();
            QuestLevel = sb.ReadUshort();
            QDisplay = sb.ReadByte();
            ParentQuestCode = sb.ReadUshort();
            QuestAcceptType = sb.ReadByte();
            ACCode = sb.ReadUint();
            ACType = (ACType)sb.ReadByte();
            sb.Skip();
            QuestGroupCode = sb.ReadUint();
            ContinueQuestCode = sb.ReadUshort();
            NPCCodeStart = sb.ReadUint();
            NPCCodeReward = sb.ReadUint();
            NPCRewardMapCode = sb.ReadUint();

            AcquireConditionInfo = new QuestAcquireConditionInfo(ref sb);
            AcquireActionInfo = new QuestAcquireActionInfo(ref sb);
            CompleteConditionInfo = new QuestCompleteConditionInfo(ref sb);
            CompleteActionInfo = new QuestCompleteActionInfo(ref sb);
        }
    }
    
    public class QuestAcquireConditionInfo
    {
        public byte ACMaxRepeatNum{ get; init; }
        public ushort ACRequireCharLevel { get; init; }
        public ushort ACRequireMaxCharLevel { get; init; }
        public byte ACRequireCharClassBit { get; init; }
        public byte ACRequireChaosState { get; init; }
        public byte ACRequireNPCDialog { get; init; }
        public uint ACRequireMissionCode1 { get; init; }
        public byte ACRequireMissionNum1 { get; init; }
        public uint ACRequireMissionCode2 { get; init; }
        public byte ACRequireMissionNum2 { get; init; }
        public ushort[] ACRequireProgQuestCode { get; init; }//3
        public byte RequireProgOperator { get; init; }
        public ushort[] ACRequireEndQuestCode { get; init; }//3
        public byte[] ACRequireEndQuestNum { get; init; }//3
        public ushort ACReqEndQuestOperator { get; init; }
        public ushort[] ACReqItemCode { get; init; }//3
        public byte[] ACReqItemNum { get; init; }//3
        public ushort[] ACResEndQuestCode { get; init; }
        public byte[] ACResEndQuestNum { get; init; }
        public ushort ACResultEndOperator { get; init; }
        public ushort ACResItemCode { get; init; }
        public byte ACResItemClass { get; init; }
        
        public QuestAcquireConditionInfo(ref StringBuffer sb)
        {
            ACMaxRepeatNum = sb.ReadByte();
            ACRequireCharLevel = sb.ReadUshort();
            ACRequireMaxCharLevel = sb.ReadUshort();
            ACRequireCharClassBit = sb.ReadByte();
            ACRequireChaosState = sb.ReadByte();
            ACRequireNPCDialog = sb.ReadByte();
            ACRequireMissionCode1 = sb.ReadUint();
            ACRequireMissionNum1 = sb.ReadByte();
            ACRequireMissionCode2 = sb.ReadUint();
            ACRequireMissionNum2 = sb.ReadByte();
            
            ACRequireProgQuestCode = new ushort[3];
            for(int i=0;i<3;i++){ACRequireProgQuestCode[i]=sb.ReadUshort(); }
            RequireProgOperator = sb.ReadByte();
            
            ACRequireEndQuestCode = new ushort[3];
            for(int i=0;i<3;i++){ACRequireEndQuestCode[i]=sb.ReadUshort(); }
            ACRequireEndQuestNum = new byte[3];
            for(int i=0;i<3;i++){ACRequireEndQuestNum[i]=sb.ReadByte(); }
            ACReqEndQuestOperator = sb.ReadUshort();
            
            ACReqItemCode = new ushort[3];
            for(int i=0;i<3;i++){ACReqItemCode[i]=sb.ReadUshort(); }
            ACReqItemNum = new byte[3];
            for(int i=0;i<3;i++){ACReqItemNum[i]=sb.ReadByte(); }
            
            ACResEndQuestCode = new ushort[3];
            for(int i=0;i<3;i++){ACResEndQuestCode[i]=sb.ReadUshort(); }
            ACResEndQuestNum = new byte[3];
            for(int i=0;i<3;i++){ACResEndQuestNum[i]=sb.ReadByte(); }

            ACReqEndQuestOperator = sb.ReadUshort();
            ACResItemCode = sb.ReadUshort();
            ACResItemClass = sb.ReadByte();
        }
    }

    public class QuestAcquireActionInfo
    {
        public byte ReqItemDelete { get; init; }
        public ushort[] GiveItemCode { get; init; }//3
        public byte[] GiveItemNum { get; init; }//3
        public uint ExpireTime { get; init; }
        
        public QuestAcquireActionInfo(ref StringBuffer sb)
        {
            ReqItemDelete = sb.ReadByte();
            GiveItemCode = new ushort[3];
            for(int i=0;i<3;i++){GiveItemCode[i]=sb.ReadUshort(); }
            GiveItemNum = new byte[3];
            for(int i=0;i<3;i++){GiveItemNum[i]=sb.ReadByte(); }
            ExpireTime = sb.ReadUint();

        }
    }

    public class QuestCompleteConditionInfo
    {
        public QuestCompleteConditionInfo(ref StringBuffer sb)
        {
            RequireCharLevel = sb.ReadUshort();
            RequireHeim = sb.ReadUshort();
            ReqMissionCode = new ushort[2];
            ReqMissionCode[0] = sb.ReadUshort();
            ReqMissionCode[1] = sb.ReadUshort();
            ReqMissionNum = new byte[2];
            ReqMissionNum[0] = sb.ReadByte();
            ReqMissionNum[1] = sb.ReadByte();
            
            ReqTrigger = new byte[4];
            for(int i=0;i<4;i++){ReqTrigger[i]=sb.ReadByte(); }
            
            ReqEndQuestCode = new ushort[5];
            for(int i=0;i<5;i++){ReqEndQuestCode[i]=sb.ReadUshort(); }
            ReqEndQuestNum = new byte[5];
            for(int i=0;i<5;i++){ReqEndQuestNum[i]=sb.ReadByte(); }
            
            ReqItemCode = new ushort[5];
            for(int i=0;i<5;i++){ReqItemCode[i]=sb.ReadUshort(); }
            ReqItemNum = new byte[5];
            for(int i=0;i<5;i++){ReqItemNum[i]=sb.ReadByte(); }

            ReqItemDelete = sb.ReadByte();

            ReqKillMonsterCode = new ushort[5];
            ReqKillMonsterGrade = new byte[5];
            ReqKillMonsterLevel = new ushort[5];
            for (int i = 0; i < 5; i++)
            {
                ReqKillMonsterCode[i] = sb.ReadUshort();
                ReqKillMonsterGrade[i] = sb.ReadByte();
                ReqKillMonsterLevel[i] = sb.ReadUshort();
            }

            ReqKillMonsterMapCode = new uint[5];
            for (int i = 0; i < 5; i++) {ReqKillMonsterMapCode[i] = sb.ReadUint(); }
            ReqKillMonsterNum = new byte[5];
            for (int i = 0; i < 5; i++) {ReqKillMonsterNum[i] = sb.ReadByte(); }

            sb.Skip(5);

            SummonMonsterCode = sb.ReadUshort();
            sb.Skip();


        }
        
        public ushort RequireCharLevel { get; init; }
        public ulong RequireHeim { get; init; }
        public ushort[] ReqMissionCode { get; init; } //2
        public byte[] ReqMissionNum { get; init; } //2
        public byte[] ReqTrigger { get; init; }//4
        public ushort[] ReqEndQuestCode { get; init; } //5
        public byte[] ReqEndQuestNum { get; init; } //5
        public ushort[] ReqItemCode { get; init; } //5
        public byte[] ReqItemNum { get; init; } //5
        public byte ReqItemDelete { get; init; }
        public ushort[] ReqKillMonsterCode { get; init; }
        public byte[] ReqKillMonsterGrade { get; init; }
        public ushort[] ReqKillMonsterLevel { get; init; }
        public uint[] ReqKillMonsterMapCode { get; init; }
        public byte[] ReqKillMonsterNum { get; init; }
        public ushort SummonMonsterCode { get; init; }
        
    }

    public class QuestCompleteActionInfo
    {
        public ushort[] RewardCode { get; init; }

        public QuestCompleteActionInfo(ref StringBuffer sb)
        {
                        
            RewardCode = new ushort[5];
            for(int i=0;i<5;i++){RewardCode[i]=sb.ReadUshort(); }
        }
    }
    


}
