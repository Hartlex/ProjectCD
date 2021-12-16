namespace ProjectCD.Objects.Game.CDObject.CDCharacter.CDPlayer.PlayerDataContainers.Slots;

public class PlayerStyleManager
{
    private ushort _currentStyleCode;
    public PlayerStyleManager(ushort currentStyleCode)
    {
        _currentStyleCode = currentStyleCode;
    }

    public ushort GetSelectedStyleCode()
    {
        return _currentStyleCode;
    }
}