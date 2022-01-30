using CDShared.ByteLevel;
using SunStructs.PacketInfos.Game.Skill.Server;
using SunStructs.ServerInfos.General.Skill;

namespace ProjectCD.Objects.Game.Slots.Skill
{
    public class SkillContainer
    {
        private readonly Dictionary<ushort, SkillSlot> _skillSlots = new();

        public SkillContainer(byte[] data)
        {
            ByteBuffer buffer = new(data);
            var count = buffer.ReadByte();
            for (int i = 0; i < count; i++)
            {
                var pos = buffer.ReadByte();
                var code = buffer.ReadUInt16();
                //Logger.Instance.Log(code.ToString());
                var slot = new SkillSlot(pos,code);
                _skillSlots.Add(code,slot);
            }
        }

        public byte[] Serialize()
        {
            ByteBuffer buffer = new();
            buffer.WriteByte((byte)_skillSlots.Count);
            foreach (var skillSlot in _skillSlots.Values)
            {
                skillSlot.GetBytes(ref buffer);
            }

            return buffer.GetData();
        }
        public bool HasSkill(ushort skillCode, out RootSkillInfo? skill)
        {
            var has = _skillSlots.ContainsKey(skillCode);

            skill = has ? _skillSlots[skillCode].RootSkillInfo : null;
            return has;

        }

        public void AddSkill(RootSkillInfo baseSkill, out SkillSlot skillSlot)
        {
            var pos = (byte)_skillSlots.Count;
            skillSlot = new SkillSlot(pos, baseSkill);
            _skillSlots.Add(baseSkill.SkillCode,skillSlot);
        }
        public void UpdateSkill(ushort oldSkillCode,RootSkillInfo newBaseInfo, out SkillSlotInfo slotInfo)
        {
            var oldSkillSlot = _skillSlots[oldSkillCode];
            _skillSlots.Remove(oldSkillCode);
            var skillSlot = new SkillSlot(oldSkillSlot.Pos, newBaseInfo);
            slotInfo = skillSlot.GetSlotInfo();
            _skillSlots.Add(newBaseInfo.SkillCode,skillSlot);
            
        }

        public bool TryGetSkillSlot(ushort skillCode, out SkillSlot slot)
        {
            return _skillSlots.TryGetValue(skillCode, out slot);
        }
    }
}
