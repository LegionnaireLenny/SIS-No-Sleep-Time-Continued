using System;
using HarmonyLib;

[HarmonyPatch(typeof(Character), "SimulateSurvivalFactors")]
public class Character_SimulateSurvivalFactors__Patch
{
	private static void Prefix(Character __instance, TimeSpan curTime, float dts)
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
