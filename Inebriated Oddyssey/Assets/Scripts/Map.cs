using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    // This is gonna become a get compenent of the level 1 array created in map manager 
    private GameObject[] Objects;
    // Start is called before the first frame update
    
    //this is referring to the spawn-points that are set on each map.
    private GameObject spawn;
    void Start()
    {
        Spawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawner()
    {
        Objects = GameObject.Find("Main Camera").GetComponent<MapManager>().level1Ob;
        int rand =  Random.Range(0, Objects.Length);
        Instantiate(Objects[rand], transform.position, Quaternion.identity);
        //here the spawnpoints will become unactive after they are spawned in by the function
        spawn = GameObject.FindGameObjectWithTag("Spawnpoint");
        spawn.SetActive(false);
    }
}
