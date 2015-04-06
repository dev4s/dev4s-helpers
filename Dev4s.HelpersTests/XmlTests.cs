using System;
using System.IO;
using Dev4s.Helpers;
using NUnit.Framework;

namespace Dev4s.HelpersTests
{
	[TestFixture]
	public class XmlTests
	{
		private FileInfo _file;
		private DirectoryInfo _directory;
		private Xml _xml;
		private const string TestFileName = "test.xml";

		#region Xml tests helpers (Not general helpers)

		private static void FileCreationAssertTests(FileInfo file, Xml xml)
		{
			Assert.That(file.Exists, Is.EqualTo(xml.Exists));
			Assert.That(file.FullName, Is.EqualTo(xml.FullName));
			Assert.That(file.Length, Is.EqualTo(0));
		}

		#endregion

		#region Tests cleanups

		[TearDown]
		public void CleanUp()
		{
			if (_file != null && _file.Exists)
			{
				_file.Delete();
				_file = null;
			}

			if (_directory != null && _directory.Exists)
			{
				_directory.Delete(true);
				_directory = null;	
			}

			_xml = null;
		}

		#endregion

		[Test]
		public void CheckIfXmlClassIsCreatingFileInDefaultPath()
		{
			// Arrange
			_file = TestsExtensions.GetFileFromDefaultPath();

			// Act
			_xml = new Xml(TestFileName);

			// Assert
			Assert.That(_xml.Exists, Is.True);
			FileCreationAssertTests(_file, _xml);
		}

		[Test]
		public void CheckIfXmlClassIsCreatingFileInSpecificPath()
		{
			// Arrange
			var testPath = AppDomain.CurrentDomain.BaseDirectory + "\\testDirectory";
			_directory = new DirectoryInfo(testPath);
			_file = new FileInfo(testPath + "\\" + TestFileName);

			_directory.Create();

			// Act
			_xml = new Xml(testPath, TestFileName);

			// Assert
			Assert.That(_xml.Exists, Is.True);
			FileCreationAssertTests(_file, _xml);
		}

		[Test]
		public void ExistsShouldBeFalseWhenBadPathIsProvided()
		{
			// Arrange
			const string testPath = "asdfasdaa\\" + TestFileName;

			// Act
			_xml = new Xml(testPath, TestFileName);

			// Assert
			Assert.That(_xml.Exists, Is.False);
		}

		//NOTE: All tests below are tested by using default path

		[Test]
		public void CheckIfXmlClassIsCreatingBaseStructure()
		{
			_xml = new Xml(TestFileName);
			_xml.CreateBaseStructure();

			var file = TestsExtensions.GetFileFromDefaultPath();

			Assert.That(_xml.Exists, Is.True);
			Assert.That(file.Length, Is.GreaterThan(0));

			

			file.Delete();
		}
	}
}