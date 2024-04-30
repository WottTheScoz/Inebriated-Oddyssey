using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;
using System.Xml.Linq;

public class SaveLevel
{
    string filePath = Directory.GetCurrentDirectory();
    string fileName = "LevelSave";

    public void SaveCurrentLevel(int level)
    {
        string saveDirectory = filePath + fileName;

        if(!Directory.Exists(saveDirectory))
        {
            using(FileStream xmlStream = File.Create(saveDirectory))
            {
                using(XmlWriter xmlWriter = XmlWriter.Create(xmlStream))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("level_progress");
                    xmlWriter.WriteElementString("level", level.ToString());
                    xmlWriter.WriteEndElement();
                }
            }
        }
    }

    public int LoadLevel()
    {
        string saveDirectory = filePath + fileName;
        
        if(Directory.Exists(saveDirectory))
        {
            // Load the XML file
            XDocument xdoc = XDocument.Load(saveDirectory);

            // Query the data and retrieve the level value
            var levelElement = xdoc.Root.Element("level_progress")?.Element("level");
            if (levelElement != null)
            {
                if (int.TryParse(levelElement.Value, out int levelValue))
                {
                    // Use 'levelValue' as needed
                    Debug.Log($"Level value: {levelValue}");
                    return levelValue;
                }
                else
                {
                    Debug.Log("Error parsing level value.");
                    return 0;
                }
            }
            else
            {
                Debug.Log("Level element not found in the XML.");
                return 0;
            }
        }
        return 0;
    }
}
