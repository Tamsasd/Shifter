using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Use like so: AudioManager.instance.PlaySFX(AudioManager.instance.death);

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

    private void Awake()
    {
        // Singleton Logic: Ensure only one AudioManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep this object alive between scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicates if we return to the Main Menu
        }
    }

    void Start()
    {
        musicSource.clip = backgroundMusic;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip sound)
    {
        SFXSource.PlayOneShot(sound);
    }
}