using HarmonyLib;

[HarmonyPatch(typeof(Character), "CanSleep")]
public class Character_CanSleep__Patch
{
	private static void Postfix(ref bool __result, Character __instance)
    {
        if (__instance == null)
        {
            return;
        }

        if ((SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal) ||
            (SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && !__instance.IsOnPlayersTeam()) ||
            (__instance is Human && __instance.IsOnPlayersTeam()))
        {
            __result = false;
        }
    }
}
