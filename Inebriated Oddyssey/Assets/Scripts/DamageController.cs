using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public SpriteRenderer PlayerColor;

    private float DamageFlashTime = 0.2f;

    void OnCollisionEnter2D(Collision2D col)
    {
        PlayerController Health = this.GetComponent<PlayerController>();

        //Makes the player flash red when hit by an enemy.
        if (col.gameObject.tag == "Enemy")
        {
            StartCoroutine(DamageAnim(PlayerColor));
            Health.health -= 1;
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
