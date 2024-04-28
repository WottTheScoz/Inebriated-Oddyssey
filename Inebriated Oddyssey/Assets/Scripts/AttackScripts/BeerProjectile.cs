using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerProjectile : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] float speed;
    [SerializeField] int beerDamage = 1;


    Rigidbody2D rgbd;

    public void Awake()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(float dir_x, float dir_y)
    {
        direction = new Vector3(dir_x, dir_y);
        //if horizontal movement is to the left, flip the sprite
        if (dir_x < 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += speed * Time.deltaTime * direction;

        //objects size and location of collider
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
        //detects an enemydamagecontrollerscript when it hits something and if so does damage and destroys projectile
        foreach (Collider2D ed in hit)
        {
            EnemyDamageController enemyDamage = ed.GetComponent<EnemyDamageController>();
            if (enemyDamage != null)
            {
                enemyDamage.TakeDamage(beerDamage);
                Destroy(gameObject);
                Debug.Log("Beer hit enemy");
            }
        }

        //if object flies 100 units destroy itself
        if (transform.position.magnitude > 100.0f)
        {
            Destroy(gameObject);
        }
    }
}
