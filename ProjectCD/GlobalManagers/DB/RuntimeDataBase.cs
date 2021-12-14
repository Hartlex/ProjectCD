﻿using System.Configuration;
using CDShared.Generics;
using CDShared.Logging;
using SunStructs.RuntimeDB;

namespace ProjectCD.GlobalManagers.DB
{
    public class RuntimeDataBase : Singleton<RuntimeDataBase>
    {
        public void Initialize()
        {
            var dataFolderPath = ConfigurationManager.AppSettings["dataPath"];
            //StringDB.Instance.Init(dataFolderPath);
            BaseItemDB.Instance.Init(dataFolderPath);
            //BaseSkillDB.Instance.Init(dataFolderPath);
            //BaseNpcDB.Instance.Init(dataFolderPath);
            BaseMapDB.Instance.Init(dataFolderPath);
            //PortalDB.Instance.Init(dataFolderPath);
            //AreaDB.Instance.Init(dataFolderPath);
            //RankOptionDB.Instance.Init(dataFolderPath);
            //StateInfoDB.Instance.Init(dataFolderPath);
            //NpcShopDB.Instance.Init(dataFolderPath);
            //EnchantInfoDB.Instance.Init(dataFolderPath);
            //ExpInfoDB.Instance.Init(dataFolderPath);
            //TileInfoDB.Instance.Init();
            //RespawnInfoDB.Instance.Init(dataFolderPath);
            //QuestInfoDB.Instance.Init(dataFolderPath);
            //RewardInfoDB.Instance.Init(dataFolderPath);
            //DropRatioInfoDB.Instance.Init(dataFolderPath);
            //AiParameterDb.Instance.Init(dataFolderPath);
            //MissionInfoDB.Instance.Init(dataFolderPath);
            Logger.Instance.Log("Runtime DB initialized!",LogType.SUCCESS);
        }
    }
}