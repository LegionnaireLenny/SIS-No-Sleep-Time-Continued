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
	public bool EnabledForAnimals = false;
	public bool EnabledForNonPlayableCharacters = false;
}
