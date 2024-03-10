using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateUFO : MonoBehaviour
{
    public EnemyDatabase EnemyDB;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("g"))
        {
            EnemyClass Enemy = EnemyDB.GetEnemy(0);
            Instantiate(Enemy.EnemyPrefab);
        }
    }
}
