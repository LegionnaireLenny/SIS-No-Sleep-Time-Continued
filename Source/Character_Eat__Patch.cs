using HarmonyLib;

[HarmonyPatch(typeof(Character), "Eat")]
public class Character_Eat__Patch
{
	private static void Postfix(Character __instance)
	{
        if (__instance == null)
        {
            return;
        }

        if ((SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal) ||
            (SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && !__instance.IsOnPlayersTeam()) ||
            (__instance is Human && __instance.IsOnPlayersTeam()))
        {
            __instance.SleepDeprivation = 0f;
        }
    }
}
