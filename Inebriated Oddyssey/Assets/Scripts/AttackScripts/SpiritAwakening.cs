using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritAwakening : MonoBehaviour
{
    //public float areaOfEffect = 3f;
    public LayerMask enemyLayer;
    public int spiritDamage = 1;
    EnemyDamageController enemyDamage;

    private void Start()
    {
        enemyDamage = GetComponent<EnemyDamageController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, enemyLayer);

        foreach (Collider2D ed in colliders)
        {
            EnemyDamageController enemyDamage = ed.GetComponent<EnemyDamageController>();
            if (enemyDamage != null)
            {
                enemyDamage.TakeDamage(spiritDamage);
                Debug.Log("Spirit hit enemy");
            }
        }
    }
}
