using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Weapons : MonoBehaviour
{
    [HideInInspector]
    public string weaponName;
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public int level;
    
    public Weapons(string _name, int _damage, int _level)
    {
        weaponName = _name;
        damage = _damage;
        level = _level;
    }
}

public class WeaponManager : MonoBehaviour
{
    void Start()
    {
        Weapons weapon1 = new Weapons("Pocket Knife", 1, 1);
        Weapons weapon2 = new Weapons("Beer Bottle", 2, 2);
        Weapons weapon3 = new Weapons("Molotov", 3, 3);
        Weapons weapon4 = new Weapons("Fire Breath", 3, 4);
        Weapons weapon5 = new Weapons("Spirit Energy", 4, 5);

        Weapons[] weaponsArray = new Weapons[] { weapon1, weapon2, weapon3, weapon4, weapon5 };

        // Convert weapons to JSON
        string weaponsJson = JsonUtility.ToJson(weaponsArray, true);
        // Define the file name
        string fileName = "weapons.json";
        string filePath = Application.dataPath + "Assets/SaveData";
        // Combine folder path with file name
        string path = Path.Combine(filePath, fileName);

        // Write JSON to a file
        File.WriteAllText(path, weaponsJson);
        Debug.Log("JSON written to file");

        using (StreamWriter stream = File.CreateText(filePath))
        {
            stream.WriteLine(weaponsJson);
            Debug.Log("Streamed");
        }


        Debug.Log("Weapons data has been saved to: " + path);
    }
}
