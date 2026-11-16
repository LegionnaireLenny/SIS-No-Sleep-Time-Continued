using HarmonyLib;

[HarmonyPatch(typeof(Character), "GetSleepDeprivation")]
public class Character_GetSleepDeprivation__Patch
{
	private static void Postfix(ref float __result, Character __instance)
	{
        if (__instance == null)
        {
            return;
        }

        if ((SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal) ||
			(SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && !__instance.IsOnPlayersTeam()) ||
			(__instance is Human && __instance.IsOnPlayersTeam()))
        {
			__result = 0f;
        }
    }
}
