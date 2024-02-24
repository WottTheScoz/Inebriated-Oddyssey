using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;
    private Rigidbody2D _rb;
    private bool isFacingRight = true;
    public int health = 3;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Get input
        float vInput = Input.GetAxisRaw("Vertical");
        float hInput = Input.GetAxisRaw("Horizontal");

        // Move the player
        Vector2 moveDirection = new Vector2(hInput, vInput).normalized;
        _rb.velocity = moveDirection * MoveSpeed * Time.fixedDeltaTime;

        // Rotate the player
        float rotation = -hInput * RotateSpeed * Time.fixedDeltaTime;
        _rb.MoveRotation(_rb.rotation + rotation);

        // Flip the sprite if changing direction
        if ((isFacingRight && hInput < 0) || (!isFacingRight && hInput > 0))
        {
            Flip();
        }
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
