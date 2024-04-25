using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectileObj;

    [HideInInspector] public int direction;

    //public delegate void LaunchDelegate(int direction);
    //public event LaunchDelegate OnLaunch;

    //private Projectile projectile;

    // Start is called before the first frame update
    void Start()
    {
        //projectile = projectileObj.GetComponent<Projectile>();
    }

    public void CreateProjectiles(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject clone = Instantiate(projectileObj, gameObject.transform);
            direction = i;
            Projectile projectile = clone.GetComponent<Projectile>();
            projectile.GetDirection(i);
            //OnLaunch?.Invoke(direction);
        }
    }
}
