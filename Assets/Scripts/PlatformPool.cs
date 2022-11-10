using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPool : MonoBehaviour
{
    [SerializeField] float t = 0;
    [SerializeField] float spawnDelay = 1;
    [SerializeField] GameObject[] platforms = new GameObject[4];
    [SerializeField] private int poolSize = 20;
    [SerializeField] private List<GameObject> platformList;
    
    private static PlatformPool instance;
    public static PlatformPool Instance { get{ return instance; } }

    [SerializeField] Score scoreScript;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
        AddPlatformsToPool(poolSize);
    }   
    private void AddPlatformsToPool(int amount)
    {
        for (int i = 0; i < poolSize; i++)
        {
            int rng = Random.Range(0, platforms.Length);
            GameObject plataform = Instantiate(platforms[rng]);
            plataform.SetActive(false);
            platformList.Add(plataform);
            plataform.transform.parent = transform;
        }
    }
    public GameObject RequestPlatform(float speed)
    {
        
        for (int i = 0; i < platformList.Count ; i++)
        {
            if (!platformList[i].activeSelf)
            {
                platformList[i].SetActive(true);
                platformList[i].GetComponent<PlatformMovement>().movementSpeed = speed;
                return platformList[i];
            }
        }
        return null;
    }         
}
