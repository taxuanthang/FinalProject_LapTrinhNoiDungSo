using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public Animator animator; // Animator của nhân vật
    public AudioSource chewingAudio; // Nguồn âm thanh nhai
    public GameObject handPosition; // Vị trí tay để cầm hoa quả

    void Update()
    {
        HandleEating();
    }

    // Hàm xử lý khi bấm phím E để ăn hoa quả
    void HandleEating()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (handPosition.transform.childCount > 0)
            {
                // Kiểm tra hoa quả trên tay
                var fruit = handPosition.transform.GetChild(0).gameObject;

                // Kích hoạt animation "Eat"
                animator.SetTrigger("Eat");

                // Sau khi ăn xong, xóa hoa quả
                Destroy(fruit, 1.5f); // Xóa hoa quả sau 1.5 giây (để khớp với animation)

                // Phát âm thanh nhai
                PlayChewingSound();
            }
            else
            {
                Debug.Log("No fruit in hand to eat!");
            }
        }
    }

    // Hàm được gọi từ Animation Event để phát âm thanh
    public void PlayChewingSound()
    {
        if (chewingAudio != null && !chewingAudio.isPlaying)
        {
            chewingAudio.Play(); // Phát âm thanh nhai
        }
        else if (chewingAudio == null)
        {
            Debug.LogWarning("Chewing audio source is not assigned!");
        }
    }

}
