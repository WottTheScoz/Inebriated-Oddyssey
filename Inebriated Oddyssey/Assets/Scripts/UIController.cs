using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text healthText;

    int score;
    int health;

    //For dynamic changes to enemy strength
    int damage;

    //For dynamic changes to enemy points upon defeat
    int enemyWorth;

    // Start is called before the first frame update
    void Start()
    {
        
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EarnScore()
    {
        //Called in Enemy script with an OnTriggerEnter2D void, triggers when projectile hits Enemy collider
        score = score + enemyWorth;
        scoreText.text = "Score: " + score;
    }

    public void TakeDamage()
    {
        //Called in Player script with an OnTriggerEnter2D void, triggers when Enemy/Enemy projectile hits Player collider
        health = health - damage;
        scoreText.text = "Health: " + health;
    }
}
