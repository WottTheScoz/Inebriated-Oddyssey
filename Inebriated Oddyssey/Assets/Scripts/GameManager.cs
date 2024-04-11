using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public bool isGameOver;
    public TMP_Text healthText;
    public TMP_Text scoreText;
    private static GameManager instance;
    public PlayerController playerController;


    private void Awake()
    {
        //Checks to make sure there is only one instance of gamemanager, if one exists destroy it, otherwise initialize the instance to itself
        if (instance)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;

            DontDestroyOnLoad(this);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //pause
        //if (Input.GetKey(KeyCode.Escape))
        //{
            //Time.timeScale = 0;
        //}

        if (playerController.health <= 0)
        {
            isGameOver = true;
            Destroy(player.gameObject);
        }

        if (isGameOver == true)
        {
            Time.timeScale = 0;
        }

        UpdateScore();
    }


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("GameManager is NULL");
            }
            return instance;
        }
    }


    private void GameOver()
    {
        //if health = 0
        {
            isGameOver = true;
        }
    }

    public void PlayAudio()
    {

    }

    public void UpdateScore()
    {
        PlayerController playerController = player.GetComponent<PlayerController>();
        healthText.text = "Health: " + playerController.health.ToString();
    }

    public void NextLevel()
    {

    }
}
