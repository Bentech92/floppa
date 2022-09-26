using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;

namespace AkshayDhotre.GraphicSettingsMenu
{
	public static class XmlManager<T>
	{
		public static void Save(T obj, string directoryPath, string fileName)
		{
			if (!Directory.Exists(directoryPath))
			{
				Directory.CreateDirectory(directoryPath);
				return;
			}
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			FileStream fileStream = new FileStream(directoryPath + fileName, FileMode.Create);
			xmlSerializer.Serialize(fileStream, obj);
			fileStream.Close();
		}

		public static T Load(string path, T defaultT)
		{
			T result = defaultT;
			if (!string.IsNullOrEmpty(path))
			{
				FileStream fileStream = new FileStream(path, FileMode.Open);
				XmlReader xmlReader = XmlReader.Create(fileStream);
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				if (xmlSerializer.CanDeserialize(xmlReader))
				{
					try
					{
						result = (T)xmlSerializer.Deserialize(xmlReader);
					}
					catch
					{
						result = defaultT;
						Debug.LogError("File in path : " + path + ", contains invalid data");
					}
				}
				fileStream.Close();
			}
			return result;
		}

		public static bool FileExists(string path)
		{
			if (File.Exists(path))
			{
				return true;
			}
			return false;
		}
	}
}
