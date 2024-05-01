using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    // This is gonna become a get compenent of the level 1 array created in map manager 
    public GameObject[] Objects;
    private MapManager level;
    public GameObject[] spawnPoints;


    // Start is called before the first frame update
    //this is referring to the spawn-points that are set on each map.
    
    
    void Start()
    {
        level = GameObject.FindObjectOfType<MapManager>();
        
        if (level == null)
        {
            Debug.Log("MapManager is NULL. Please go back and ensure the MapManager is loaded correctly");
        }
        else
        {
            Debug.Log("MapManager has been loaded correctly");
            IndexOutOfRange();
            level.Spawner(Objects, spawnPoints);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    void IndexOutOfRange()
    {
        try
        {
            level.Spawner(Objects, spawnPoints);
        }
        catch (System.IndexOutOfRangeException ioorException)
        {
            Debug.Log(ioorException.ToString());
        }
        finally
        {
            Debug.Log("Objects have been placed along the map");
        }
    }
}
