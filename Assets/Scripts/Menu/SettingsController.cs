using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    [Header("Audio Settings")]
    public AudioMixer mainAudioMixer;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    [Header("Camera Settings")]
    public Slider panSlider;
    public Slider zoomSlider;

    void Start()
    {
        // Load saved values or set the default values
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        panSlider.value = PlayerPrefs.GetFloat("PanSensitivity", 1f);
        zoomSlider.value = PlayerPrefs.GetFloat("ZoomSensitivity", 1f);

        // Add listeners
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        panSlider.onValueChanged.AddListener(SetPanSensitivity);
        zoomSlider.onValueChanged.AddListener(SetZoomSensitivity);
    }

    // Convert slider values to db
    public void SetMasterVolume(float sliderValue)
    {
        mainAudioMixer.SetFloat("MasterVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MasterVolume", sliderValue);
    }

    public void SetMusicVolume(float sliderValue)
    {
        mainAudioMixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("MusicVolume", sliderValue);
    }

    public void SetSFXVolume(float sliderValue)
    {
        mainAudioMixer.SetFloat("SFXVol", Mathf.Log10(sliderValue) * 20);
        PlayerPrefs.SetFloat("SFXVolume", sliderValue);
    }

    // Camera stuff
    public void SetPanSensitivity(float sliderValue)
    {
        PlayerPrefs.SetFloat("PanSensitivity", sliderValue);
    }

    public void SetZoomSensitivity(float sliderValue)
    {
        PlayerPrefs.SetFloat("ZoomSensitivity", sliderValue);
    }
}