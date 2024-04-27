using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f;
    public float RegenTimer;

    public int health = 3;
    [HideInInspector]public int maxHealth = 3;

    public float vInput;
    public float hInput;
    private float RegenTimerMax = 4;

    private Vector2 lookDirection = new Vector2(1,0);

    private Rigidbody2D _rb;
    private Animator animator;

    [HideInInspector] public bool isFacingRight = true;

    public delegate void HPDelegate();
    public event HPDelegate OnRegen;

    void Start()
    {
        maxHealth = health;

        _rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        RegenTimer = RegenTimerMax;
    }

    void Update()
    {
        // Get input
        vInput = Input.GetAxisRaw("Vertical");
        hInput = Input.GetAxisRaw("Horizontal");

        Vector2 move = new Vector2(hInput, vInput);

        if(!Mathf.Approximately(move.x, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }

        animator.SetFloat("Look X", lookDirection.x);
        animator.SetFloat("Speed", move.magnitude);

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
