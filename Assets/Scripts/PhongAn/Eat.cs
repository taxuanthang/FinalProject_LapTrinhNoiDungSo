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
}
