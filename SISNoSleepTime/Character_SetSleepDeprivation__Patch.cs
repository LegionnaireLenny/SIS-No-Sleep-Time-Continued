using System;
using HarmonyLib;

// Token: 0x02000007 RID: 7
[HarmonyPatch(typeof(Character), "SetSleepDeprivation")]
public class Character_SetSleepDeprivation__Patch
{
	// Token: 0x0600000B RID: 11 RVA: 0x00002238 File Offset: 0x00000438
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
