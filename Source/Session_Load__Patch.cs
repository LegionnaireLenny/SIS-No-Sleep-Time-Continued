using HarmonyLib;

[HarmonyPatch(typeof(Session), "Load")]
public class Session_Load__Patch
{
	private static bool IsFirstLoad = true;
	private static void Finalizer(Session __instance)
	{
		if (IsFirstLoad)
		{
			IsFirstLoad = false;
			return;
		}
		SISNoSleepTime_Config.LoadSettings();
	}
}
