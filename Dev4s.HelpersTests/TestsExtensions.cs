using System;
using System.IO;

namespace Dev4s.HelpersTests
{
	// This are the "extensions" used only for tests
	public static class TestsExtensions
	{
		private const string TestFileName = "test.xml";
		private const string SampleData = "test1\r\ntest2\r\n\test3";
		public static readonly string Path = AppDomain.CurrentDomain.BaseDirectory;

		public static object[] GetAttributesFromProperties(Type classWithProperties, string propertyName)
		{
			var property = classWithProperties.GetProperty(propertyName);
			return property.GetCustomAttributes(false);
		}

		public static FileInfo GetFileFromDefaultPath()
		{
			return new FileInfo(Path + "\\" + TestFileName);
		}

		public static string ReadFileForTest(FileInfo file)
		{
			var fileStream = file.OpenRead();
			using (var stream = new StreamReader(fileStream))
			{
				return stream.ReadToEnd();
			}
		}

		public static void WriteSampleDataToTestFile(FileInfo file)
		{
			var fileStream = file.OpenWrite();
			using (var stream = new StreamWriter(fileStream))
			{
				stream.Write(SampleData);
			}
		}

		public static void CreateEmptyFile(string pathAndFileName)
		{
			using (File.Create(pathAndFileName)) { }
		}
	}
}