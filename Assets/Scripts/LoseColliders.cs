using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseColliders : MonoBehaviour
{
    [SerializeField] GameObject loseScreen;
    [SerializeField] AudioSource bgMusic;
    [SerializeField] ParticleSystem deathPS;
    public bool hasLost;

    void Awake()
    {
        loseScreen.SetActive(false);
        hasLost = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            hasLost = true;
            bgMusic.Stop();
            loseScreen.SetActive(true);
            Time.timeScale = 0;
            deathPS.transform.position = collision.transform.position;
            deathPS.Play();
        }
    }
}
