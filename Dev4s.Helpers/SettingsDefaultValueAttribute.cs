using System;

namespace Dev4s.Helpers
{
	//TODO: Thinking about changing this to QuickSettingsDefault
	public class SettingsDefaultValueAttribute : Attribute
	{
		public object Value { get; private set; }

		public SettingsDefaultValueAttribute(string value)
		{
			Value = value;
		}

		public SettingsDefaultValueAttribute(int value)
		{
			Value = value;
		}

		//TODO: Do for more value types
	}
}
