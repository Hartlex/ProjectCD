using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using ProjectCD.GlobalManagers;
using ProjectCD.Objects.Game.World;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General;

namespace ProjectCD.Objects.Game.CDObject;

public abstract class ObjectBase
{
    private uint _objectID;
    private SunVector _position;
    private ObjectType _objectType;
    private Field? _currentField;
    protected ObjectBase(uint key)
    {
        _objectID = key;
        _objectType = ObjectType.OBJECT_OBJECT;
        _position = new SunVector(0, 0, 0);
    }

    ~ObjectBase()
    {
        ObjectFactory.Instance.FreeObject(this);
    }

    public abstract bool Update(long currentTick);
    public virtual void SetPos(SunVector pos){ _position = pos; }
    public SunVector GetPos(){return _position;}
    public ObjectType GetObjectType() { return _objectType; }

    public bool IsObjectType(ObjectType type)
    {
        return (_objectType & type)==type;
    }
    public void SetObjectType(ObjectType type) { _objectType = type; }
    public uint GetKey() { return _objectID; }
    public virtual void OnEnterField(Field field, SunVector pos, ushort angle = 0)
    {
        _currentField = field;
        _position = pos;
    }

    public virtual void OnLeaveField()
    {
        _currentField = null;
    }

    public Field? GetCurrentField()
    {
        return _currentField;
    }

    public override bool Equals(object? obj)
    {
        return obj is ObjectBase objBase && Equals(objBase);
    }

    protected bool Equals(ObjectBase other)
    {
        return _objectID == other._objectID;
    }

    public override int GetHashCode()
    {
        return (int) _objectID;
    }
}

public enum ObjectKey
{
    PLAYER_OBJECT_KEY = 0,
    MONSTER_OBJECT_KEY = 500000,
    NPC_OBJECT_KEY = 1000000,
    NONCHARACTER_OBJECT_KEY = 1500000,
    MAP_OBJECT_KEY = 2000000,
    ITEM_OBJECT_KEY = 2500000,
    PET_OBJECT_KEY = 3000000,
    ONLYCLIENT_OBJECT_KEY = 3400000,
    ONLYCLIENT_BATTLEZONE_OBJECT_KEY = 3410000,
    MAX_OBJECT_KEY = 3500000,
};