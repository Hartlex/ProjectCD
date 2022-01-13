using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.ByteLevel;

namespace SunStructs.PacketInfos.Game.Status.Server
{
    public class TotalStateInfo : ServerPacketInfo
    {
        public readonly byte StateCount;
        public readonly StateInfo[] States;
        public readonly byte EtcStateCount;
        public readonly EtcStateInfo[] EtcStates;
        
        public TotalStateInfo(EtcStateInfo[] etcStates)
        {
            StateCount = 0;
            States = Array.Empty<StateInfo>();
            EtcStateCount = (byte) etcStates.Length;
            EtcStates = etcStates;
        }

        public TotalStateInfo()
        {
            StateCount = 0;
            EtcStateCount = 0;
            States = Array.Empty<StateInfo>();
            EtcStates = Array.Empty<EtcStateInfo>();
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(StateCount);
            foreach (var stateInfo in States)
            {
                stateInfo.GetBytes(ref buffer);
            }
            buffer.WriteByte(EtcStateCount);
            foreach (var stateInfo in EtcStates)
            {
                stateInfo.GetBytes(ref buffer);
            }
        }
    }

    public class EtcStateInfo :ServerPacketInfo
    {
        public readonly ushort StateCode;
        public readonly uint StateTime;

        public EtcStateInfo(ushort stateCode, uint stateTime)
        {
            StateCode = stateCode;
            StateTime = stateTime;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(StateCode);
            buffer.WriteUInt32(StateTime);
        }
    }

    public class StateInfo : ServerPacketInfo
    {
        public readonly ushort SkillCode;
        public readonly byte Reflect;
        public readonly byte AbilityIndex;
        public readonly int LeaveTime;

        public StateInfo(ushort skillCode, byte reflect, byte abilityIndex, int leaveTime)
        {
            SkillCode = skillCode;
            Reflect = reflect;
            AbilityIndex = abilityIndex;
            LeaveTime = leaveTime;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(SkillCode);
            buffer.WriteByte(Reflect);
            buffer.WriteByte(AbilityIndex);
            buffer.WriteInt32(LeaveTime);
        }
    }
}
