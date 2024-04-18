using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RegenTimer;

    public int health = 3;
    public int maxHealth = 3;

    private float vInput;
    private float hInput;
    private float RegenTimerMax = 4;

    private Rigidbody2D _rb;

    [HideInInspector] public bool isFacingRight = true;

    public delegate void HPDelegate();
    public event HPDelegate OnRegen;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        RegenTimer = RegenTimerMax;
    }

    void Update()
    {
        // Get input
        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        // Move the player
        //Vector2 moveDirection = new Vector2(hInput, vInput);

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

        Regen();
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
        if (RegenTimer < RegenTimerMax)
        {
            RegenTimer += Time.deltaTime;
        }
        else
        {
            if (health < maxHealth)
            {
                health ++;
                OnRegen?.Invoke();
            }
            RegenTimer = 0;
        }
    }
}
