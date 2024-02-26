using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] Objects;
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
        int rand =  Random.Range(0, Objects.Length);
        Instantiate(Objects[rand], transform.position, Quaternion.identity);
        //here the spawnpoints will become unactive after they are spawned in by the function
        spawn = GameObject.FindGameObjectWithTag("Spawnpoint");
        spawn.SetActive(false);
    }
}
