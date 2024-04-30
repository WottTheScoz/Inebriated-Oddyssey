using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    // This is gonna become a get compenent of the level 1 array created in map manager 
    public GameObject[] Objects;
    private MapManager level;


    // Start is called before the first frame update

    //this is referring to the spawn-points that are set on each map.
    private GameObject spawn;
    
    Grid grid = null;
    public Tilemap map = null;
    public Tilemap border = null;
    public Tile tile_main = null;
    public Tile tile_border = null;

    void Start()
    {
        level = GameObject.FindObjectOfType<MapManager>();
        grid = FindObjectOfType<Grid>();
        GenerateMap();
        GenerateBorder();
         
        if (level == null)
        {
            Debug.Log("MapManager is NULL. Please go back and ensure the MapManager is loaded correctly");
        }
        else
        {
            Debug.Log("MapManager has been loaded correctly");
            IndexOutOfRange();
            level.Spawner(Objects);
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
            level.Spawner(Objects);
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
    
    void GenerateMap()
    {
        for(int x = -250; x < 250; x++)
        {
            for(int y = -250; y < 250; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                map.SetTile(tilePos, tile_main);
                
            }
        }
      
    }
    
    void generateSpawner()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawnpoint");
        int rand = UnityEngine.Random.Range(0, Objects.Length);
        Instantiate(Objects[rand], spawn.transform.position, Quaternion.identity);
        spawn.SetActive(false);
    }

    void GenerateBorder()
    {
        int borderSize = 3;
        for(int x = -250 - borderSize; x < 250 + borderSize; x++)
        {
            for(int y = -250 - borderSize; y < 250 + borderSize; y++)
            {
                Vector3Int tilePos = new Vector3Int(x, y, 0);
                if(x < -250 || x >= 250 || y < -250 || y >= 250)
                {
                    border.SetTile(tilePos, tile_border);
                }
            }
        }
    }
    
    
}
