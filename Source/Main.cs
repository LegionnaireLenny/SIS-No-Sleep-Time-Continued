using System;
using HarmonyLib;

// Token: 0x02000008 RID: 8
public class Main
{
	// Token: 0x0600000D RID: 13 RVA: 0x00002298 File Offset: 0x00000498
	public static void Load()
	{
		Main.HarmonyInstance = new Harmony("SISNoSleepTime");
		Main.HarmonyInstance.PatchAll();
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000022B8 File Offset: 0x000004B8
	public static void Unload()
	{
		bool flag = Main.HarmonyInstance != null;
		if (flag)
		{
			Main.HarmonyInstance.UnpatchAll(null);
		}
	}

	// Token: 0x04000001 RID: 1
	public static Harmony HarmonyInstance;
}
