using System;
using HarmonyLib;

// Token: 0x02000002 RID: 2
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
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	private static void Postfix(Character __instance, LiquidPrototype liquid, float amount, bool playSound, bool fromInfoScreen, InfectionType infectedWith)
	{
		bool flag = !SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal;
		if (!flag)
		{
			bool flag2 = !SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && __instance.Community != null && __instance.Community.CommunityType > 0;
			if (!flag2)
			{
				__instance.SleepDeprivation = 0f;
			}
		}
	}
}
