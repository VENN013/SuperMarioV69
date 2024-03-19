using UnityEngine;

public class move2 : MonoBehaviour
{
    public float playerSpeed;
    public float jumpForce;
    public Rigidbody2D playerRb;
    private float movementX;
    private bool isGrounded; // ‘лаг, показывающий, находитс€ ли игрок на земле

    private void Update()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(movementX * playerSpeed, playerRb.velocity.y);
        playerRb.velocity = movement;
    }

    private void Jump()
    {
        playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ѕровер€ем, сталкиваетс€ ли игрок с полом
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ѕровер€ем, покинул ли игрок пол
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
