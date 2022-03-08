using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Skill;

namespace SunStructs.RuntimeDB
{
    public class BaseSkillDB : Singleton<BaseSkillDB>
    {
        private Dictionary<ushort, RootSkillInfo> _baseSkillInfos;

        public void Init(string dataFolderPath)
        {
            var parser = new BaseSkillParser();
            _baseSkillInfos = parser.ParseBaseSkillInfos(dataFolderPath);

            var styleParser = new StyleInfoParser();
            var styleInfos = styleParser.ParseBaseStyleInfos(dataFolderPath);

            styleInfos.ToList().ForEach(x => _baseSkillInfos.Add(x.Key, x.Value));
            Logger.Instance.LogOnLine($"{_baseSkillInfos.Count} Skills loaded!\n", LogType.SUCCESS);


        }

        public BaseSkillInfo? GetBaseSkillInfo(ushort skillCode)
        {
            try
            {
                return _baseSkillInfos[skillCode] as BaseSkillInfo;
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }

        public BaseStyleInfo GetBaseStyleInfo(ushort styleCode)
        {
            try
            {
                return _baseSkillInfos[styleCode] as BaseStyleInfo;
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }
        public RootSkillInfo GetRootSkillInfo(ushort skillCode)
        {
            try
            {
                return _baseSkillInfos[skillCode];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString(),LogType.ERROR);
                return null;
            }
        }



    }
}
