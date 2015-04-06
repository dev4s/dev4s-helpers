using System;

namespace Dev4s.Helpers
{
	//TODO: Thinking about changing this to QuickSettingsAttribute
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
	public class SettingsAttribute : Attribute {}
}
