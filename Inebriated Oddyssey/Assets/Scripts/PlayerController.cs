using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;

    public int health = 3;
    public int maxHealth = 3;

    private float vInput;
    private float hInput;
    private float RegenTimer;
    private float RegenTimerMax = 4;

    private Rigidbody2D _rb;

    private bool isFacingRight = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input
        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        // Move the player
        Vector2 moveDirection = new Vector2(hInput, vInput);

        // Flip the sprite if changing direction
        if ((isFacingRight && hInput < 0) || (!isFacingRight && hInput > 0))
        {
            Flip();
        }
    }

    void FixedUpdate()
    {
        Vector2 position = _rb.position;
        position.x = position.x + MoveSpeed * hInput * Time.deltaTime;
        position.y = position.y + MoveSpeed * vInput * Time.deltaTime;

        _rb.MovePosition(position);

        if(RegenTimer < RegenTimerMax)
        {
            RegenTimer += Time.deltaTime;
        }
        else
        {
            Regen();
            RegenTimer = 0;
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void Regen()
    {
        if (health < maxHealth)
        {
            /* pointer error, holding for now
            health += * Time.deltaTime; */

            health ++;
            Debug.Log("Health Remaining: " + health);
            //very basic rn, putting method in fixedupdate for deltatime iirc. this might work honestly (delete comment later)
        }
    }
}
