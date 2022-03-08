using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer;
using SunStructs.Definitions;
using SunStructs.PacketInfos.Game.Status.Server;

namespace ProjectCD.Objects.Game.CDObject.CDCharacter.SkillSystem.StateSystem.AbilityState
{
    internal class DragonTransStatus : AbilityStatus
    {
        private bool _startingState=false;

        public override void Execute() { }

        public TransformType GetCharType(){ return (TransformType) Option2;}
        public override void Start()
        {
            var owner = GetOwner();
            if (owner == null) return;

            _startingState = true;


            int changedHP = SkillAttrCalc.ApplyDragonTransformation(true, SkillCode, owner.GetHP());
            owner.OnRecover(changedHP,0,0);

            ApplyAttrEx(true);
            _startingState = false;
        }


        public override void End()
        {
            var owner = GetOwner();
            if (owner == null) return;

            var dragonEndInfo = new DragonTransStartInfo();
            dragonEndInfo.PlayerKey = owner.GetKey();
            dragonEndInfo.SkillCode = SkillCode;
            dragonEndInfo.StatusCode = (ushort) GetCharType();

            var changedHP= SkillAttrCalc.ApplyDragonTransformation(false, SkillCode, owner.GetHP());
            owner.OnRecover(changedHP,0,0);
            ApplyAttrEx(false);
        }

        public bool CheckStarting(){ return _startingState; }

        private void ApplyAttrEx(bool apply)
        {
            var owner = GetOwner();
            if(owner== null) return;

            owner.UpdateCalcRecover(true,true,false);

            if (owner is Player player)
            {
                player.NotifyChangedStatus(PlayerStatEvent.CHANGED_HP);
                player.NotifyChangedStatus(PlayerStatEvent.CHANGED_MP);

                if (apply)
                {
                    if (GetCharType() == TransformType.TRANSFORM_TYPE_DRAGON1)
                        player.SetSelectedStyle(StyleEnum.STYLE_DRAGON_TRANSFORM1);
                    else
                        player.SetSelectedStyle(StyleEnum.STYLE_DRAGON_TRANSFORM2);
                }
                else
                    player.SelectBaseStyle();
            }


        }
    }
}
