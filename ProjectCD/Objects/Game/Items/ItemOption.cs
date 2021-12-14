using CDShared.ByteLevel;
using SunStructs.Definitions;
using SunStructs.ServerInfos.General.Object.Items.EnchantSystem;
using SunStructs.ServerInfos.General.Object.Items.RankSystem;
using SunStructs.ServerInfos.General.Object.Items.SocketSystem;

namespace ProjectCD.Objects.Game.Items;

internal class ItemOption
{
    private ulong _option1;
    private uint _option2;
    private uint _option3;
    private uint _option4;
    private byte[] _unkOption;

    private Rank _rank;
    private readonly RankOption[] _rankOptions = new RankOption[(int) Rank.RANK_MAX];
    private int _socketCount = 0;
    private readonly Socket[] _sockets = new Socket[(int) SocketID.SOCKET_MAX];
    private EnchantGrade _enchantGrade;
    private bool _etherMounted;
    public ItemOption()
    {
        _unkOption = new byte[5];
    }
    public ItemOption(ref ByteBuffer buffer)
    {
        var mask = new byte[8];
        var bytes = buffer.ReadBlock(6);
        Buffer.BlockCopy(bytes, 0, mask, 0, 6);
        _option1 = BitConverter.ToUInt64(mask);
        _option2 = buffer.ReadUInt32();
        _option3 = buffer.ReadUInt32();
        _option4 = buffer.ReadUInt32();
        _unkOption = buffer.ReadBlock(5);
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
            case Rank.RANK_F:
                break;
            case Rank.RANK_E:
                break;
            case Rank.RANK_D:
                _option1 = BitManip.Set13to19(_option1, value);
                break;
            case Rank.RANK_C:
                _option1 = BitManip.Set20to26(_option1, value);
                break;
            case Rank.RANK_B:
                _option1 = BitManip.Set27to33(_option1, value);
                break;
            case Rank.RANK_MA:
                _option1 = BitManip.Set34to40(_option1, value);
                break;
            case Rank.RANK_A:
                _option1 = BitManip.Set41to47(_option1, value);
                break;
            case Rank.RANK_PA:
                _option2 = BitManip.Set0to6(_option2, value);
                break;
            case Rank.RANK_MS:
                _option2 = BitManip.Set7to13(_option2, value);
                break;
            case Rank.RANK_S:
                _option2 = BitManip.Set14to20(_option2, value);
                break;
            case Rank.RANK_PS:
                _option2 = BitManip.Set21to27(_option2, value);
                break;
            case Rank.RANK_MAX:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(rank), rank, null);
        }
        _rankOptions[(int)rank] = rankOption;
    }
    public RankOption GeRankOption(Rank rank)
    {
        return _rankOptions[(int)rank];
    }
    public void SetEnchant(EnchantGrade enchant)
    {
        _enchantGrade = (EnchantGrade) enchant;
        _option2 = BitManip.Set28to31(_option2, enchant);
    }
    public EnchantGrade GetEnchant()
    {
        return _enchantGrade;
    }

    public int GetSocketCount()
    {
        return _socketCount;
    }
    public void SetSocket(SocketID id, SocketOption option, SocketLevel level)
    {
        var value = (byte)option.Value[(int)level];
        switch (id)
        {
            case SocketID.SOCKET_1:
                _option3 = BitManip.Set3to10(_option3, value);
                break;
            case SocketID.SOCKET_2:
                _option3 = BitManip.Set11to18(_option3, value);
                break;
            case SocketID.SOCKET_3:
                _option3 = BitManip.Set19to26(_option3, value);
                break;
            case SocketID.SOCKET_MAX:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(id), id, null);
        }

        bool n = _sockets[(int)id]  == null;
        _sockets[(int) id] = new ((AttrType) option.AttrIndex, option.NumericType, option.Value[(int) level]);
        if (n) _socketCount++;
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

}