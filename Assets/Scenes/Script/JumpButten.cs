using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public Rigidbody2D characterRigidbody;
    public float jumpForce = 8f;

    private bool isGrounded = true;

    void Start()
    {
        Button jumpButton = GetComponent<Button>();
        if (jumpButton != null)
        {
            jumpButton.onClick.AddListener(OnJumpButtonPressed);
        }
    }

    private void OnJumpButtonPressed()
    {
        if (characterRigidbody != null)
        {
            var playerController = characterRigidbody.GetComponent<CharacterController>();
            if (playerController != null)
            {
                playerController.PerformJump(jumpForce);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}