using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapManager : MonoBehaviour
{
    private Scene index;
    private GameObject spawn;
    

    private List<string> levelNames = new List<string>()
    {
        "Level 1",
        "GameplayScene",
        "SampleScene"
    };


    //this function will serve as the initializer for the array of obstacles that every level has
    public void Spawner(GameObject[] arr)
    {
        if (arr != null)
        {
            spawn = GameObject.FindGameObjectWithTag("Spawnpoint");
            int rand = UnityEngine.Random.Range(0, arr.Length);
            Instantiate(arr[rand], spawn.transform.position, Quaternion.identity);
            //here the spawnpoints will become unactive after they are spawned in by the function
            spawn.SetActive(false);
        }
        else
        {
            Debug.Log("Obstacle Array is NULL. Please go back and ensure the obstacle array is loaded correctly");
        }

    }
    
    
    public void LoadScene(string scene)
    {
            

        if (levelNames.Contains(scene))
        {
            SceneManager.LoadScene(scene);
        }
        else
        {
            Debug.Log("The Scene that you are trying to load doesnt exist");
        }
    }

    public void LoadScene(int buildIndex)
    {
        if (SceneManager.GetActiveScene().buildIndex == buildIndex)
        {
            Debug.Log("you are already in the level 1 Scene");
        }
        else
        {
            SceneManager.LoadScene(buildIndex);
        }
    }

    public void GenerateGrid()
    {
        
    }

    
    public void writeXML() {
        string xmlPath = Directory.GetCurrentDirectory() + @"\Assets\SaveData\" + "MapXML.xml";
    
        if (!File.Exists(xmlPath))
        {
            
                using (XmlWriter xmlWriter = XmlWriter.Create(xmlPath))
                { 
                    xmlWriter.WriteStartElement("Levels");
                    xmlWriter.WriteString("Level 1");
                    xmlWriter.WriteEndElement();
                    xmlWriter.Close();
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
