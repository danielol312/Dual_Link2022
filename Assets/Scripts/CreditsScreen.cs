using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsScreen : MonoBehaviour
{
    [SerializeField] GameObject previousScreen;
    
    public void Back()
    {
        previousScreen.SetActive(true);
        gameObject.SetActive(false);
    }
}
