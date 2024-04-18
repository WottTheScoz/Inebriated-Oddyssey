using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class MapManager : MonoBehaviour
{
    public class Level
    {
        public GameObject[] Obstacles;
        private Scene index;
        private GameObject spawn;

        //For the random level generator an Enum wouldnt be bad

        private List<string> levelNames = new List<string>()
        {
            "Level 1",
            "GameplayScene",
            "SampleScene"
        };


        //this function will serve as the initializer for the array of obstacles that every level has
        public void Spawner(GameObject[] arr)
        {
            if (Obstacles != null)
            {
                spawn = GameObject.FindGameObjectWithTag("Spawnpoint");
                int rand = Random.Range(0, arr.Length);
                Instantiate(arr[rand], spawn.transform.position, Quaternion.identity);
                //here the spawnpoints will become unactive after they are spawned in by the function
                spawn.SetActive(false);
            }
            else
            {
                Debug.Log("Obstacle Array is NULL. Please go back and ensure the obstacle array is loaded correctly");
            }

        }

        //This function will load the scene of the player
        // It is overloaded to support implementation via build index or scene name
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
        /* needs to be better optimized
        public void LoadScene(int buildIndex)
        {
            Scene currentlevel = SceneManager.GetActiveScene();


            if (currentlevel.buildIndex == buildIndex)
            {
                Debug.Log("you are already in your assigned level");
            }
            else
            {
                SceneManager.LoadScene(index.name);
            }
        }*/
    }
}
/*
 private GameManager GM;
 private GameObject Map;
 public GameObject[] level1Ob;

 private void Awake()
 {
    // GM = Map.GetComponent<GameManager>();
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
*/