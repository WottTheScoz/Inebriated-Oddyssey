using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text healthText;
    public Slider progressBar; // Reference to the progress bar UI element

    int score;
    int health;

    //For dynamic changes to enemy strength
    public int damage;

    //For dynamic changes to enemy points upon defeat
    public int enemyWorth;

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();
        scoreText.text = "Score: " + score;
        healthText.text = "Health: " + health;
        progressBar.maxValue = 5; // Set the maximum value of the progress bar to 5
        progressBar.value = 0; // Initialize the progress bar value to 0
    }

    void Update()
    {
        // Update the UI text whenever the score changes
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        // Get the current score value from the EnemyDamageController script
        int currentScore = EnemyDamageController.GetScore();

        // If the current score is greater than the previous score, update the progress bar
        if (currentScore > score)
        {
            score = currentScore;
            scoreText.text = "Score: " + score.ToString();
            // Increment the progress bar value by 1 for each score gained
            progressBar.value = score % (int)progressBar.maxValue;
        }
    }

    public void TakeDamage()
    {
        //Called in Player script with an OnTriggerEnter2D void, triggers when Enemy/Enemy projectile hits Player collider
        health -= damage;
        healthText.text = "Health: " + health;
    }
}
