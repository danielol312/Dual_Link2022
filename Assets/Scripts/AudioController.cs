using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource bgMusic;
    public AudioMixer mixer;
    public Slider volumeSlider;

    void Awake()
    {
        bgMusic.pitch = 0.6f;
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0);
        mixer.SetFloat("volume", PlayerPrefs.GetFloat("Volume", 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Score", 0) < 300) { bgMusic.pitch = 0.6f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 300 && bgMusic.pitch >= 0.6f) { bgMusic.pitch = 0.8f; }
        if (PlayerPrefs.GetInt("Score", 0) >= 500 && bgMusic.pitch >= 0.8f) { bgMusic.pitch = 1f; }
    }
}
