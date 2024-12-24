using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip musicClip; // Assign your audio clip in the Inspector
    private AudioSource audioSource;

    void Start()
    {
        // Add an AudioSource component if not already attached
        audioSource = gameObject.AddComponent<AudioSource>();

        // Configure the AudioSource
        audioSource.clip = musicClip;
        audioSource.loop = true;  // Loop the music
        audioSource.playOnAwake = false; // Don't play automatically
        audioSource.volume = 1f; // Set initial volume
        PlayMusic();
    }

    // Play the music
    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    // Pause the music
    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    // Stop the music
    public void StopMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    // Adjust the volume
    public void SetVolume(float volume)
    {
        if (audioSource != null)
        {
            audioSource.volume = Mathf.Clamp01(volume); // Clamp between 0 and 1
        }
    }
}
