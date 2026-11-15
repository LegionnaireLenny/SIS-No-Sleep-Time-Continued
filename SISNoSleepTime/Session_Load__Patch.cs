using System;
using HarmonyLib;

// Token: 0x02000009 RID: 9
[HarmonyPatch(typeof(Session), "Load")]
public class Session_Load__Patch
{
	// Token: 0x06000010 RID: 16 RVA: 0x000022E0 File Offset: 0x000004E0
	private static void Finalizer(Session __instance)
	{
		SISNoSleepTime_Config.ReloadSettings();
	}
}
