using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject[] Objects;
    // Start is called before the first frame update
    void Start()
    {
        int rand =  Random.Range(0, Objects.Length);
        Instantiate(Objects[rand], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
