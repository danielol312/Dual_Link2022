using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] AudioSource bgMusic;

    [SerializeField] LoseColliders topColliderScript, bottomColliderScript;

    bool isPaused = false;

    void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void SettingsButton()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false); settingsMenu.SetActive(false);
        bgMusic.Play();
        Time.timeScale = 1;
        isPaused = false;
    }

    public void Title()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        
        if (topColliderScript.hasLost == false && bottomColliderScript.hasLost == false)
        {
            if (isPaused == false && Time.timeScale != 0)
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    Time.timeScale = 0;
                    bgMusic.Pause();
                    pauseMenu.SetActive(true);
                    isPaused = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                {
                    pauseMenu.SetActive(false); settingsMenu.SetActive(false);
                    bgMusic.Play();
                    Time.timeScale = 1;
                    isPaused = false;
                }
            }
        }
    }
}
