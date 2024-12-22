using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // Nhấn phím E để kích hoạt animation "Ăn"
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Eat");
        }
    }
        public AudioSource chewingAudio;

    // Hàm này sẽ được gọi qua Animation Event
    public void PlayChewingSound()
    {
        if (chewingAudio != null)
        {
            chewingAudio.Play(); // Chơi âm thanh nhai
        }
        else
        {
            Debug.LogWarning("Chewing audio source is not assigned!");
        }
    }
}
