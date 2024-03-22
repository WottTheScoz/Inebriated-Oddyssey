using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    public int speed = 3;

    private Rigidbody2D ThisRB;


    // Start is called before the first frame update
    void Start()
    {
        ThisRB = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector3 position = ThisRB.position;
        position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        ThisRB.MovePosition(position);
    }
}
