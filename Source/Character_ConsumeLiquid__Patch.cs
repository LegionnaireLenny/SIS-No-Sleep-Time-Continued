using HarmonyLib;
using System;

[HarmonyPatch(typeof(Character), "ConsumeLiquid", new Type[]
{
	typeof(LiquidPrototype),
	typeof(float),
	typeof(bool),
	typeof(bool),
	typeof(InfectionType)
}, new ArgumentType[]
{
	ArgumentType.Normal,
	ArgumentType.Normal,
	ArgumentType.Normal,
	ArgumentType.Normal,
	ArgumentType.Normal
})]
public class Character_ConsumeLiquid__Patch
{
	private static void Postfix(Character __instance, LiquidPrototype liquid, float amount, bool playSound, bool fromInfoScreen, InfectionType infectedWith)
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
