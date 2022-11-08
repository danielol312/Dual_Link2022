using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] float t = 0;
    [SerializeField] float spawnDelay = 1;
    [SerializeField] GameObject[] platforms = new GameObject[4];
    [SerializeField] Score scoreScript;
    void Start()
    {
        GameObject platform = Instantiate(platforms[0]);
        platform.transform.position = transform.position;
        spawnDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreScript.score >= 30) { spawnDelay = 2.8f; }
        if (scoreScript.score >= 50) { spawnDelay = 2.5f; }
        if (scoreScript.score >= 70) { spawnDelay = 2.4f; }
        if (scoreScript.score >= 100) { spawnDelay = 2.3f; }
        if (scoreScript.score >= 200) { spawnDelay = 2.2f; }
        if (scoreScript.score >= 300) { spawnDelay = 2f; }
        if (scoreScript.score >= 600) { spawnDelay = 1.5f; }
        if (scoreScript.score >= 800) { spawnDelay = 1f; }
        if (scoreScript.score >= 1000) { spawnDelay = 0.8f; }

        if (t >= spawnDelay)
        {
            int rng = Random.Range(0, platforms.Length - 1);
            GameObject platform = Instantiate(platforms[rng]);
            platform.transform.position = transform.position;
            Destroy(platform, 10);
            t = 0;
        }
        else
        {
            t += Time.deltaTime;
        }
    }
}
