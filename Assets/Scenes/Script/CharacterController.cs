using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Joystick joystick;
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rigidbody;

    private bool isGrounded = true;

    public float minX = -8f; 
    public float maxX = 8f;  
    public float minY = -4f; 
    public float maxY = 4f;  

    void Update()
    {
        float horizontal = joystick.Horizontal;
        float vertical = joystick.Vertical;

        
        if (Mathf.Abs(horizontal) > 0.1f)
        {
            rigidbody.linearVelocity = new Vector2(horizontal * moveSpeed, rigidbody.linearVelocity.y);

            if (horizontal > 0)
                transform.localScale = new Vector3(1, 1, 1); 
            else if (horizontal < 0)
                transform.localScale = new Vector3(-1, 1, 1); 

            animator.SetFloat("Speed", Mathf.Abs(horizontal));
        }
        else
        {
            rigidbody.linearVelocity = new Vector2(0, rigidbody.linearVelocity.y);
            animator.SetFloat("Speed", 0);
        }

        
        Vector3 currentPosition = transform.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, minX, maxX); 
        currentPosition.y = Mathf.Clamp(currentPosition.y, minY, maxY); 
        transform.position = currentPosition;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("IsJumping", false);
        }
    }

    public void PerformJump(float jumpForce)
    {
        if (isGrounded)
        {
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;

            animator.SetBool("IsJumping", true);
        }
    }
}