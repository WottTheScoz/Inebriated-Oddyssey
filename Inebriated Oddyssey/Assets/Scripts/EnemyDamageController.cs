using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public int DamageOutput = -1;
    public float damageFlashTime = 0.2f;

    [SerializeField] int health = 3;

    private SpriteRenderer spriteRend;

    private DamageAnimations damageAnims = new DamageAnimations();

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
            Destroy(gameObject);
        }
    }
}
