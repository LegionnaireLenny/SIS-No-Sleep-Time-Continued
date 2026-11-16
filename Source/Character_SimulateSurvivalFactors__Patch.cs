using System;
using HarmonyLib;

// Token: 0x02000004 RID: 4
[HarmonyPatch(typeof(Character), "SimulateSurvivalFactors")]
public class Character_SimulateSurvivalFactors__Patch
{
	// Token: 0x06000005 RID: 5 RVA: 0x00002114 File Offset: 0x00000314
	private static void Prefix(Character __instance, TimeSpan curTime, float dts)
	{
		bool flag = __instance == null;
		if (!flag)
		{
			bool flag2 = !SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal;
			if (!flag2)
			{
				bool flag3 = !SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && __instance.Community != null && __instance.Community.CommunityType > 0;
				if (!flag3)
				{
					__instance.SleepDeprivation = -dts;
				}
			}
		}
	}
}
