using CDShared.Generics;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Skill.Style;

namespace SunStructs.RuntimeDB
{
    public class BaseQuickStyleRegDB :Singleton<BaseQuickStyleRegDB>
    {
        private Dictionary<uint, BaseQuickStyleRegisterInfo> _baseQuickStyleReg;

        public void Init(string dataFolderPath)
        {

            var parser = new BaseQuickStyleRegParser();
            _baseQuickStyleReg = parser.ParseAllInfos(dataFolderPath);
        }

        public BaseQuickStyleRegisterInfo GetQuickStyleRegisterInfo(byte cls, byte weapon)
        {
            var key = MakeKey(cls, weapon);
            return _baseQuickStyleReg[key];
        }
        private uint MakeKey(byte cls,byte weapon)
        {
            return ((uint) cls << 16 | weapon);
        }
    }
}
