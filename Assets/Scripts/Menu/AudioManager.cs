using System.Collections; // Required for Coroutines
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // The static reference that other scripts use
    public static AudioManager instance;

    [Header("--- Audio Source ---")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--- Audio Clip ---")]
    public AudioClip backgroundMusic;
    public AudioClip click;
    public AudioClip death;
    public AudioClip quack;
    public AudioClip fireExtinguisher;

    [Header("--- Music Settings ---")]
    [SerializeField] float fadeDuration = 1.5f; // How long the fade takes
    private float maxMusicVolume; // Stores the original volume from the Inspector

    private void Awake()
    {
        // Singleton Logic
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return; // Add return to prevent the rest of Awake from running on the duplicate
        }
    }

    void Start()
    {
        // 1. Force the audio source to loop in code (bulletproof!)
        musicSource.loop = true;

        // 2. Remember the volume you set in the Inspector so we fade up to the right level
        maxMusicVolume = musicSource.volume;

        // 3. Start the music with a fade-in
        PlayMusicWithFade(backgroundMusic);
    }

    public void PlaySFX(AudioClip sound)
    {
        SFXSource.PlayOneShot(sound);
    }

    // --- NEW FADE LOGIC ---

    /// <summary>
    /// Call this from any script to smoothly change the background music!
    /// Example: AudioManager.instance.PlayMusicWithFade(AudioManager.instance.bossMusic);
    /// </summary>
    public void PlayMusicWithFade(AudioClip newClip)
    {
        // Stop any currently running fades so they don't fight each other
        StopAllCoroutines();
        StartCoroutine(FadeMusicCoroutine(newClip));
    }

    private IEnumerator FadeMusicCoroutine(AudioClip newClip)
    {
        float currentTime = 0;

        // 1. FADE OUT: If music is already playing, smoothly turn it down to 0
        if (musicSource.isPlaying)
        {
            float startVolume = musicSource.volume;

            while (currentTime < fadeDuration)
            {
                currentTime += Time.deltaTime;
                // Mathf.Lerp smoothly blends between the start volume and 0 over time
                musicSource.volume = Mathf.Lerp(startVolume, 0f, currentTime / fadeDuration);
                yield return null; // Wait for the next frame before looping again
            }
            musicSource.Stop();
        }

        // 2. SWAP TRACKS: Load the new music
        musicSource.clip = newClip;
        musicSource.volume = 0f; // Start at complete silence
        musicSource.Play();

        // 3. FADE IN: Smoothly turn it up to the max volume
        currentTime = 0;
        while (currentTime < fadeDuration)
        {
            currentTime += Time.deltaTime;
            musicSource.volume = Mathf.Lerp(0f, maxMusicVolume, currentTime / fadeDuration);
            yield return null;
        }

        // 4. SAFETY NET: Ensure volume lands exactly on the target number
        musicSource.volume = maxMusicVolume;
    }
}