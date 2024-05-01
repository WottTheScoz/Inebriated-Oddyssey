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
    
    

    private List<string> levelNames = new List<string>()
    {
        "Level 1",
        "GameplayScene",
        "SampleScene"
    };


    //this function will serve as the initializer for the array of obstacles that every level has
    public void Spawner(GameObject[] arr, GameObject[] spawnPoints)
    {
        int randSpawn = UnityEngine.Random.Range(12, spawnPoints.Length);
        
        for(int i = 0; i < randSpawn; i++)
        {
            int randPoint = UnityEngine.Random.Range(0, spawnPoints.Length);
            
            Collider2D hitCollider = Physics2D.OverlapCircle(spawnPoints[randPoint].transform.position, 0.1f);
            if (hitCollider != null)
            {
                // If the spawn point is occupied, skip to the next iteration
                continue;
            }
            
            int rand = UnityEngine.Random.Range(0, arr.Length);
            Instantiate(arr[rand], spawnPoints[randPoint].transform.position, Quaternion.identity);
            spawnPoints[randPoint].SetActive(false);
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
