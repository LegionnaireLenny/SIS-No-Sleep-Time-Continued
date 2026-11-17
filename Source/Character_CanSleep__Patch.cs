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

        if (__instance.IsOnPlayersTeam())
        {
            SISNoSleepTime_Config.Log($"Goal: {__instance?.GetGoal()?.ToString() ?? "None"} | Goal Target: {__instance?.GoalTarget?.Object?.Category?.ToString() ?? "None"}");
        }

        if (SISNoSleepTime_Config.MinDaysSleepDeprivationToSleep > 0)
        {
            if (__instance.InsideBuilding != null && !__instance.IsOutdoors() && __instance.IsSleepingOrUnconscious())
            {
                __result = __instance.SleepDeprivation > 0f;
            }
            else
            {
                __result = __result && __instance.SleepDeprivation >= Sun.DayLengthSecs * SISNoSleepTime_Config.MinDaysSleepDeprivationToSleep;
            }
        }
        else
        {
            if (SISNoSleepTime_Utils.IsCharacterExempt(__instance))
            {
                __result = false;
            }
        }
    }
}
