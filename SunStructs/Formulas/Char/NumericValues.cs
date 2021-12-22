using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;
using static SunStructs.Definitions.CharMoveState;
using static SunStructs.Definitions.Const;
using static SunStructs.ServerInfos.General.Object.Items.RankSystem.Rank;

namespace SunStructs.Formulas.Char
{
    public static class NumericValues
    {
        public static float GetBaseMoveSpeedAsState(CharMoveState state)
        {
            switch (state)
            {
                case CMS_WALK: return 1.2f * SPEED_MULTIPLIER;
                case CMS_RUN: return 5.0f * SPEED_MULTIPLIER;
                case CMS_SWIPE: return 10.0f * SPEED_MULTIPLIER;
                case CMS_KNOCKBACK: return 6.0f * SPEED_MULTIPLIER;
                case CMS_KNOCKBACK2: return 15.0f * SPEED_MULTIPLIER; //__NA001048_080514_APPEND_ABILITY_KNOCKBACK2__
                case CMS_KNOCKBACK_DOWN: return 12.0f * SPEED_MULTIPLIER;
                case CMS_SIDESTEP: return 4.0f * SPEED_MULTIPLIER;
                case CMS_BACKSTEP: return 3.0f * SPEED_MULTIPLIER;
                case CMS_MONSTER_ATTACKJUMP: return 9.0f * SPEED_MULTIPLIER;
                case CMS_LUCKY_MONSTER_RUNAWAY: return 15.0f * SPEED_MULTIPLIER;
                case CMS_TUMBLING_FRONT: return 10.0f * SPEED_MULTIPLIER;
                case CMS_TUMBLING_LEFT: return 10.0f * SPEED_MULTIPLIER;
                case CMS_TUMBLING_RIGHT: return 10.0f * SPEED_MULTIPLIER;
                case CMS_TUMBLING_BACK: return 10.0f * SPEED_MULTIPLIER;
                case CMS_SHOULDER_CHARGE: return 10.0f * SPEED_MULTIPLIER;
                case CMS_SLIDING: return 10.0f * SPEED_MULTIPLIER;
                case CMS_TELEPORT: return 10.0f * SPEED_MULTIPLIER;
                case CMS_STOP: return 0;
            };


            return 5.0f * SPEED_MULTIPLIER;
        }

        public static float GetPriceWeightForEnchant(int enchant)
        {
            switch (enchant)
            {
                case 0: return 1.0f;
                case 1: return 1.4f;
                case 2: return 1.96f;
                case 3: return 2.74f;
                case 4: return 3.84f;
                case 5: return 5.38f;
                case 6: return 7.53f;
                case 7: return 10.54f;
                case 8: return 14.76f;
                case 9: return 20.66f;
                case 10: return 28.93f;
                case 11: return 40.50f;
                case 12: return 56.69f;
                case 13: return 56.69f;
                case 14: return 56.69f;
                case 15: return 56.69f;
            };
            return 0.3f;
        }

        public static float GetPriceWeightForRank(Rank param)
        {
            switch (param)
            {
                case RANK_E: return 0;
                case RANK_D: return 0;
                case RANK_C: return 0;
                case RANK_B: return 0;
                case RANK_MA: return 0;
                case RANK_A: return 0;
                case RANK_PA: return 0;
                case RANK_MS: return 0;
                case RANK_S: return 0;
                case RANK_PS: return 0;
            };

            return 0;
        }
    }
}
