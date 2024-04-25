using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiationManager : MonoBehaviour
{
    public List<GameObject> enemyList = new List<GameObject>();

    private int enemyCount = 0;
    private int enemyMaxCount = 10;

    private float timer = 10;
    private float maxTimer;

    void Start()
    {
        maxTimer = timer;
        timer = 0;
    }

    void Update()
    {
        CreateEnemyOnTimer();
    }

    void CreateRandomEnemy()
    {
        int RNG = Random.Range(0, enemyList.Count);
        Instantiate(enemyList[RNG], new Vector3(Random.Range(0, 10), Random.Range(0, 10), 0), Quaternion.identity);
        enemyCount++;
    }

    void CreateEnemyOnTimer()
    {
        if(enemyCount < enemyMaxCount)
        {
            if(timer >= maxTimer)
            {
                CreateRandomEnemy();
                timer = 0;
            }
            else
            {
                timer += Time.deltaTime;
            }
        }
    }
}
