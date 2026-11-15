using System;
using HarmonyLib;

// Token: 0x02000005 RID: 5
[HarmonyPatch(typeof(Character), "Eat")]
public class Character_Eat__Patch
{
	// Token: 0x06000007 RID: 7 RVA: 0x0000217C File Offset: 0x0000037C
	private static void Postfix(Character __instance)
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
