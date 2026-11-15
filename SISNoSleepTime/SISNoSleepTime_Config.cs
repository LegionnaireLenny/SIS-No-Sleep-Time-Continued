using System;
using System.IO;
using System.Xml.Serialization;
using HarmonyLib;
using Newtonsoft.Json;

// Token: 0x0200000B RID: 11
public class SISNoSleepTime_Config
{
	// Token: 0x06000014 RID: 20 RVA: 0x0000231C File Offset: 0x0000051C
	public static void Log(string message)
	{
		try
		{
			bool loggingActive = SISNoSleepTime_Config.LoggingActive;
			if (loggingActive)
			{
				FileLog.Log("[SISNoSleepTime] " + message);
			}
		}
		catch
		{
		}
	}

	// Token: 0x06000015 RID: 21 RVA: 0x00002360 File Offset: 0x00000560
	private static string GetStoryPath()
	{
		foreach (Story story in GameImpl.Instance.CurrentStories)
		{
			string text = story.Path + SISNoSleepTime_Config.ModIdentifier;
			string text2 = story.Path + SISNoSleepTime_Config.SettingsFilePath;
			bool flag = File.Exists(text) || File.Exists(text2);
			if (flag)
			{
				return story.Path;
			}
		}
		return ".";
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00002404 File Offset: 0x00000604
	public static void LoadSettings()
	{
		try
		{
			bool flag = false;
			foreach (Story story in GameImpl.Instance.CurrentStories)
			{
				string text = story.Path + SISNoSleepTime_Config.SettingsFilePath;
				bool flag2 = File.Exists(text);
				if (flag2)
				{
					flag = true;
					XmlSerializer xmlSerializer = new XmlSerializer(typeof(SISNoSleepTime_Settings));
					FileStream fileStream = new FileStream(text, FileMode.Open);
					SISNoSleepTime_Settings sisnoSleepTime_Settings = (SISNoSleepTime_Settings)xmlSerializer.Deserialize(fileStream);
					fileStream.Dispose();
					SISNoSleepTime_Config.Log(JsonConvert.SerializeObject(sisnoSleepTime_Settings));
					SISNoSleepTime_Config.FillSettings(sisnoSleepTime_Settings);
					SISNoSleepTime_Config.Log("Loaded settings from path " + text);
				}
			}
			bool flag3 = !flag;
			if (flag3)
			{
				SISNoSleepTime_Settings @default = SISNoSleepTime_Settings.GetDefault();
				SISNoSleepTime_Config.FillSettings(@default);
				SISNoSleepTime_Config.Log("Loaded default settings since no settings file was found");
				SISNoSleepTime_Config.Log(JsonConvert.SerializeObject(@default));
				foreach (Story story2 in GameImpl.Instance.CurrentStories)
				{
					string text2 = story2.Path + SISNoSleepTime_Config.ModIdentifier;
					bool flag4 = File.Exists(text2);
					if (flag4)
					{
						SISNoSleepTime_Config.SaveSettings(SISNoSleepTime_Settings.GetDefault(), story2.Path);
						SISNoSleepTime_Config.Log("Saved settings file at path " + story2.Path);
					}
				}
			}
		}
		catch (Exception ex)
		{
			SISNoSleepTime_Config.Log(ex.ToString());
			SISNoSleepTime_Config.FillSettings(SISNoSleepTime_Settings.GetDefault());
			SISNoSleepTime_Config.Log("Loaded default settings since no settings file was found");
		}
	}

	// Token: 0x06000017 RID: 23 RVA: 0x00002600 File Offset: 0x00000800
	private static void SaveSettings(SISNoSleepTime_Settings settings, string folderPath)
	{
		string text = folderPath + SISNoSleepTime_Config.SettingsFilePath;
		SISNoSleepTime_Config.Log("Saving to " + text);
		bool flag = File.Exists(text);
		if (flag)
		{
			File.Delete(text);
		}
		XmlSerializer xmlSerializer = new XmlSerializer(typeof(SISNoSleepTime_Settings));
		FileStream fileStream = File.Create(text);
		xmlSerializer.Serialize(fileStream, settings);
		fileStream.Dispose();
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002668 File Offset: 0x00000868
	private static void FillSettings(SISNoSleepTime_Settings myobj)
	{
		FileLog.logPath = SISNoSleepTime_Config.GetStoryPath() + SISNoSleepTime_Config.LogFilePath;
		bool flag = File.Exists(FileLog.logPath);
		if (flag)
		{
			File.Delete(FileLog.logPath);
		}
		SISNoSleepTime_Config.EnabledForAnimals = myobj.EnabledForAnimals;
		SISNoSleepTime_Config.EnabledForNonPlayableCharacters = myobj.EnabledForNonPlayableCharacters;
	}

	// Token: 0x06000019 RID: 25 RVA: 0x000026BB File Offset: 0x000008BB
	public static void ReloadSettings()
	{
		SISNoSleepTime_Config.ResetSettings();
		SISNoSleepTime_Config.LoadSettings();
		SISNoSleepTime_Config.Log("Loaded!");
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000026D5 File Offset: 0x000008D5
	public static void ResetSettings()
	{
		SISNoSleepTime_Config.FillSettings(SISNoSleepTime_Settings.GetDefault());
	}

	// Token: 0x04000004 RID: 4
	private static bool LoggingActive = false;

	// Token: 0x04000005 RID: 5
	private static string SettingsFilePath = "/Settings_NoSleepTime.xml";

	// Token: 0x04000006 RID: 6
	private static string LogFilePath = "/log.txt";

	// Token: 0x04000007 RID: 7
	private static string ModIdentifier = "/SISNOSLEEPTIME.txt";

	// Token: 0x04000008 RID: 8
	public static bool EnabledForAnimals;

	// Token: 0x04000009 RID: 9
	public static bool EnabledForNonPlayableCharacters;
}
