using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed = 2;
    

    void Update()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;
        if (PlayerPrefs.GetInt("Score", 0) >= 100) { movementSpeed = 2.2f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 200) { movementSpeed = 2.4f; }        
        if (PlayerPrefs.GetInt("Score", 0) >= 300) { movementSpeed = 2.6f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 400) { movementSpeed = 2.8f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 500) { movementSpeed = 3.0f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 600) { movementSpeed = 3.2f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 700) { movementSpeed = 3.4f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 800) { movementSpeed = 3.6f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 900) { movementSpeed = 3.8f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 1000) { movementSpeed = 4f; }
    }
}
