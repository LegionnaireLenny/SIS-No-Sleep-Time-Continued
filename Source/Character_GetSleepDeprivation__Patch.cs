using System;
using HarmonyLib;

// Token: 0x02000006 RID: 6
[HarmonyPatch(typeof(Character), "GetSleepDeprivation")]
public class Character_GetSleepDeprivation__Patch
{
	// Token: 0x06000009 RID: 9 RVA: 0x000021DC File Offset: 0x000003DC
	private static void Postfix(ref float __result, Character __instance)
	{
		bool flag = !SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal;
		if (!flag)
		{
			bool flag2 = !SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && __instance.Community != null && __instance.Community.CommunityType > 0;
			if (!flag2)
			{
				__result = 0f;
			}
		}
	}
}
