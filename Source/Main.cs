using HarmonyLib;

public class Main
{
	public static void Load()
	{
		SISNoSleepTime_Config.Initialize();
		SISNoSleepTime_Config.LoadSettings();
		HarmonyInstance = new Harmony("SISNoSleepTime");
		HarmonyInstance.PatchAll();
	}

	public static void Unload()
	{
        if (HarmonyInstance != null)
		{
			HarmonyInstance.UnpatchAll(null);
		}
	}

	public static Harmony HarmonyInstance;
}
