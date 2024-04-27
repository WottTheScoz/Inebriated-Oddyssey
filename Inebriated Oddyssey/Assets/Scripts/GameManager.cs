using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyType1;
    public GameObject enemyType2;
    public GameObject enemyType3;
    public GameObject enemyType4;
    public TMP_Text healthText;
    public TMP_Text scoreText;

    private static GameManager instance;

    private PlayerController playerCon;
    private DamageController playerDC;


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
        playerCon = player.GetComponent<PlayerController>();
        playerDC = player.GetComponent<DamageController>();

        //Calls UpdateHealth to display HP on start.
        UpdateHealth();

        //Assigning listeners.
        playerDC.OnChangeHealth += UpdateHealth;
        playerDC.OnChangeHealth += GameOver;

        playerCon.OnRegen += UpdateHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //pause
        //if (Input.GetKey(KeyCode.Escape))
        //{
            //Time.timeScale = 0;
        //}

        //UpdateScore();
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
        if(playerCon.health <= 0)
        {
            Time.timeScale = 0;
            Destroy(player);

            //Unsubscribes listener.
            playerDC.OnChangeHealth -= GameOver;
        }
    }

    public void PlayAudio()
    {

    }

    public void UpdateHealth()
    {
        healthText.text = "Health: " + playerCon.health.ToString();

        if(playerCon.health <= 0)
        {
            //Unsubscribes listener.
            playerDC.OnChangeHealth -= UpdateHealth;
            playerCon.OnRegen -= UpdateHealth;
        }
    }

    public void NextLevel()
    {

    }
}
