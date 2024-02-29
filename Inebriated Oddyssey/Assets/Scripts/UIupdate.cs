using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIupdate : MonoBehaviour
{

    public TMP_Text scoreText;
    public TMP_Text healthText;

    int score;
    int health;

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
        score = score + 1;
        scoreText.text = "Score: " + score;
    }

    public void TakeDamage()
    {
        //Called in Player script with an OnTriggerEnter2D void, triggers when Enemy/Enemy projectile hits Player collider
        health = health - 1;
        scoreText.text = "Health: " + health;
    }
}
