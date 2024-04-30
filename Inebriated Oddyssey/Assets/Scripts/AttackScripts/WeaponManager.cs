using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class Weapon
{
    [HideInInspector]
    public string weaponName;
    [HideInInspector]
    public int damage;
    [HideInInspector]
    public int level;
    
    public Weapon(string _name, int _damage, int _level)
    {
        weaponName = _name;
        damage = _damage;
        level = _level;
    }
}

[System.Serializable]
public class AllWeapons
{
    public List<Weapon> Weapons;
}

public class WeaponManager : MonoBehaviour
{
    public List<GameObject> weapons = new List<GameObject>();

    void Start()
    {
        //SaveWeapons();
    }

    public void ActivateWeapon(int weapon)
    {
        if(weapons.Contains(weapons[weapon]))
        {
            weapons[weapon].SetActive(true);
        }
    }

    void SaveWeapons()
    {
        //Creates a list of new weapons
        List<Weapon> localWeapons = new List<Weapon>();
        localWeapons.Add(new Weapon("Pocket Knife", 1, 1));
        localWeapons.Add(new Weapon("Beer Bottle", 2, 2));
        localWeapons.Add(new Weapon("Molotov", 3, 3));
        localWeapons.Add(new Weapon("Fire Breath", 3, 4));
        localWeapons.Add(new Weapon("Spirit Energy", 4, 5));

        //Transfers that list info to the AllWeapons class
        AllWeapons allWeapons = new AllWeapons();
        allWeapons.Weapons = localWeapons;

        // Convert weapons to JSON
        string weaponsJson = JsonUtility.ToJson(allWeapons, true);

        // Define the file name
        string fileName = "weapons.json";
        string filePath = Directory.GetCurrentDirectory() + @"\Assets\SaveData\";

        // Combine folder path with file name
        string path = filePath + fileName;

        // Write JSON to a file
        using (StreamWriter stream = File.CreateText(path))
        {
            stream.WriteLine(weaponsJson);
            Debug.Log("Streamed");
        }


        Debug.Log("Weapons data has been saved to: " + path);
    }
}
