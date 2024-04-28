using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public int DamageOutput = -1;

    [SerializeField] int health = 3;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health < 1)
        {
            Destroy(gameObject);
        }
    }
}
