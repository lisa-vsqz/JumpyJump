using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    public float moveSpeed = 5f;    // Player movement speed
    public float jumpForce = 10f;   // Player jump force
    private Rigidbody rb;
    private bool isGrounded;
    private Vector3 originalGravity;
    private bool JustJump = false;
    private float origianlMoveSpeed;
    private Vector3 OriginalPosition;
    private int gravityMultiplayer = 1;
    public bool isStomping = false;
   
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        originalGravity = Physics.gravity;
        origianlMoveSpeed = moveSpeed;
        OriginalPosition = this.transform.position;
        Physics.gravity = originalGravity * 2f; // Duplicar la gravedad
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f) * moveSpeed * Time.deltaTime;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    void Update()
    {
        if (isGrounded)
        {
            gravityMultiplayer = 1;
            isStomping = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (!isGrounded && rb.velocity.y < 0)
            {
                gravityMultiplayer = 3;
                isStomping = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            JustJump = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !isGrounded && JustJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            JustJump = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed *= 2;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = origianlMoveSpeed;
        }

        if (!isGrounded && rb.velocity.y < 0)
        {
            Physics.gravity = originalGravity * 4f * gravityMultiplayer; // Increase gravity
        }

        if (transform.position.y < -6)
        {
            Respawn();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Destroy the bullet
            Destroy(collision.gameObject);
            // Respawn the player
            Respawn();
        }
    }

    void Respawn()
    {
        Debug.Log("?");
        transform.position = OriginalPosition; // Move player to initial position
        rb.velocity = Vector3.zero; // Reset velocity
        isGrounded = true; // Set grounded state
    }
}
