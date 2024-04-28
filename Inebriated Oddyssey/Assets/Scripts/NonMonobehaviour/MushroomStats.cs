using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomStats : DefaultEnemyStats
{
    public MushroomStats()
    {
        // Override the default value of projectileAmount to 3
        projectileAmount = 3;
    }
}