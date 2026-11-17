using System;
using System.ComponentModel;
using System.Xml.Serialization;

[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
[Serializable]
public class SISNoSleepTime_Settings
{
	public static SISNoSleepTime_Settings GetDefault()
	{
		return new SISNoSleepTime_Settings();
	}

	public bool LoggingEnabled = false;
	public bool EnabledForPlayer = true;
	public bool EnabledForPlayerCommunity = true;
	public bool EnabledForNonPlayableCharacters = false;
	public bool EnabledForAnimals = false;
	public float MinDaysSleepDeprivationToSleep = 0f;
	public float SleepRecoverRateMultiplier = 1f;
	public float SleepDeprivationRateMultiplier = 1f;
}
