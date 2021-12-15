using CDShared.ByteLevel;
using CDShared.Logging;
using SunStructs.Definitions;
using SunStructs.RuntimeDB;
using SunStructs.ServerInfos.General.Object.Items.EnchantSystem;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;
using static SunStructs.ServerInfos.General.Object.Items.RankSystem.Rank;

namespace ProjectCD.Objects.Game.Items;

internal class ItemOption
{
    private ulong _option1;
    private uint _option2;
    private uint _option3;
    private uint _option4;
    private byte[] _unkOption;

    private readonly Item _owner;
    //User this when moving to byte[] instead of multiple uint,ulong
    //----------------
    //          Span<byte> span;
    //          ushort tmp;
    //          byte[] tmpConv;

    //private byte[] _data;
    //span = new Span<byte>(_data);
    //tmp =BitConverter.ToUInt16(span.Slice(1, 2));
    //tmp = BitManip.Set5to11(tmp, value);
    //tmpConv = BitConverter.GetBytes(tmp);
    //_data[1] = tmpConv[1];
    //_data[2] = tmpConv[2];
    //----------------


    private Rank _rank = RANK_E;
    private readonly RankInfo[] _ranks = new RankInfo[(int) RANK_MAX];
    private int _socketCount;
    private readonly SocketInfo[] _sockets = new SocketInfo[(int) SocketID.SOCKET_MAX];
    private EnchantGrade _enchantGrade = EnchantGrade.ENCHANT_LV0;
    private bool _etherMounted;
    private bool _isDivine;
    private byte _extraStoneOption;
    public ItemOption(Item owner)
    {
        _unkOption = new byte[5];
        _owner =owner;
    }
    public ItemOption(ref ByteBuffer buffer,Item owner)
    {
        var mask = new byte[8];
        var bytes = buffer.ReadBlock(6);
        Buffer.BlockCopy(bytes, 0, mask, 0, 6);
        _option1 = BitConverter.ToUInt64(mask);
        _option2 = buffer.ReadUInt32();
        _option3 = buffer.ReadUInt32();
        _option4 = buffer.ReadUInt32();
        _unkOption = buffer.ReadBlock(5);
        _owner = owner;

        InitFromBytes();
    }

    public void GetBytes(ref ByteBuffer buffer, ItemByteType type = ItemByteType.MAX)
    {
        switch (type)
        {
            case ItemByteType.MIN:
                break;
            case ItemByteType.TWENTY:
                var b2 = BitConverter.GetBytes(_option1);
                buffer.WriteBlock(b2, 0, 6);
                buffer.WriteUInt32(_option2);
                buffer.WriteUInt32(_option3);
                var b3 = BitConverter.GetBytes(_option4);
                buffer.WriteBlock(b3, 0, 2);
                break;
            case ItemByteType.MAX:
                var b = BitConverter.GetBytes(_option1);
                buffer.WriteBlock(b, 0, 6);
                buffer.WriteUInt32(_option2);
                buffer.WriteUInt32(_option3);
                buffer.WriteUInt32(_option4);
                buffer.WriteBlock(_unkOption);
                return;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }

    }
    public void SetRank(Rank rank)
    {
        _option1 = BitManip.Set9to12(_option1, (byte)rank);
        _rank = rank;
    }
    public Rank GetRank()
    {
        return _rank;
    }
    public void SetRankOption(Rank rank, RankOption rankOption)
    {
        var value = (byte)rankOption.AttrType;

        switch (rank)
        {
            case RANK_F:
                break;
            case RANK_E:
                break;
            case RANK_D:
                _option1 = BitManip.Set13to19(_option1, value);
                break;
            case RANK_C:
                _option1 = BitManip.Set20to26(_option1, value);
                break;
            case RANK_B:
                _option1 = BitManip.Set27to33(_option1, value);
                break;
            case RANK_MA:
                _option1 = BitManip.Set34to40(_option1, value);
                break;
            case RANK_A:
                _option1 = BitManip.Set41to47(_option1, value);
                break;
            case RANK_PA:
                _option2 = BitManip.Set0to6(_option2, value);
                break;
            case RANK_MS:
                _option2 = BitManip.Set7to13(_option2, value);
                break;
            case RANK_S:
                _option2 = BitManip.Set14to20(_option2, value);
                break;
            case RANK_PS:
                _option2 = BitManip.Set21to27(_option2, value);
                break;
            case RANK_MAX:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rank), rank, null);
        }
        _ranks[(int)rank] = new (rankOption.AttrType,rankOption.ValueKind,rankOption.RankValues[(int)rank]);
    }
    public RankInfo GeRankOption(Rank rank)
    {
        return _ranks[(int)rank];
    }
    public void SetEnchant(EnchantGrade enchant)
    {
        _enchantGrade = enchant;
        _option2 = BitManip.Set28to31(_option2, (byte)enchant);
    }
    public EnchantGrade GetEnchant()
    {
        return _enchantGrade;
    }

    public int GetSocketCount()
    {
        return _socketCount;
    }
    public void SetExtraStoneOption(byte inc)
    {
        _option1 = BitManip.Set6to8(_option1, inc);
        _extraStoneOption = inc;
    }

    public byte GetExtraStoneOption()
    {
        return _extraStoneOption;
    }
    public void SetSocket(SocketID id, SocketOption option, SocketLevel level)
    {
        switch (id)
        {
            case SocketID.SOCKET_1:
                _option3 = BitManip.Set3to10(_option3, option.SocketItemCode);
                break;
            case SocketID.SOCKET_2:
                _option3 = BitManip.Set11to18(_option3, option.SocketItemCode);
                break;
            case SocketID.SOCKET_3:
                _option3 = BitManip.Set19to26(_option3, option.SocketItemCode);
                break;
            case SocketID.SOCKET_MAX:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id), id, null);
        }

        bool n = _sockets[(int)id]  == null;
        _sockets[(int) id] = new ((AttrType) option.AttrIndex, option.NumericType, option.Value[(int) level]);
        if (n)
        {
            _socketCount++;
            _option3 = BitManip.Set1to2(_option3,(byte) _socketCount);
        }
    }

    public void SetDivine(byte b)
    {
        _option3 = BitManip.Set0(_option3, b);
        _isDivine = b == 1;
    }

    public bool IsDivine()
    {
        return _isDivine;
    }
    public int GetSocketValue(SocketID id)
    {
        return _sockets[(int)id].Value;
    }
    public void SetEtherMount(byte value)
    {
        _option3 = BitManip.Set27(_option3, value);
        _etherMounted = value == 1;
    }

    public bool IsEtherMounted()
    {
        return _etherMounted;
    }

    private void InitFromBytes()
    {
        _rank = (Rank)BitManip.Get9to12(_option1);
        for (int i = (int) RANK_D; i < (int) _rank; i++)
        {
            var option = RankOptionDB.Instance.GetRankOption(_owner.GetItemType(), (Rank)i);
            _ranks[i] = new RankInfo(option.AttrType, option.ValueKind, option.RankValues[i]);
        }

        _enchantGrade = (EnchantGrade) BitManip.Get28to31(_option2);
        _socketCount = BitManip.Get1to2(_option3);
        _isDivine = BitManip.Get0(_option3) == 1;
        _extraStoneOption = BitManip.Get6to8(_option1);
        for (int i = (int) SocketID.SOCKET_1; i < _socketCount; i++)
        {
            var code = BitManip.Get3to10(_option3);
            if (code == 0)
            {
                Logger.Instance.Log("No socket found!");
                return;
            }

            var socketInfo = SocketOptionDB.Instance.GetSocketItemOption(code);
            _sockets[i] = new SocketInfo((AttrType) socketInfo.AttrIndex, socketInfo.NumericType, socketInfo.Value);
        }
        _etherMounted = BitManip.Get27(_option3) == 1;
    }

    public RankInfo[]? GetRankValues()
    {
        var result = new RankInfo[(int) _rank];
        for (int i = (int) RANK_D; i < (int) _rank; i++)
        {
            result[i] = _ranks[i];
        }

        return result;
    }

    public SocketInfo[]? GetSockets()
    {
        var result = new SocketInfo[_socketCount];

        for (int i = 0; i < _socketCount; i++)
        {
            result[i] = _sockets[i];
        }

        return result;
    }

}