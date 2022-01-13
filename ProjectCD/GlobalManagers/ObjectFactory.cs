using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDShared.Generics;
using CDShared.Logging;
using ProjectCD.Objects.Game.CDObject;
using ProjectCD.Objects.Game.CDObject.CDCharacter.CDNPC.MOB;
using SunStructs.Definitions;
using static ProjectCD.Objects.Game.CDObject.ObjectKey;

namespace ProjectCD.GlobalManagers
{
    public class ObjectFactory : Singleton<ObjectFactory>
    {
        private ObjectKeyGenerator _monsterKeyGen;
        private ObjectKeyGenerator _itemKeyGen;

        public void Initialize()
        {
            Logger.Instance.Log("Creating ObjectKeyGenerators...",LogType.SYSTEM_MESSAGE);
            Logger.Instance.LogLine(LogType.SYSTEM_MESSAGE);
            _monsterKeyGen = new (MONSTER_OBJECT_KEY , NPC_OBJECT_KEY);
            _itemKeyGen = new (ITEM_OBJECT_KEY , PET_OBJECT_KEY);
            Logger.Instance.LogLine(LogType.SYSTEM_MESSAGE);
            Logger.Instance.Log("");

        }

        public ObjectBase? CreateObject(ObjectType type)
        {
            switch (type)
            {
                case ObjectType.OBJECT_OBJECT:
                    break;
                case ObjectType.CHARACTER_OBJECT:
                    break;
                case ObjectType.NONCHARACTER_OBJECT:
                    break;
                case ObjectType.PLAYER_OBJECT:
                    break;
                case ObjectType.NPC_OBJECT:
                    break;
                case ObjectType.MONSTER_OBJECT:
                    return new Monster(_monsterKeyGen.GetKey());
                case ObjectType.SUMMON_OBJECT:
                    break;
                case ObjectType.MERCHANT_OBJECT:
                    break;
                case ObjectType.MAPNPC_OBJECT:
                    break;
                case ObjectType.LUCKYMON_OBJECT:
                    break;
                case ObjectType.ITEM_OBJECT:
                    return new FieldItem(_itemKeyGen.GetKey());
                case ObjectType.MAP_OBJECT:
                    break;
                case ObjectType.MONEY_OBJECT:
                    break;
                case ObjectType.CAMERA_OBJECT:
                    break;
                case ObjectType.TRANSFORM_PLAYER_OBJECT:
                    break;
                case ObjectType.TOTEMNPC_OBJECT:
                    break;
                case ObjectType.PET_OBJECT:
                    break;
                case ObjectType.SSQMONSTER_OBJECT:
                    break;
                case ObjectType.COLLECTION_OBJECT:
                    break;
                case ObjectType.LOTTO_NPC_OBJECT:
                    break;
                case ObjectType.RIDER_OBJECT:
                    break;
                case ObjectType.CRYSTALWARP_OBJECT:
                    break;
                case ObjectType.FRIEND_MONSTER_OBJECT:
                    break;
                case ObjectType.SYNC_MERCHANT_OBJECT:
                    break;
                case ObjectType.MAX_OBJECT:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return null;
        }

        public void FreeObject(ObjectBase obj)
        {
            switch (obj.GetObjectType())
            {
                case ObjectType.OBJECT_OBJECT:
                    break;
                case ObjectType.CHARACTER_OBJECT:
                    break;
                case ObjectType.NONCHARACTER_OBJECT:
                    break;
                case ObjectType.PLAYER_OBJECT:
                    break;
                case ObjectType.NPC_OBJECT:
                    break;
                case ObjectType.MONSTER_OBJECT:
                    _monsterKeyGen.FreeKey(obj.GetKey());
                    break;
                case ObjectType.SUMMON_OBJECT:
                    break;
                case ObjectType.MERCHANT_OBJECT:
                    break;
                case ObjectType.MAPNPC_OBJECT:
                    break;
                case ObjectType.LUCKYMON_OBJECT:
                    break;
                case ObjectType.ITEM_OBJECT:
                    _itemKeyGen.FreeKey(obj.GetKey());
                    break;
                case ObjectType.MAP_OBJECT:
                    break;
                case ObjectType.MONEY_OBJECT:
                    break;
                case ObjectType.CAMERA_OBJECT:
                    break;
                case ObjectType.TRANSFORM_PLAYER_OBJECT:
                    break;
                case ObjectType.TOTEMNPC_OBJECT:
                    break;
                case ObjectType.PET_OBJECT:
                    break;
                case ObjectType.SSQMONSTER_OBJECT:
                    break;
                case ObjectType.COLLECTION_OBJECT:
                    break;
                case ObjectType.LOTTO_NPC_OBJECT:
                    break;
                case ObjectType.RIDER_OBJECT:
                    break;
                case ObjectType.CRYSTALWARP_OBJECT:
                    break;
                case ObjectType.FRIEND_MONSTER_OBJECT:
                    break;
                case ObjectType.SYNC_MERCHANT_OBJECT:
                    break;
                case ObjectType.MAX_OBJECT:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    class ObjectKeyGenerator
    {
        private readonly Queue<uint> _idQueue;

        public ObjectKeyGenerator(ObjectKey from, ObjectKey to)
        {
            _idQueue = new ((to+1) - from);
            for (uint i = (uint)from; i < (uint)to; i++)
            {
                _idQueue.Enqueue(i);
            }

            Logger.Instance.Log($"[{from}] Created {_idQueue.Count} keys!",LogType.SUCCESS);

        }

        public uint GetKey()
        {
            return _idQueue.Dequeue();
        }

        public void FreeKey(uint key)
        {
            _idQueue.Enqueue(key);
        }
    }
}
