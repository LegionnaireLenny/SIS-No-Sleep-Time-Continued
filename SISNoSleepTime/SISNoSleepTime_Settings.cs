using System;
using System.ComponentModel;
using System.Xml.Serialization;

// Token: 0x0200000A RID: 10
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
[Serializable]
public class SISNoSleepTime_Settings
{
	// Token: 0x06000012 RID: 18 RVA: 0x000022EC File Offset: 0x000004EC
	public static SISNoSleepTime_Settings GetDefault()
	{
		return new SISNoSleepTime_Settings();
	}

	// Token: 0x04000002 RID: 2
	public bool EnabledForAnimals = false;

	// Token: 0x04000003 RID: 3
	public bool EnabledForNonPlayableCharacters = false;
}
