using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public int DamageOutput = -1;
    public float damageFlashTime = 0.2f;

    [SerializeField] int health = 3;
    [SerializeField] int scoreValue = 1; // Add a variable to store the score value

    private SpriteRenderer spriteRend;

    private DamageAnimations damageAnims = new DamageAnimations();

    public delegate void EnemyDelegate();
    public event EnemyDelegate OnDestroy;

    // Variable to store the current score
    private static int totalScore = 0;

    void Start()
    {
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        StartCoroutine(damageAnims.NormalDamage(spriteRend, damageFlashTime));

        if(health < 1)
        {
            // Increment the score when enemy is destroyed
            AddScore(scoreValue);
            OnDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

    // Method to add score
    private void AddScore(int value)
    {
        totalScore += value;
    }

    // Method to get the current score
    public static int GetScore()
    {
        return totalScore;
    }
}
