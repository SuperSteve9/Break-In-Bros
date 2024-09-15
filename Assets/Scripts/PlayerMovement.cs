using UnityEngine;
// ya this is just the brackeys movement script tf you gonna do, buddy?

public class PlayerMovement : MonoBehaviour
{
    // CHARCTER CONTROLLER
    public CharacterController controller;

    // play movement variables
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // shit for the ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // idk why velocity is here
    Vector3 velocity;
    bool isGrounded;

    public DevScripts devscript;
    public PauseMenuManager pmm;

    // Update is called once per frame - I know stupid ass unity
    void Update()
    {
        if (!devscript.isInHomeOwnerMode && !pmm.isInMenu)
        {

            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed += 5;
            }

            // set isgrounded equal to if the ground check is touching another object within the layer of groundmask
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            // smooth
            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            // movement
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            // jump him
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);

        }
    }
}
