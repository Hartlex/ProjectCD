using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunStructs.Definitions;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer
{
    internal partial class Player
    {
        private bool _forceAttack;

        public void SetForceAttack(bool value){ _forceAttack = true; }
        public override AttackType GetWeaponBaseAttackType()
        {
            var attackType = AttackType.ATTACK_TYPE_MELEE;

            var item = _equipment.GetItem((int) EquipContainerPos.EQUIPCONTAINER_WEAPON);
            if (item != null)
            {
                attackType = item.GetBaseInfo().BaseAttackType;
            }

            return attackType;
        }
        public override AttackType GetWeaponMagicAttackType()
        {
            var attackType = AttackType.ATTACK_TYPE_INVALID;

            var item = _equipment.GetItem((int)EquipContainerPos.EQUIPCONTAINER_WEAPON);
            if (item != null)
            {
                attackType = item.GetBaseInfo().MagicAttackType;
            }

            return attackType;
        }

        public override ArmorType GetArmorType()
        {
            var info = _equipment.GetItem((int)EquipContainerPos.EQUIPCONTAINER_ARMOR)?.GetBaseInfo();
            return info?.ArmorType ?? ArmorType.ARMOR_UNARMOR;
        }

        public override MeleeType GetMeleeType()
        {
            var info = _equipment.GetItem((int) EquipContainerPos.EQUIPCONTAINER_WEAPON)?.GetBaseInfo();
            return info?.MeleeType ?? MeleeType.MELEE_TYPE_HIT;
        }
    }
}
