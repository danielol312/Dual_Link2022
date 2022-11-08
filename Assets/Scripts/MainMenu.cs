using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject creditsMenu;
    public GameObject titleMenu;
    public AudioMixer mixer;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Fullscreen", 0) == 0) { Screen.fullScreen = true; }
        if (PlayerPrefs.GetInt("Fullscreen", 0) == 1) { Screen.fullScreen = false; }
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume", 0));

    }
    public void Play() { SceneManager.LoadScene(1); }
    public void Quit() { Application.Quit(); }
    public void Settings()
    {
        settingsMenu.SetActive(true);
        titleMenu.SetActive(false);
    }

    public void Credits()
    {
        creditsMenu.SetActive(true);
        titleMenu.SetActive(false);
    }

}
