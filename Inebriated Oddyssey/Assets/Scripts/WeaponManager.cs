using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class WeaponManager : MonoBehaviour
{

    public Weapon() 
    { 
        public string name;
        public int damage;
        public int level;
    }

    public List<Weapon> weaponInventory = new List<Weapon>
    {
    new Weapon("Knife", 1, 1),
    new Weapon("Beer Bottle", 2, 2),
    new Weapon("Molotov", 2, 3),
    new Weapon("Fire Breath", 2, 4),
    new Weapon("Spirit Energy", 3, 5)
    };



    void WeaponsToJSON(string name, int damage, int level)
    {
    //_jsonWeapons = _dataPath + "WeaponJSON.json";

    string _jsonString = JsonUtility.ToJson(weaponInventory, true);

    //Weapon Knife = new Weapon("Pocket Knife", 1, 1);
    //string knifeString = JsonUtility.ToJson(Knife, true); //true = upkeep indentation
    //Weapon BeerBottle = new Weapon("Beer Bottle", 2, 2);
    //string beerString = JsonUtility.ToJson(BeerBottle, true); //true = upkeep indentation
    //Weapon Molotov = new Weapon("Molotov", 3, 3);
    //string molotovString = JsonUtility.ToJson(Molotov, true); //true = upkeep indentation
    //Weapon FireBreath = new Weapon("Fire Breath", 3, 4);
    //string fireBreathString = JsonUtility.ToJson(FireBreath, true); //true = upkeep indentation
    //Weapon SpiritEnergy = new Weapon("Spirit Energy", 3, 5);
    //string spiritEnergyString = JsonUtility.ToJson(SpiritEnergy, true); //true = upkeep indentation

    using(StreamWriter stream = File.CreateText(_jsonString))
        {
            stream.WriteLine(_jsonString);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
