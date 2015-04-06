using Dev4s.Helpers;

namespace Dev4s.HelpersTests
{
	[Settings]
	public static class SettingsTestClass
	{
		[SettingsDefaultValue("test_string")]
		public static string StringName { get; set; }

		[SettingsDefaultValue(100)]
		public static int IntName { get; set; }

		public static string StringNameWithoutDefaultValue { get; set; }
		public static int IntNameWithoutDefaultValue { get; set; }
	}
}