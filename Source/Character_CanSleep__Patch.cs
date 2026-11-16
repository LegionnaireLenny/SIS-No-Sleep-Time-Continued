using System;
using HarmonyLib;

// Token: 0x02000003 RID: 3
[HarmonyPatch(typeof(Character), "CanSleep")]
public class Character_CanSleep__Patch
{
	// Token: 0x06000003 RID: 3 RVA: 0x000020BC File Offset: 0x000002BC
	private static void Postfix(ref bool __result, Character __instance)
	{
		bool flag = !SISNoSleepTime_Config.EnabledForAnimals && __instance is Animal;
		if (!flag)
		{
			bool flag2 = !SISNoSleepTime_Config.EnabledForNonPlayableCharacters && __instance is Human && __instance.Community != null && __instance.Community.CommunityType > 0;
			if (!flag2)
			{
				__result = false;
			}
		}
	}
}
