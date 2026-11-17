using HarmonyLib;
using System;

[HarmonyPatch(typeof(Character), "SimulateSurvivalFactors")]
public class Character_SimulateSurvivalFactors__Patch
{
	private static void Prefix(Character __instance, TimeSpan curTime, float dts)
    {
        if (__instance == null)
        {
            return;
        }

        if (SISNoSleepTime_Config.MinDaysSleepDeprivationToSleep > 0)
        {
            if (__instance.IsSleepingOrUnconscious())
            {
                __instance.SleepDeprivation -= dts * Character.SleepRecoverRate * (SISNoSleepTime_Config.SleepRecoverRateMultiplier - 1);
            }
            else if (!__instance.Zombie && 
                    !__instance.DontSimulateSurvivalFactorsUntilJoinCommunity && 
                    !__instance.DontSimulateSurvivalFactorsUntilDiscovered && 
                    __instance.ScriptedGoalMarker == null && 
                    (!__instance.CanFollowPlayer || __instance.IsControllableByPlayer() || __instance.SquadLeader == null || !__instance.SquadLeader.IsControllableByPlayer()) && 
                    !__instance.IsAmbient())
            {
                __instance.SleepDeprivation += dts * (SISNoSleepTime_Config.SleepDeprivationRateMultiplier - 1);
            }
        }
        else
        {
            if (SISNoSleepTime_Utils.IsCharacterExempt(__instance))
            {
                __instance.SleepDeprivation = 0f;
            }
        }
    }
}
