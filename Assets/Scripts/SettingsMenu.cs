using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject previousMenu;
    public Slider volumeSlider;
    public TMP_Dropdown resDropdown;
    public Toggle fsCheck;

    Resolution[] resolutions;

    private void Awake()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> resOptions = new List<string>();

        if (PlayerPrefs.GetInt("Fullscreen", 0) == 0) { fsCheck.isOn = true; } // 0 Fullscreen, 1 Windowed
        else { fsCheck.isOn = false; }

        int currentResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            resOptions.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResIndex;
        resDropdown.RefreshShownValue();

        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0);
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume", 0));
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        mixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen) { PlayerPrefs.SetInt("Fullscreen", 0); } // 0 Fullscreen, 1 Windowed
        else { PlayerPrefs.SetInt("Fullscreen", 1); }

        Screen.fullScreen = isFullscreen;
    }

    public void Back()
    {
        previousMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
