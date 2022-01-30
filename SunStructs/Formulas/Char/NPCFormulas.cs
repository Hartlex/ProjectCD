using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Formulas.Char
{
    public static class NPCFormulas
    {
        public static int CalcNpcHPRecovery(int maxHP, uint recoveryRatio = 1)
        {
            return (int) (maxHP * 0.005f * recoveryRatio);
        }
        public static int CalcNpcMPRecovery(int maxMP, uint recoveryRatio = 1)
        {
            return (int)(maxMP * 0.01f * recoveryRatio);
        }
        public static int CalcNpcSDRecovery(int maxSD)
        {
            return (int)(maxSD * 0.15f);
        }
    }
}
