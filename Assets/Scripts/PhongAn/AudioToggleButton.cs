using UnityEngine;

public class AudioToggleButton : MonoBehaviour
{
    public AudioSource audioSource; // Kéo AudioSource vào đây

    public void ToggleAudio()
    {
        if (audioSource.isPlaying)
        {
            // Dừng hoàn toàn và đặt lại vị trí phát
            audioSource.Stop();
        }
        else
        {
            // Phát lại từ đầu
            audioSource.Play();
        }
    }
}
