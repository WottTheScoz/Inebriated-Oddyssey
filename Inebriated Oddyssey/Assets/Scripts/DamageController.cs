using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    private SpriteRenderer PlayerColor;

    private float DamageFlashTime = 0.2f;
    private float IFramesTimer;
    [SerializeField]
    private float IFramesLength = 2;

    private DamageAnimations damageAnims = new DamageAnimations();

    public delegate void PlayerDamageDelegate();
    public event PlayerDamageDelegate OnChangeHealth;

    void OnCollisionStay2D(Collision2D enemy)
    {
        if (enemy.gameObject.tag.ToLower() == "enemy")
        {
            EnemyDamageController enemyDC = enemy.gameObject.GetComponent<EnemyDamageController>();
            ChangeHealth(enemyDC.DamageOutput);
            //Debug.Log("Enemy hit player");
        }
    }

    void Start()
    {
        PlayerColor = GetComponent<SpriteRenderer>();

        IFramesTimer = IFramesLength;
    }

    void Update()
    {
        //Calculates the amount of time I-Frames last.
        if(IFramesTimer < IFramesLength)
        {
            IFramesTimer += Time.deltaTime;
        }
    }

    public void ChangeHealth(int amount)
    {
        PlayerController playerController = GetComponent<PlayerController>();

        if (amount < 0 && IFramesTimer >= IFramesLength)
        {
            //Damages the player if they don't have active I-Frames.
            playerController.health += amount;
            StartCoroutine(damageAnims.NormalDamage(PlayerColor, DamageFlashTime));
            IFramesTimer = 0;
        }
        else if (amount > 0 && playerController.health < playerController.maxHealth)
        {
            //Increases the player's health if it less than the max health.
            playerController.health += amount;
        }

        //Resets the health regeneration timer when this function is called.
        playerController.RegenTimer = 0;

        //Notifies subscribers.
        OnChangeHealth?.Invoke();
    }
}
