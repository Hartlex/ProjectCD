using CDShared.Logging;
using ProjectCD.Servers.Game;
using SunStructs.RuntimeDB;

namespace ProjectCD.Objects.Game.World
{
    internal class FieldManager
    {
        private readonly Dictionary<uint, GameField> _activeFields;
        private readonly GameServer _gameServer;

        public FieldManager(GameServer gameServer)
        {
            _gameServer = gameServer;
            var infos = BaseMapDB.Instance.GetAllMaps();
            _activeFields = new(infos.Count);
            foreach (var info in infos)
            {
                var gameField = new GameField(info.Value,_gameServer);
                _activeFields.Add(info.Key,gameField);
            }
        }

        public GameField GetField(uint mapCode)
        {
            try
            {
                return _activeFields[mapCode];
            }
            catch (KeyNotFoundException e)
            {
                Logger.Instance.Log(e.ToString());
                return null;
            }
        }
    }
}
