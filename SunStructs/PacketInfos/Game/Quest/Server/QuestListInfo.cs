using CDShared.ByteLevel;
using SunStructs.ServerInfos.General.Quest;

namespace SunStructs.PacketInfos.Game.Quest.Server
{
    public class QuestListInfo : ServerPacketInfo
    {
        public FinishedQuestInfo[] FinishedQuestInfos { get; init; }
        public OngoingQuestInfo[] OngoingQuestInfos { get; init; }
        
        public QuestListInfo(FinishedQuestInfo[] finishedQuestInfos,OngoingQuestInfo[] ongoingQuestInfos)
        {
            FinishedQuestInfos = finishedQuestInfos;
            OngoingQuestInfos = ongoingQuestInfos;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16((ushort)FinishedQuestInfos.Length);
            foreach (var finishedQuestInfo in FinishedQuestInfos)
            {
                finishedQuestInfo.GetBytes(ref buffer);
            }
            buffer.WriteByte((byte)OngoingQuestInfos.Length);
            foreach (var ongoingQuestInfo in OngoingQuestInfos)
            {
                ongoingQuestInfo.GetBytes(ref buffer);
            }
        }
    }

    public class FinishedQuestInfo : ServerPacketInfo
    {
        public byte Flag { get; init; } //not 0
        public ushort QuestCode { get; init; }

        public FinishedQuestInfo(ref ByteBuffer buffer)
        {
            Flag = buffer.ReadByte();
            QuestCode = buffer.ReadUInt16();
        }
        public FinishedQuestInfo(ushort questCode)
        {
            Flag = 1;
            QuestCode = questCode;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteByte(Flag);
            buffer.WriteUInt16(QuestCode);
        }
    }

    public class OngoingQuestInfo : ServerPacketInfo
    {
        public ushort QuestCode { get; init; }
        public QuestProgress Progress { get; init; }
        
        public OngoingQuestInfo(ushort questCode)
        {
            QuestCode = questCode;
            Progress = new QuestProgress();
        }
        public OngoingQuestInfo(ushort questCode, QuestProgress progress)
        {
            QuestCode = questCode;
            Progress = progress;
        }

        public override void GetBytes(ref ByteBuffer buffer)
        {
            buffer.WriteUInt16(QuestCode);
            Progress.GetBytes(ref buffer);
        }
    }
}
