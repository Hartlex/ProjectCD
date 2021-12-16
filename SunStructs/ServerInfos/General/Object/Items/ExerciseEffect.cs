using SunStructs.Definitions;

namespace SunStructs.ServerInfos.General.Object.Items
{
    /// <summary>
    /// I have no idea what this is for
    /// </summary>
    public class ExerciseEffect
    {
        public byte Exercise;
        public AttrInfo AttrInfo;

        public ExerciseEffect(ref string[] info, int start)
        {
            Exercise = byte.Parse(info[start]);
            AttrInfo = new AttrInfo(
                byte.Parse(info[start + 1]),
                (AttrValueKind) byte.Parse(info[start + 2]),
                int.Parse(info[start + 3])
            );
        }
    }
}