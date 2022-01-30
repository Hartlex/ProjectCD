using CDShared.Parsing;

namespace CherryDragon.Structures.ForGame.AI
{
    public class AiParamInfo
    {
        public readonly ushort AggroTime; // ¾î±×·Î ÁÖ±â
        public readonly ushort BattleRecordUpdateTime; // BattleRecord ¾÷µ¥ÀÌÆ® ÁÖ±â
        public readonly byte DamagePointReduceRatio; // µ¥¹ÌÁö Æ÷ÀÎÆ® »è°¨·ü
        public readonly ushort MinDamagePoint; // ÃÖ¼Òµ¥¹ÌÁö Æ÷ÀÎÆ®(ÃÖ¼Òµ¥¹ÌÁö Æ÷ÀÎÆ® ÀÌÇÏÀÌ¸é Æ÷ÀÎÆ®°¡ »è°¨µÉ ¶§ 0À¸·Î ÃÊ±âÈ­µÈ´Ù.)
        public readonly ushort FirstAttackPoint; // ¼±°ø Æ÷ÀÎÆ®
        public readonly ushort NearDistancePoint; // ÃÖ¼Ò °Å¸® Æ÷ÀÎÆ®
        public readonly ushort LowLevelPoint; // ÃÖ¼Ò ·¹º§ Æ÷ÀÎÆ®
        public readonly ushort LowHPPoint; // ÃÖ¼Ò Ã¼·ÂºñÀ² Æ÷ÀÎÆ®
        public readonly ushort DamagePoint; // µ¥¹ÌÁö Æ÷ÀÎÆ®

        // »óÅÂ ÁÖ±â ½Ã°£
        public readonly ushort SearchPeriod; // Å½»ö ÁÖ±â
        public readonly ushort RetreatPeriod; // ÈÄÅð ÁÖ±â
        public readonly ushort TrackPeriod; // ÃßÀû ÁÖ±â
        public readonly ushort DeadWaitingTime; // »ç¸Á´ë±â ½Ã°£
        public readonly ushort IdleMinTime; // IDLE ÃÖ¼Ò ½Ã°£
        public readonly ushort IdleMaxTime; // IDLE ÃÖ´ë ½Ã°£
        public readonly ushort KnockdownTime; // ´Ù¿î À¯Áö ½Ã°£
        public readonly ushort RunawayTime; // µµ¸Á À¯Áö ½Ã°£
        public readonly ushort ThrustTime; // ¹Ð¸®±â À¯Áö ½Ã°£

        // °Å¸® °ü·Ã
        public readonly float MinMoveDistance; // ÇÑ¹ø¿¡ ÀÌµ¿ÇÏ´Â ÃÖ¼Ò°Å¸®(Wander, Return, RunAway ...)
        public readonly float MaxMoveDistance;
        public readonly float RegenLocationLimit; // ¸ó½ºÅÍ°¡ ÃÖ´ë·Î ¹þ¾î³¯ ¼ö ÀÖ´Â ¹Ý°æ
        public readonly float MinMovableDistance; // ÀÌ¼öÄ¡ ÀÌÇÏÀÌ¸é ÀÌµ¿À» ¾ÈÇÑ´Ù.
        public readonly float WanderRadiusFromRegenarea; // ¸®Á¨µÈ ¿µ¿ªÀ¸·ÎºÎÅÍ ¹æÈ²ÇÏ´Â ÃÖ´ë¹üÀ§
        public readonly float GroupFollowerMinRadius; // ±×·ì¸ó½ºÅÍ ¸â¹öµéÀÌ ¸®´õ·ÎºÎÅÍ µû¶ó´ó±â´Â ÃÖ¼Ò¹üÀ§
        public readonly float GroupFollowerMaxRadius;

        // Á¡ÇÁ »óÅÂ
        public readonly float JumpMinHeight; // Á¡ÇÁ°¡´ÉÇÑ ÃÖ¼Ò ³ôÀÌ
        public readonly float JumpMaxHeight;
        public readonly float JumpMinDistance;
        public readonly float JumpMaxDistance;

        // FallApart »óÅÂ
        public readonly float
            FallapartMinAttackRangeLimit; // ÃÖ¼Ò °ø°Ý»ç°Å¸®, ÀÌ°Å¸®º¸´Ù °¡±î¿ì¸é ¸ó½ºÅÍ´Â ÇÑ¹ß ¹°·¯³­´Ù.

        // Retreat »óÅÂ
        public readonly float RetreatMinDistanceLimit; // »ç°Å¸®°¡ ÀÌ¼öÄ¡ ÀÌ»óÀÌ¾î¾ß ÈÄÅð°ø°ÝÀ» ÇÑ´Ù.
        public readonly float RetreatMinDistanceLimitRatio; // ÇöÀç°Å¸®°¡ »ç°Å¸®*Ratio ÀÌÇÏ°¡ µÇ¸é ÈÄÅð¸¦ ÇÑ´Ù.
        
        // Help »óÅÂ
        public readonly float HelpSightrangeRatio; // ÇïÇÁ»óÅÂÀÏ ¶§ÀÇ ½Ã¾ß¹üÀ§ ¹è¼ö
        public readonly float HelpRequestHPPercent; // Ã¼·ÂÀÌ 50ÇÁ·Î ÀÌÇÏÀÏ ¶§ ÇïÇÁ¸¦ ¿äÃ»ÇÑ´Ù.

        // ±âÅ¸
        public readonly float RangeTolerance; // »ç°Å¸® °øÂ÷
        public readonly ushort SearchRotateAngle; // Å½»ö È¸Àü°¢
        public readonly byte MaxObserversPerPlayer; // ÇÃ·¹ÀÌ¾î´ç ¸ó½ºÅÍ ¼ö
        public readonly ushort GroupAimessageMinDelay; // ±×·ì¸í·É ÃÖ¼Ò µô·¹ÀÌ
        public readonly ushort GroupAimessageMaxDelay;
        public readonly ushort TrackInnerAngle; // ÃßÀû ³»°¢
        public readonly ushort WRegenCycle; // ¸®Á¨ ÁÖ±â
        public readonly ushort PlayingOverTime; // ÇÇ·Îµµ ½Ã°£(12½Ã°£)

        // ½ºÅ³°ü·Ã
        public readonly float EtherSplashDamageRatio; // ¹ßÅ°¸® ¿¡Å×¸£ ¿þÆù ½ºÇÃ·¡½¬ µ¥¹ÌÁö ºñÀ²
        public readonly float StyleSplashDamageRatio; // ÀÏ¹Ý ½ºÅ¸ÀÏ ½ºÇÃ·¡½¬ µ¥¹ÌÁö ºñÀ²
        
        // ¼ÒÈ¯ °ü·Ã
        public readonly float SummonFollowDistance; // ¼ÒÈ¯Ã¼°¡ ¼ÒÈ¯ÀÚ¸¦ µû¶ó´ó±â´Â °Å¸®
        public readonly float SummonMaxFollowDistance; // ¼ÒÈ¯Ã¼°¡ ÅÚ·¹Æ÷Æ®ÇÏ´Â °Å¸®
        public readonly ushort SummonChangeDestposTime; // ¼ÒÈ¯Ã¼°¡ »ó´ëÀ§Ä¡¸¦ º¯°æÇÏ´Â ÁÖ±â

        // HP, MP ¸®Á¨ ÁÖ±â °ü·Ã
        public readonly ushort PlayerHPRegenPeriod; // ÇÃ·¹ÀÌ¾î HP ¸®Á¨ ÁÖ±â
        public readonly ushort PlayerMPRegenPeriod; // ÇÃ·¹ÀÌ¾î MP ¸®Á¨ ÁÖ±â
        public readonly ushort NPCHPMPRegenPeriod;		// NPC HPMP ¸®Á¨ ÁÖ±â

        public AiParamInfo(string[] info)
        {
            var sb = new StringBuffer(info);
            AggroTime = sb.ReadUshort();
            BattleRecordUpdateTime = sb.ReadUshort();
            DamagePointReduceRatio = sb.ReadByte();
            MinDamagePoint = sb.ReadUshort();
            FirstAttackPoint = sb.ReadUshort();
            NearDistancePoint = sb.ReadUshort();
            LowLevelPoint = sb.ReadUshort();
            LowHPPoint = sb.ReadUshort();
            DamagePoint = sb.ReadUshort();

            SearchPeriod = sb.ReadUshort();
            RetreatPeriod = sb.ReadUshort();
            TrackPeriod = sb.ReadUshort();
            DeadWaitingTime = sb.ReadUshort();
            IdleMinTime = sb.ReadUshort();
            IdleMaxTime = sb.ReadUshort();
            KnockdownTime = sb.ReadUshort();
            RunawayTime = sb.ReadUshort();
            ThrustTime = sb.ReadUshort();


            MinMoveDistance = sb.ReadFloat();
            MaxMoveDistance = sb.ReadFloat();
            RegenLocationLimit = sb.ReadFloat();
            MinMovableDistance = sb.ReadFloat();
            WanderRadiusFromRegenarea = sb.ReadFloat();
            GroupFollowerMinRadius = sb.ReadFloat();
            GroupFollowerMaxRadius = sb.ReadFloat();
            JumpMinHeight = sb.ReadFloat();
            JumpMaxHeight = sb.ReadFloat();
            JumpMinDistance = sb.ReadFloat();
            JumpMaxDistance = sb.ReadFloat();
            FallapartMinAttackRangeLimit = sb.ReadFloat();
            RetreatMinDistanceLimit = sb.ReadFloat();
            RetreatMinDistanceLimitRatio = sb.ReadFloat();
            HelpSightrangeRatio = sb.ReadFloat();
            HelpRequestHPPercent = sb.ReadFloat();

            RangeTolerance = sb.ReadFloat();
            SearchRotateAngle = sb.ReadUshort();
            MaxObserversPerPlayer = sb.ReadByte();

            GroupAimessageMinDelay = sb.ReadUshort();
            GroupAimessageMaxDelay = sb.ReadUshort();
            TrackInnerAngle = sb.ReadUshort();
            WRegenCycle = sb.ReadUshort();
            PlayingOverTime = sb.ReadUshort();

            EtherSplashDamageRatio = sb.ReadFloat();
            StyleSplashDamageRatio = sb.ReadFloat();

            SummonFollowDistance = sb.ReadFloat();
            SummonMaxFollowDistance = sb.ReadFloat();
            SummonChangeDestposTime = sb.ReadUshort();

            PlayerHPRegenPeriod = sb.ReadUshort();
            PlayerMPRegenPeriod = sb.ReadUshort();
            NPCHPMPRegenPeriod = sb.ReadUshort();

        }
    }
}