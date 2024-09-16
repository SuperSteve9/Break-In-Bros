using UnityEngine;
// brackeys is amazing

public class MouseLook : MonoBehaviour
{
    // variables you know how it is
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public PauseMenuManager pmm;

    float xRot = 0f;

    // lock cursor
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per fucks i give
    // actually never mind that would never load
    void Update()
    {
        if (!pmm.isInMenu)
        {
            // get mouse position
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            // clamp that bitch
            xRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -90f, 90f);

            // actually the rotation
            transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
