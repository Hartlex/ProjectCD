using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunStructs.Formulas.Char
{
    public static class NPCFormulas
    {
        public static int CalcNpcHPRecovery(uint MaxHP, uint recoveryRatio = 1)
        {
            return (int) (MaxHP * 0.005f * recoveryRatio);
        }
        public static int CalcNpcMPRecovery(uint MaxMP, uint recoveryRatio = 1)
        {
            return (int)(MaxMP * 0.01f * recoveryRatio);
        }
        public static int CalcNpcSDRecovery(uint MaxSD)
        {
            return (int)(MaxSD * 0.15f);
        }
    }
}
