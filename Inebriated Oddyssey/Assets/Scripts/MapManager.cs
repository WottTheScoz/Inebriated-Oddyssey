using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    private GameManager GM;
    private GameObject Map;
    public GameObject[] level1Ob;

    private void Awake()
    {
        GM = Map.GetComponent<GameManager>();
        writeTXT();
        writeXML();
        writeJson();
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelChecker();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GM.isGameOver == true)
        {
            SceneManager.LoadScene("GameplayScene");
        }
    }

    private void LevelChecker()
    {
        Scene level = SceneManager.GetActiveScene();

        string levelName = level.name;
        
        if (levelName == "Level 1")
        {
            Debug.Log("your already in level 1");
        }
        else
        {
            SceneManager.LoadScene("Level 1");
        }
    }
    
    public void writeXML() {
        string xmlPath = Directory.GetCurrentDirectory() + @"\Assets\SaveData\" + "MapXML.xml";
    
        if (!File.Exists(xmlPath))
        {
            using (FileStream xmlStream = File.Create(xmlPath))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(xmlPath))
                { 
                    xmlWriter.WriteStartElement("Levels");
                    xmlWriter.WriteStartElement("Level 1");
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
                }
            }
        }
    
    }
            
    public void writeJson()
    {
        string jsonPath = Directory.GetCurrentDirectory() + @"\Assets\SaveData\" + "MapJSON.json";
        if (!File.Exists(jsonPath))
        {
            using (FileStream jsonStream = File.Create(jsonPath))
            {
                JsonUtility.ToJson("Welcome to Json");
            }
        }
    }
    
    public void writeTXT()
    {
        string path = Directory.GetCurrentDirectory() + @"\Assets\SaveData\" + "MapTXT.txt";
                
        if (!File.Exists(path))
        {
            using (StreamWriter txt = File.CreateText(path))
            {
                txt.WriteLine("This is from the Map Manager");
            }
        }
        else
        {
            using (StreamWriter txt = File.AppendText(path))
            {
                txt.WriteLine("This is from the Map Manager");
            }
        }
    }
}
