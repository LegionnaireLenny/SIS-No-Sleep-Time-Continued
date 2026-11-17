using static SISNoSleepTime_Config;

public class SISNoSleepTime_Utils
{
    public static bool IsCharacterExempt(Character character)
    {
        if (character is Human)
        {
            return (EnabledForPlayer && character.IsOnPlayersTeam() && Hud.Instance.LocalControlledCharacter == character) ||
                    (EnabledForPlayerCommunity && character.IsOnPlayersTeam() && Hud.Instance.LocalControlledCharacter != character) ||
                    (EnabledForNonPlayableCharacters && !character.IsOnPlayersTeam());
        }
        else if (character is Animal)
        {
            return EnabledForAnimals;
        }
        return false;
    }
}
