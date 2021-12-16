using CDShared.Generics;
using SunStructs.RuntimeDB.Parsers;

namespace SunStructs.RuntimeDB
{
    public class ExpInfoDB : Singleton<ExpInfoDB>
    {
        private Dictionary<ushort, ulong> _expValues;

        public void Init(string dataFolderPath)
        {
            var parser = new ExpInfoParser();
            _expValues = parser.ParseExpValues(dataFolderPath);
        }

        public ulong GetRequiredExp(ushort level)
        {
            return _expValues[level];
        }
    }
}
