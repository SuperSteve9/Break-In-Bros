using UnityEngine;

public class HomeOwnerCameraController : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform horizontalBody;
    float xRotation = 0f;

    public DevScripts devscript;
    public PauseMenuManager pmm;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the horizontal body based on mouse X input
        horizontalBody.Rotate(Vector3.up * mouseX);

        // Adjust the camera's vertical rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Vector3 forwardMovement = horizontalBody.forward;
        Vector3 rightMovement = horizontalBody.right;

        // Apply movement
        if (Input.GetKey(KeyCode.W))
        {
            horizontalBody.position += forwardMovement * 0.1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            horizontalBody.position -= forwardMovement * 0.1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            horizontalBody.position -= rightMovement * 0.1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            horizontalBody.position += rightMovement * 0.1f;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            horizontalBody.position += Vector3.down * 0.1f;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            horizontalBody.position += Vector3.up * 0.1f;
        }
    }
}
