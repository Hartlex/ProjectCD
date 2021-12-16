using CDShared.Generics;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.RuntimeDB.Parsers;
using SunStructs.ServerInfos.General;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;

namespace SunStructs.RuntimeDB
{
    public class RankOptionDB : Singleton<RankOptionDB>
    {
        private Dictionary<ItemType,Dictionary<byte,RankOption>>  _rankOptionDictionary;
        public void Init(string dataFolderPath)
        {
            var parser = new RankOptionParser();
            _rankOptionDictionary = parser.ParseAllOptions(dataFolderPath);
            Logger.Instance.LogOnLine($"{_rankOptionDictionary.Count} RankOptions loaded!\n", LogType.SUCCESS);
        }

        //public byte GetRankOptionIndex(Item item, )
        //{
        //    var itemType = item.GetItemType();
        //    var options = _rankOptionDictionary[itemType];
        //    var possibleOptions =
        //        (from option
        //            in options.Values
        //        where (option.Value[(int) item.ItemOption.GetRank()] != 0)
        //        select option).ToList();

        //    var rand = GlobalRand.Instance.Random(0, possibleOptions.Count());
        //    return possibleOptions[rand].OptionIndex;
        //}

        public RankOption GetRankOption(ItemType type,Rank rank)
        {
            var options = _rankOptionDictionary[type];
            var possibleOptions =
                (from option in options.Values
                    where (option.RankValues[(int) rank] != 0)
                    select option).ToList();

            var rand = GlobalRand.Instance.Random(0, possibleOptions.Count());
            return possibleOptions[rand];
        }
    }
}
