using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] float t = 0;
    [SerializeField] float spawnDelay = 3;
    [SerializeField] GameObject[] platforms = new GameObject[4];
    [SerializeField] Score scoreScript;
    private float movementSpeed = 2;
    void Start()
    {
        GameObject platform = PlatformPool.Instance.RequestPlatform(2);
        platform.transform.position = transform.position;
        spawnDelay = 3f;
        t = 0;
    }
    void Update()
    {
        movementSpeed += 0.02f * Time.deltaTime;
        spawnDelay -= 0.02f * Time.deltaTime; 
        if (spawnDelay <= 0.8f)
        {
            spawnDelay = 0.8f;
        }        
        if (t >= spawnDelay)
        {
            GameObject platform = PlatformPool.Instance.RequestPlatform(movementSpeed);
            platform.transform.position = transform.position;            
            t = 0;
        }
        else
        {
            t += Time.deltaTime;
        }
    }    
}
