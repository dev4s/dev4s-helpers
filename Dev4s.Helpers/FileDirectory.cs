using System;
using System.IO;

namespace Dev4s.Helpers
{
	public static class FileDirectory
	{
		// It's a place where are all files putted
		public static readonly string BaseDirectoryPath = AppDomain.CurrentDomain.BaseDirectory;

		// It creates empty file based on full path and it's filename
		public static bool CreateEmptyFile(string fullPathAndFileName)
		{
			try
			{
				using (File.Create(fullPathAndFileName)) 
				{
					//NOTE: we are creating a new file. "using" is for automatic dispose of this...
				}
				return true;
			}
			catch(DirectoryNotFoundException)
			{
				return false;
			}
			catch(UnauthorizedAccessException)
			{
				return false;
			}
		}

		// It reads file to end and returns a string of it
		public static string ReadFileToEnd(string fullPathAndFileName)
		{
			try
			{
				// Opening file for read with specified path and filename
				var fileStream = File.OpenRead(fullPathAndFileName);

				// Opening stream for reading
				using (var stream = new StreamReader(fileStream))
				{
					return stream.ReadToEnd();
				}
			}
			catch (DirectoryNotFoundException)
			{
				return null;
			}
			catch(FileNotFoundException)
			{
				return null;
			}
		}
	}
}
