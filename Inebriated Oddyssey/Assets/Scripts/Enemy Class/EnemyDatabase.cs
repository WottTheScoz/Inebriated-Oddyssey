using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyDatabase : ScriptableObject
{
    public EnemyClass[] Enemies;

    public int EnemyCount { get { return Enemies.Length; } }

    public EnemyClass GetEnemy(int index)
    {
        return Enemies[index];
    }
}
