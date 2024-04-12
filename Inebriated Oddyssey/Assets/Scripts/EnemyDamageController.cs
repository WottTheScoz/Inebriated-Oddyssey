using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public int DamageOutput = -1;

    [SerializeField] int health = 3;

    //Enemy dealing damage to player, moved to DamageController
    /*void OnCollisionStay2D(Collision2D player)
    {
        DamageController damageController = player.gameObject.GetComponent<DamageController>();

        if (damageController != null)
        {
            damageController.ChangeHealth(DamageOutput);
            Debug.Log("Enemy hit player");
        }
    }*/

    private void Attack()
    {

    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health < 1)
        {
            Destroy(gameObject);
        }
    }
}
