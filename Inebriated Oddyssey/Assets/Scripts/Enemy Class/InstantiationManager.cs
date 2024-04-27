using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    private int enemyCount = 0;
    public int maxEnemyCount = 10;

    public float maxTimer = 10;

    private GenericTimer enemyTimer = new GenericTimer();

    void Update()
    {
        CreateEnemyOnTimer();
    }

    void CreateRandomEnemy()
    {
        //Instantiates a random enemy from the enemy list.
        int RNG = Random.Range(0, enemyList.Count);
        GameObject newEnemy = Instantiate(enemyList[RNG], new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), Quaternion.identity);

        //Notifies ReduceEnemyCount when the enemy is destroyed.
        EnemyDamageController enemyDC = newEnemy.GetComponent<EnemyDamageController>();
        enemyDC.OnDestroy += ReduceEnemyCount;

        //Increases enemy count.
        enemyCount++;
    }

    void CreateEnemyOnTimer()
    {
        string timerStatus = enemyTimer.Timer(maxTimer);
        if(enemyCount < maxEnemyCount)
        {
            if(timerStatus == "complete")
            {
                CreateRandomEnemy();
            }
        }
    }

    void ReduceEnemyCount()
    {
        enemyCount--;
        //Debug.Log("Amount of on-screen enemies: " + enemyCount);
    }
}
