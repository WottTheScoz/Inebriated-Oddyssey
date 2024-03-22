using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageController : MonoBehaviour
{
    public int DamageOutput = -1;

    void OnCollisionEnter2D(Collision2D player)
    {
        DamageController damageController = player.gameObject.GetComponent<DamageController>();

        if (damageController != null)
        {
            damageController.ChangeHealth(DamageOutput);
            //Debug.Log("It worked.");
        }
    }
}
