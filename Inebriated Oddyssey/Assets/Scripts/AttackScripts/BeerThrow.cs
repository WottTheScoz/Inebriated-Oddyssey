using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerThrow : MonoBehaviour
{
    float attackTime = 3f;
    float timer;

    public GameObject beerPrefab;

    PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < attackTime)
        {
            timer += Time.deltaTime;
            return;
        }

        timer = 0;
        SpawnBeer();
    }


    void SpawnBeer()
    {
        GameObject beerBottle = Instantiate(beerPrefab);
        beerBottle.transform.position = transform.position;

        //if facing right shoot right, otherwise shoot left
        if (playerController.isFacingRight == true)
        {
            beerBottle.GetComponent<BeerProjectile>().SetDirection(1f, 0f);
        }
        else
        {
            beerBottle.GetComponent<BeerProjectile>().SetDirection(-1f, 0f);
        }
    }
}
