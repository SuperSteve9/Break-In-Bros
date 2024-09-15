using System.Collections;
using UnityEngine;
// ya this is just the brackeys movement script tf you gonna do, buddy?

public class PlayerMovement : MonoBehaviour
{
    // Public:
    // CHARCTER CONTROLLER
    [Header("Physics")]
    public CharacterController controller;
    
    [Header("General Properties")]
    // Player movement variables
    public float speed;
    public float sprintSpeed;
    public float jumpHeight;

    public float gravity;

    [Header("Script References")]
    public DevScripts devscript;
    public PauseMenuManager pmm;

    // Private:
    private float originalSpeed;
    // Graun cheker
    private float groundDistance = 0.4f;
    private bool isGrounded;
    private Transform groundCheck;
    private LayerMask groundMask;
    // Physics
    private Vector3 velocity;

    void Start()
    {
        originalSpeed = speed;

        groundCheck = transform.Find("GroundCheck");
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame - I know stupid ass unity
    void Update()
    {
        if (!devscript.isInHomeOwnerMode && !pmm.isInMenu)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                speed = sprintSpeed;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                speed = originalSpeed;
            }

            Movement();
            Jump();
            Grounded();
        }
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Grounded()
    {
        // set isgrounded equal to if the ground check is touching another object within the layer of groundmask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // smooth
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }
}
