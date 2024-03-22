using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    private SpriteRenderer PlayerColor;
    private BoxCollider2D PlayerCollider;

    private float DamageFlashTime = 0.2f;
    private float IFramesTimer;
    [SerializeField]
    private float IFramesLength = 2;

    void Start()
    {
        PlayerColor = GetComponent<SpriteRenderer>();
        PlayerCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        //Calculates the amount of time I-Frames last.
        if(IFramesTimer < IFramesLength)
        {
            PlayerCollider.enabled = false;
            IFramesTimer += Time.deltaTime;
        }
        else
        {
            PlayerCollider.enabled = true;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        PlayerController Health = GetComponent<PlayerController>();

        //Makes the player flash red and lose health when hit by an enemy.
        if (col.gameObject.tag == "Enemy" && IFramesTimer >= IFramesLength)
        {
            StartCoroutine(DamageAnim(PlayerColor));

            Health.health -= 1;

            IFramesTimer = 0;

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
