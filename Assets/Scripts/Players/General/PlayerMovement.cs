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

    [Header("Movement")]
    // Player movement variables
    public float speed;
    public float sprintSpeed;
    public float crouchSpeed;
    public float jumpHeight;

    [Header("Misc")]
    public int health;

    public float gravity;

    [Header("Script References")]
    public DevScripts devscript;
    public PauseMenuManager pmm;

    // Private:
    private static float crouchInterval = 0.0f;
    private static float sprintInterval = 0.0f;

    private float originalSpeed;
    private float originalHeight;
    private float crouchHeight;

    private float originalPosition;

    private bool isCrouching = false;
    private bool isCrouchSmoothing = false;
    private bool isSprinting = false;
    // Graun cheker
    private float groundDistance = 0.4f;
    private bool isGrounded;
    private Transform bottomGroundCheck;
    private Transform topGroundCheck;
    private LayerMask groundMask;
    // Physics
    private Vector3 velocity;

    private enum MovementStates
    {
        Walking, // Default
        Sprinting,
        Crouching,
        Jumping
    }

    private MovementStates moveState;

    void Start()
    {
        moveState = MovementStates.Walking;

        originalSpeed = speed;

        originalHeight = controller.height;
        crouchHeight = originalHeight / 2;

        bottomGroundCheck = transform.Find("Bottom");
        topGroundCheck = transform.Find("Top");
        groundMask = LayerMask.GetMask("Ground");
    }

    // Update is called once per frame - I know stupid ass unity
    void Update()
    {
        if (!devscript.isInHomeOwnerMode && !pmm.isInMenu)
        {
            Movement();
            Sprint();
            Jump();
            Grounded();
            Crouch();
        }

        if (health < 100)
        {
            Die();
        }

        print(moveState);
    }

    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void Sprint()
    {
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            isSprinting = true;
        }

        if (isSprinting)
        {
            SprintUp();
        }

        if (moveState != MovementStates.Walking)
            return;

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)
        {
            SprintDown();
        }
    }

    private void Jump()
    {
        if (moveState == MovementStates.Crouching)
            return;

        if (Input.GetButtonDown("Jump") && isGrounded)
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    private void Grounded()
    {
        // set isgrounded equal to if the ground check is touching another object within the layer of groundmask
        isGrounded = Physics.CheckSphere(bottomGroundCheck.position, groundDistance, groundMask);

        bool isCieling = Physics.CheckSphere(topGroundCheck.position, groundDistance, groundMask);

        // smooth
        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        if (!isGrounded && isCieling)
            velocity.y = -2f;
    }

    private void Crouch()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            // Smoothing function allows for crouch smoothing between two speeds and controller heights
            isCrouching = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            // Smoothing function allows for crouch smoothing between two speeds and controller heights
            isCrouching = true;
            isCrouchSmoothing = true;
        }

        if (isCrouchSmoothing)
        {
            if (isCrouching)
            {
                CrouchSmoothingDown();
            }
            else
            {
                CrouchSmoothingUp();
            }
        }
    }

    private void CrouchSmoothingDown()
    {
        if (crouchInterval >= 1)
        {
            speed = crouchSpeed;
            controller.height = crouchHeight;
            crouchInterval = 1;
            return;
        }

        speed = Mathf.Lerp(originalSpeed, crouchSpeed, crouchInterval);
        controller.height = Mathf.Lerp(originalHeight, crouchHeight, crouchInterval);

        crouchInterval += (crouchSpeed + 1) * Time.deltaTime;
    }

    private void CrouchSmoothingUp()
    {
        speed = Mathf.Lerp(originalSpeed, crouchSpeed, crouchInterval);
        controller.height = Mathf.Lerp(originalHeight, crouchHeight, crouchInterval);

        crouchInterval -= (crouchSpeed + 1) * Time.deltaTime;

        if (crouchInterval <= 0)
        {
            speed = originalSpeed;
            controller.height = originalHeight;
            isCrouching = false;
            isCrouchSmoothing = false;
            crouchInterval = 0;
        }
    }

    private void SprintDown()
    {
        if (sprintInterval >= 1)
        {
            speed = sprintSpeed;
            sprintInterval = 1;
            return;
        }

        speed = Mathf.Lerp(originalSpeed, sprintSpeed, sprintInterval);

        sprintInterval += (sprintSpeed / 4) * Time.deltaTime;
    }

    private void SprintUp()
    {
        speed = Mathf.Lerp(originalSpeed, sprintSpeed, sprintInterval);

        sprintInterval -= (sprintSpeed / 4) * Time.deltaTime;

        if (sprintInterval <= 0)
        {
            speed = originalSpeed;
            isSprinting = false;
            sprintInterval = 0;
        }
    }

    private void Die()
    {
        // You dead
    }
}
