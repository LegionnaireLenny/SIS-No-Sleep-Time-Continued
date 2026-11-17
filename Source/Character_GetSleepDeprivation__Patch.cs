using HarmonyLib;

[HarmonyPatch(typeof(Character), "GetSleepDeprivation")]
public class Character_GetSleepDeprivation__Patch
{
	private static void Postfix(ref float __result, Character __instance)
    {
        if (__instance == null || 
            SISNoSleepTime_Config.MinDaysSleepDeprivationToSleep > 0 ||
            !SISNoSleepTime_Utils.IsCharacterExempt(__instance))
        {
            return;
        }

        __result = 0f;
    }
}
