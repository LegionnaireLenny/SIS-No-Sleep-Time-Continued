using HarmonyLib;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Xml.Serialization;

public class SISNoSleepTime_Config
{
	public static void Log(string message)
	{
		try
		{
            if (LoggingEnabled)
			{
                using (StreamWriter streamWriter = File.AppendText(LogPath))
				{
	                streamWriter.WriteLine(new string(FileLog.indentChar, FileLog.indentLevel) + $"[SISNoSleepTime] {message}");
				}
            }
        }
		catch { }
	}

	public static void Initialize()
	{
		StoryPath = GetStoryPath();
		LogPath = StoryPath + LogFilename;
		SettingsPath = StoryPath + SettingsFilename;
		ModIdentifierPath = StoryPath + ModIdentifierFilename;
	}

	private static string GetStoryPath()
	{
		foreach (Story story in GameImpl.Instance.CurrentStories)
		{
            if (File.Exists(story.Path + ModIdentifierFilename) || File.Exists(story.Path + SettingsFilename))
			{
				return story.Path;
			}
		}
		return ".";
	}

	public static void LoadSettings()
	{
		try
		{
			if (File.Exists(SettingsPath))
			{
                using (FileStream fileStream = new FileStream(SettingsPath, FileMode.Open))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(SISNoSleepTime_Settings));
                    FillSettings(xmlSerializer.Deserialize(fileStream) as SISNoSleepTime_Settings);
                }
                Log($"Loaded settings from path {SettingsPath}");
            }
			else
			{
				SISNoSleepTime_Settings @default = SISNoSleepTime_Settings.GetDefault();
				FillSettings(@default);
				Log("Loaded default settings since no settings file was found");
				SaveSettings(@default, SettingsPath);
			}
		}
		catch (Exception ex)
		{
			Log($"Error loading settings, using defaults. {ex}");
			FillSettings(SISNoSleepTime_Settings.GetDefault());
		}
	}

	private static void SaveSettings(SISNoSleepTime_Settings settings, string folderPath)
    {
        Log($"Saving to {SettingsPath}");

        if (File.Exists(SettingsPath))
        {
            File.Delete(SettingsPath);
        }

        using (FileStream fileStream = File.Create(SettingsPath))
        {
	        XmlSerializer xmlSerializer = new XmlSerializer(typeof(SISNoSleepTime_Settings));
            xmlSerializer.Serialize(fileStream, settings);
        }

        Log($"Saved settings to {SettingsPath}");
    }

    private static void FillSettings(SISNoSleepTime_Settings obj)
	{
        Log(JsonConvert.SerializeObject(obj));

        LoggingEnabled = obj.LoggingEnabled;
		EnabledForAnimals = obj.EnabledForAnimals;
		EnabledForNonPlayableCharacters = obj.EnabledForNonPlayableCharacters;
	}

	private static string StoryPath = "";
	private static string LogPath = "";
	private static string SettingsPath = "";
	private static string ModIdentifierPath = "";

	private static string LogFilename = "/Log_NoSleepTimeContinued.txt";
	private static string SettingsFilename = "/Settings_NoSleepTime.xml";
	private static string ModIdentifierFilename = "/SISNOSLEEPTIME.txt";

	public static bool LoggingEnabled;
	public static bool EnabledForAnimals;
	public static bool EnabledForNonPlayableCharacters;
}
