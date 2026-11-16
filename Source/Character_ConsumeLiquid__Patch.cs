using System;
using HarmonyLib;

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
