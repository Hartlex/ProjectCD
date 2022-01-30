using CDShared.Generics;
using CDShared.Logging;
using CherryDragon.Structures.ForGame.AI;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General.Object.AI;

namespace SunStructs.RuntimeDB
{
    public class AiParameterDb : Singleton<AiParameterDb>
    {
        private Dictionary<byte, AiTypeInfo> _aiTypeInfos;
        private AiParamInfo _aiParamInfo;

        public void Init(string dataFolderPath)
        {
            var parser = new AiTypeParser();
            _aiTypeInfos = parser.ParseTypeInfos(dataFolderPath);
            _aiParamInfo = parser.ParseParamInfo(dataFolderPath);
        }
        
        public AiTypeInfo GetAiTypeInfo(byte code)
        {
            try
            {
                return _aiTypeInfos[code];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e);
                return null;
            }

        }

        public AiParamInfo GetAiParamInfo()
        {
            return _aiParamInfo;
        }
    }
}
