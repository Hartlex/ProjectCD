namespace SunStructs.Packets
{
    public enum AuthPacketType
    {
        AUTH=51
    }
    public enum GamePacketType
    {
        //AUTH=51,
        CONNECTION=72,
        CHAR_INFO=165,
        SYNC = 253,
        STATUS = 89,
        BATTLE = 60,
        ITEM = 33,
        INVENTORY = 101,
        SKILL = 200,
        ZONE =111,
        STYLE =98,
        QUEST = 106,
        WAREHOUSE = 247,
        TRIGGER = 226,
        PRIVATE_STORE = 47,
        MAP = 229
    }

    public enum WorldPacketType
    {
        WORLD = 253,
        CHAT = 165,
        Unk1 = 163,
        Unk2 = 98,
        Unk3 = 107
    }


}
