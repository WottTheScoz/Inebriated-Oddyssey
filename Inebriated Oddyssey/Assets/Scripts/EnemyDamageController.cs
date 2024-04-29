using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public int DamageOutput = -1;
    public float damageFlashTime = 0.2f;

    int expAmount = 10;

    [SerializeField] int health = 3;

    private SpriteRenderer spriteRend;

    private DamageAnimations damageAnims = new DamageAnimations();

    public delegate void EnemyDelegate();
    public event EnemyDelegate OnDestroy;

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
            OnDestroy?.Invoke();
            Destroy(gameObject);
            ExperienceManager.Instance.AddExperience(expAmount);
        }
    }
}
