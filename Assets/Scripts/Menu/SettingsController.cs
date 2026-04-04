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

        panSlider.value = PlayerPrefs.GetFloat("PanSensitivity", 2000f);
        zoomSlider.value = PlayerPrefs.GetFloat("ZoomSensitivity", 3f);

        // Add listeners
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

        panSlider.onValueChanged.AddListener(SetPanSensitivity);
        zoomSlider.onValueChanged.AddListener(SetZoomSensitivity);

        // Just to make the defaults work visually when the user opens settings for the first time
        // There is definitely a prettier way to do this but oh well
        float savedVol = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
        float savedmusic = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float savedSFX = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        float savedPan = PlayerPrefs.GetFloat("PanSensitivity", 2000f);
        float savedZoom = PlayerPrefs.GetFloat("ZoomSensitivity", 3f);
        masterSlider.value = savedVol;
        musicSlider.value = savedmusic;
        sfxSlider.value = savedSFX;
        panSlider.value = savedPan;
        zoomSlider.value = savedZoom;
        SetMasterVolume(savedVol);
        SetMusicVolume(savedmusic);
        SetSFXVolume(savedSFX);
        SetPanSensitivity(savedPan);
        SetZoomSensitivity(savedZoom);
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