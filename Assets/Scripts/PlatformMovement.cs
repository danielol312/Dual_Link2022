using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public float movementSpeed = 2;

    void Update()
    {
        transform.position += Vector3.up * movementSpeed * Time.deltaTime;        
        DeactivatePlatform();        
    }
    private void DeactivatePlatform()
    {
        if (gameObject.transform.position.y >= 11f)
        {
            gameObject.SetActive(false);           
        }
    }
}
