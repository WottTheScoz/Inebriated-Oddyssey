using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    float attackTime = 2.5f;
    float timer;

    [SerializeField] GameObject sliceLeft;
    [SerializeField] GameObject sliceRight;

    PlayerController playerController;
    [SerializeField] Vector2 KnifeAttackSize = new Vector2(4f, 2f);
    [SerializeField] int KnifeDamage = 1;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //Debug.Log("Knife Attack");
        timer = attackTime;

        if(playerController.isFacingRight == true)
        {
            sliceRight.SetActive(true);
            //cycle through all the colliders in the array
            Collider2D[] colliders = Physics2D.OverlapBoxAll(sliceRight.transform.position, KnifeAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else
        {
            sliceLeft.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(sliceLeft.transform.position, KnifeAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    public void ApplyDamage(Collider2D[] colliders)
    {
        //Detect something when it is within the colliders space
        for (int i = 0; i < colliders.Length; i++)
        {
            //if enemydamagecontroller component is present on this collider...
            EnemyDamageController e = colliders[i].GetComponent<EnemyDamageController>();
            if (e != null)
            {
                //Cycles thru all the colliders, grabs the enemydamagecontroller component, and applies the knife damage value to take damage function
                colliders[i].GetComponent<EnemyDamageController>().TakeDamage(KnifeDamage);
                //Debug.Log("Knife hit enemy");
            }
        }
    }
}
