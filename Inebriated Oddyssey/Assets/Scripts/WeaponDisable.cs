 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDisable : MonoBehaviour
{
    float DisableAfterTime = 0.6f;
    float timer;

    private void OnEnable()
    {
        timer = DisableAfterTime;
    }

    private void LateUpdate()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            //turns object off
            gameObject.SetActive(false);
        }
    }
}
