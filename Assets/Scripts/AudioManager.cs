using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Audio Sources")]
    public AudioSource SFXSource;      // For playing sound effects
    public AudioSource MusicSource;    // For playing background music

    [Header("Audio Clips")]
    public AudioClip swooshSFX;        // Assign in the Inspector
    public AudioClip backgroundMusic;  // Assign in the Inspector

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Keep AudioManager persistent across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(); // Start background music when game begins
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);  // Plays sound effect without interrupting other sounds
    }

    public void PlayMusic()
    {
        Debug.Log("Trying to play music...");

        if (MusicSource == null)
        {
            Debug.LogError("No AudioSource found!");
            return;
        }

        if (backgroundMusic == null)
        {
            Debug.LogError("No background music assigned!");
            return;
        }

        MusicSource.clip = backgroundMusic;
        MusicSource.loop = true;

        Debug.Log("MusicSource.isPlaying: " + MusicSource.isPlaying);

        if (!MusicSource.isPlaying)
        {
            Debug.Log("Music played");
            MusicSource.Play();
        }
        else
        {
            Debug.Log("Music was already playing.");
        }
    }
}
