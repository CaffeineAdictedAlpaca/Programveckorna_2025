using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private Slider masterSlider; // Master volume slider

    private void Start()
    {
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMasterVolume();
            SetMusicVolume();
            SetSFXVolume();
        }
    }

    public void SetMasterVolume()
    {
        float volume = Mathf.Max(0.0001f, masterSlider.value); // Avoid log10(0)
        myMixer.SetFloat("master", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("masterVolume", volume);
    }

    public void SetMusicVolume()
    {
        float volume = Mathf.Max(0.0001f, musicSlider.value);
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        float volume = Mathf.Max(0.0001f, SFXSlider.value);
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        // Load saved values
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume", 1.0f);
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume", 1.0f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1.0f);

        // Apply the saved volumes
        SetMasterVolume();
        SetMusicVolume();
        SetSFXVolume();
    }
}
