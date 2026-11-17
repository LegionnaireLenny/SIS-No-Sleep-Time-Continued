using HarmonyLib;

[HarmonyPatch(typeof(Character), "SetSleepDeprivation")]
public class Character_SetSleepDeprivation__Patch
{
	private static void Postfix(Character __instance)
    {
        if (__instance == null ||
            SISNoSleepTime_Config.MinDaysSleepDeprivationToSleep > 0 ||
            !SISNoSleepTime_Utils.IsCharacterExempt(__instance))
        {
            return;
        }

        __instance.SleepDeprivation = 0f;
    }
}
