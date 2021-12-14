namespace SunStructs.ServerInfos.General.Object.Items
{
    /// <summary>
    /// I have no idea what this is for
    /// </summary>
    public class ExerciseEffect
    {
        public ushort EffectCode;
        public ushort OptionType;
        public ushort OptionKind;
        public int OptionValue;

        public ExerciseEffect(ref string[] info, int start)
        {
            EffectCode = ushort.Parse(info[start]);
            OptionType = ushort.Parse(info[start+1]);
            OptionKind = ushort.Parse(info[start+2]);
            OptionValue = int.Parse(info[start+3]);
        }
    }
}