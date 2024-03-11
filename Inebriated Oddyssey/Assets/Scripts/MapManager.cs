using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    private GameManager GM;
    private GameObject Map;
    public GameObject[] level1Ob;

    private void Awake()
    {
        GM = Map.GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelChecker();
    }

    // Update is called once per frame
    private void Update()
    {
        if (GM.isGameOver == true)
        {
            SceneManager.LoadScene("GameplayScene");
        }
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
}
