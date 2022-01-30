using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.EtherSystem.EtherDeviceCombo;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.EtherSystem
{
    internal enum EtherDeviceCombo
    {
        ETHER_DEVICE_COMBO_NORMAL = 0,
        ETHER_DEVICE_COMBO_1 = 1,
        ETHER_DEVICE_COMBO_2 = 2,
        ETHER_DEVICE_COMBO_3 = 3,
        ETHER_DEVICE_COMBO_4 = 4,
        ETHER_DEVICE_COMBO_5 = 5,
        ETHER_DEVICE_COMBO_MAX = 5,
    };
    public class EtherBulletOptionInfo
    {
        private const int MAX_BULLET_OPTION_COUNT = 3;

        public OptionInfo[] OptionInfos = new OptionInfo[MAX_BULLET_OPTION_COUNT];
    }

    public class EtherBulletInfo
    {
        public readonly ushort BulletID;
        public readonly ushort ItemCode;

        public readonly EtherBulletOptionInfo[] EtherOptionInfo =
            new EtherBulletOptionInfo[(int) ETHER_DEVICE_COMBO_MAX];
        public readonly int[] AttackSpeeds = new int[(int) ETHER_DEVICE_COMBO_MAX - 1];
        public readonly byte EffectCode;
        public readonly uint Effect;
        public readonly bool ApplyPvpDamage;
    }
    public struct OptionInfo
    {
        public readonly ushort OptionKind;
        public readonly byte ValueType;
        public readonly int Value;

    }
}
