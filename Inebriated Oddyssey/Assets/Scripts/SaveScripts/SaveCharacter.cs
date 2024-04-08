using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml;

public class SaveCharacter : MonoBehaviour
{
    public CharacterDatabase CharacterDB;

    public void SaveThisCharacter(int index)
    {
        string FilePath = Directory.GetCurrentDirectory() + @"\Assets\SaveData\";

        CharacterClass characterClass = CharacterDB.Character[index];

        using(FileStream xmlStream = File.Create(FilePath + "CharacterSave"))
        {
            using(XmlWriter xmlWriter = XmlWriter.Create(xmlStream))
            {
                xmlWriter.WriteStartElement("Character");
                xmlWriter.WriteString(characterClass.CharacterName);

                xmlWriter.WriteEndElement();
            }
        }
    }
}
