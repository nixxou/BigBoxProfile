using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace BigBoxProfile
{
	public class ConfigurationData
	{
		public string name;
		public Dictionary<string, string> Options { get; set; }


		public static List<ConfigurationData> LoadConfigurationDataList(string filePath)
		{
			if (!File.Exists(filePath)) return new List<ConfigurationData>();
			var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(List<ConfigurationData>));

			using (var reader = XmlReader.Create(filePath))
			{
				return (List<ConfigurationData>)serializer.ReadObject(reader);
			}
		}

		public static void SaveConfigurationDataList(string filePath, List<ConfigurationData> config)
		{
			var serializer = new System.Runtime.Serialization.DataContractSerializer(typeof(List<ConfigurationData>));
			var settings = new XmlWriterSettings
			{
				Indent = true,
				IndentChars = "    "
			};
			string directoryName = Path.GetDirectoryName(filePath);


			// Create the directory if it doesn't exist
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}

			// Create the file if it doesn't exist
			if (!File.Exists(filePath))
			{
				using (var file = File.Create(filePath))
				{
					// Leave the file stream open so that the serializer can write to it
				}
			}


			using (var writer = XmlWriter.Create(filePath, settings))
			{
				serializer.WriteObject(writer, config);
			}
		}


	}


}
