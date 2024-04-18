using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public int speed = 3;

    private Vector3 lastPosition;
    //private Vector3 direction;

    public float lastDirection = 1;

    private Rigidbody2D ThisRB;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        ThisRB = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - lastPosition;
        direction.Normalize();
        animator.SetFloat("Move X", direction.x);
        lastPosition = currentPosition;
    }

    void FixedUpdate()
    {
        Vector3 position = ThisRB.position;
        position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        ThisRB.MovePosition(position);
    }
}
