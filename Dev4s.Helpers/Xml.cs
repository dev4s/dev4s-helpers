using System.Text;
using System.Xml;

namespace Dev4s.Helpers
{
	//TODO: IDisposable
	public class Xml
	{
		public string FullName { get; private set; }
		public bool Exists { get; private set; }

		private XmlWriter GetXmlWriter()
		{
			return new XmlTextWriter(FullName, Encoding.UTF8);
		}

		//Default behaviour
		//Default path = place where program or library are placed
		public Xml(string fileName) : this(FileDirectory.BaseDirectoryPath, fileName) {}

		public Xml(string filePath, string fileName)
		{
			//Creating full path with filename
			var fullPathAndFileName = filePath + "\\" + fileName;
			FullName = fullPathAndFileName;

			//Creating empty file in place where program or library are placed
			Exists = FileDirectory.CreateEmptyFile(fullPathAndFileName);
		}

		public void CreateBaseStructure()
		{
			//TODO: Try to change this... or do something else with it...
			//TODO: Close should be changed... or put it in other method...
			var xmlWriter = GetXmlWriter();
			xmlWriter.WriteStartDocument(true);
			xmlWriter.Close();
		}

		public void AddRootNode()
		{
			
		}

		public void AddRootNode(string nodeName)
		{
			
		}

		public void AddNode()
		{
			
		}

		public void RemoveNode()
		{
			
		}

		public void ChangeNode()
		{
			
		}

		public void ReadData()
		{
			
		}

		public void WriteData()
		{
			
		}

		public void WriteData(string nodeName, object value)
		{
			
		}
	}
}