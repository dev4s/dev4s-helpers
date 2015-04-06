using System.IO;
using Dev4s.Helpers;
using NUnit.Framework;

namespace Dev4s.HelpersTests
{
	[TestFixture]
	public class FileDirectoryTests
	{
		private FileInfo _file;

		#region Tests cleanups

		[TearDown]
		public void CleanUp()
		{
			if (_file != null && _file.Exists)
			{
				_file.Delete();
				_file = null;
			}
		}

		#endregion

		[Test]
		public void CheckCreationOfEmptyFileWhenPathExists()
		{
			// Arrange
			_file = TestsExtensions.GetFileFromDefaultPath();

			// Act
			var result = FileDirectory.CreateEmptyFile(_file.FullName);

			// Assert
			Assert.That(_file.Exists, Is.True);
			Assert.That(_file.Length, Is.EqualTo(0));
			Assert.That(result, Is.True);
		}

		[Test]
		public void CheckCreationOfEmptyFileWhenPathDoesNotExists()
		{
			// Arrange
			const string notExistingPathWithFileName = "pathThatDoesNotExist\\test.txt";

			// Act
			var result = FileDirectory.CreateEmptyFile(notExistingPathWithFileName);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public void CheckCreationOfEmptyFileWhenFileDoesNotExists()
		{
			// Arrange
			var notExistingFile = TestsExtensions.Path;

			// Act
			var result = FileDirectory.CreateEmptyFile(notExistingFile);

			// Assert
			Assert.That(result, Is.False);
		}

		[Test]
		public void ReadFileToEndWhenFileExists()
		{
			// Arrange
			_file = TestsExtensions.GetFileFromDefaultPath();
			TestsExtensions.WriteSampleDataToTestFile(_file);
			var resultFromTestExt = TestsExtensions.ReadFileForTest(_file);

			// Act
			var result = FileDirectory.ReadFileToEnd(_file.FullName);

			// Assert
			Assert.That(result, Is.EqualTo(resultFromTestExt));
		}

		[Test]
		public void ReadFileToEndWhenPathDoesNotExists()
		{
			// Arrange
			const string notExistingPath = "sdfasdf\\test.xml";

			// Act
			var result = FileDirectory.ReadFileToEnd(notExistingPath);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public void ReadFileToEndWhenFileDoesNotExists()
		{
			// Arrange
			var notExistingFile = TestsExtensions.Path + "\\test.xml";

			// Act
			var result = FileDirectory.ReadFileToEnd(notExistingFile);

			// Assert
			Assert.That(result, Is.Null);
		}

		[Test]
		public void ReadFileToEndWhenFileIsEmpty()
		{
			// Arrange
			var emptyFile = TestsExtensions.GetFileFromDefaultPath().FullName;
			TestsExtensions.CreateEmptyFile(emptyFile);

			// Act
			var result = FileDirectory.ReadFileToEnd(emptyFile);

			// Assert
			Assert.That(result, Is.EqualTo(""));
		}
	}
}