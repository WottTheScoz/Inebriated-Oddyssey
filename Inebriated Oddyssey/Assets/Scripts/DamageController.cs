using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public SpriteRenderer PlayerColor;

    private float DamageFlashTime = 0.2f;

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController Health = this.GetComponent<PlayerController>();

        //Makes the player flash red when hit by an enemy.
        if (col.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageAnim(PlayerColor));
            Health.health -= 1;
            Debug.Log("Health Remaining: " + Health.health);
        }
    }

    //Makes a sprite flash red.
    IEnumerator DamageAnim(SpriteRenderer sprite)
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(DamageFlashTime);
        sprite.color = Color.white;
    }
}
