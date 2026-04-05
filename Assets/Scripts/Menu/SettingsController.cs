using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsController : MonoBehaviour
{
    public AudioMixer mainAudioMixer;
    public Slider masterSlider, musicSlider, sfxSlider, panSlider, zoomSlider;

    void Start()
    {
        float mVol = PlayerPrefs.GetFloat("MasterVolume", 0.75f); // default values back here
        float muVol = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        float sVol = PlayerPrefs.GetFloat("SFXVolume", 0.75f);
        float pSens = PlayerPrefs.GetFloat("PanSensitivity", 2000f);
        float zSens = PlayerPrefs.GetFloat("ZoomSensitivity", 3f);

        masterSlider.value = mVol;
        musicSlider.value = muVol;
        sfxSlider.value = sVol;
        panSlider.value = pSens;
        zoomSlider.value = zSens;

        // Apply to Mixer
        SetMasterVolume(mVol);
        SetMusicVolume(muVol);
        SetSFXVolume(sVol);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
        panSlider.onValueChanged.AddListener(SetPanSensitivity);
        zoomSlider.onValueChanged.AddListener(SetZoomSensitivity);
    }

    public void SetMasterVolume(float val) { ApplyVol("MasterVol", "MasterVolume", val); }
    public void SetMusicVolume(float val) { ApplyVol("MusicVol", "MusicVolume", val); }
    public void SetSFXVolume(float val) { ApplyVol("SFXVol", "SFXVolume", val); }

    private void ApplyVol(string exposedParam, string prefsKey, float val)
    {
        mainAudioMixer.SetFloat(exposedParam, Mathf.Log10(val) * 20);
        PlayerPrefs.SetFloat(prefsKey, val);
    }

    public void SetPanSensitivity(float val) { PlayerPrefs.SetFloat("PanSensitivity", val); }
    public void SetZoomSensitivity(float val) { PlayerPrefs.SetFloat("ZoomSensitivity", val); }
}