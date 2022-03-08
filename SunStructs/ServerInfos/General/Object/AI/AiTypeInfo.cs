using CDShared.Parsing;

namespace SunStructs.ServerInfos.General.Object.AI
{
    public class AiTypeInfo
    {
        public readonly byte Code;
        public readonly uint SearchTargeType;
        public readonly uint AggroTime;
        public readonly uint BattleUpdateType;
        public readonly uint PointInitRandomRatio;
        public readonly uint TargetChangeRatio;
        public readonly uint[] ClassBasePoints;
        public readonly uint FirstAttPoint;
        public readonly uint NearDistPointInc;
        public readonly uint NearDistPointMax;
        public readonly uint LowLevelPointInc;
        public readonly uint LowLevelPointMax;
        public readonly uint LowHpPointInc;
        public readonly uint LowHpPointMax;
        public readonly uint DamagePointInc;
        public readonly uint DamagePointMax;
        public readonly uint SearchPeriod;
        public readonly uint RetreatPeriod;
        public readonly uint TrackPeriod;
        public readonly int IdleMinTime;
        public readonly int IdleMaxTime;
        public readonly uint RunawayTime;
        public readonly uint RegenLocationLimit;
        public readonly uint WanderRadius;
        public readonly float HelpRequestHPPercent;
        public readonly uint NpcHpMpRegenPeriod;
        public readonly uint NpcSDRecoveryPeriod;
        public readonly uint LuckyMonsterRunawayTimeMin;
        public readonly uint LuckyMonsterRunawayTimeMax;
        public readonly uint LuckyMonsterRegenTime;

        public AiTypeInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            Code = sb.ReadByte();
            SearchTargeType = sb.ReadUint();
            AggroTime = sb.ReadUint();
            BattleUpdateType= sb.ReadUint();
            PointInitRandomRatio= sb.ReadUint();
            TargetChangeRatio= sb.ReadUint();
            ClassBasePoints = new[]
            {
                sb.ReadUint(),
                sb.ReadUint(),
                sb.ReadUint(),
                sb.ReadUint(),
                sb.ReadUint(),
            };
            FirstAttPoint= sb.ReadUint();
            NearDistPointInc= sb.ReadUint();
            NearDistPointMax= sb.ReadUint();
            LowLevelPointInc= sb.ReadUint();
            LowLevelPointMax= sb.ReadUint();
            LowHpPointInc= sb.ReadUint();
            LowHpPointMax= sb.ReadUint();
            DamagePointInc= sb.ReadUint();
            DamagePointMax= sb.ReadUint();
            SearchPeriod= sb.ReadUint();
            RetreatPeriod= sb.ReadUint();
            TrackPeriod= sb.ReadUint();
            IdleMinTime= sb.ReadInt();
            IdleMaxTime= sb.ReadInt();
            RunawayTime= sb.ReadUint();
            RegenLocationLimit= sb.ReadUint();
            WanderRadius= sb.ReadUint();
            HelpRequestHPPercent= sb.ReadFloat();
            NpcHpMpRegenPeriod= sb.ReadUint();
            NpcSDRecoveryPeriod= sb.ReadUint();
            LuckyMonsterRunawayTimeMin= sb.ReadUint();
            LuckyMonsterRunawayTimeMax= sb.ReadUint();
            LuckyMonsterRegenTime= sb.ReadUint();
        }
    }
}
