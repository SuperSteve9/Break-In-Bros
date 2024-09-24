using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Rendering.LookDev;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [HideInInspector] public bool isUsingCameras = false;

    private int selectedCam = 0;

    private Transform cameras;
    private Camera playerCam;

    private LayerMask cameraLayer;

    // Start is called before the first frame update
    void Start()
    {
        cameras = GameObject.Find("Scene").transform.Find("Cameras");
        playerCam = transform.Find("Main Camera").GetComponent<Camera>();

        cameraLayer = LayerMask.GetMask("Cameras");
    }

    // Update is called once per frame
    void Update()
    {
        CameraCheck();
        if (isUsingCameras)
        {
            ChangeCamera();
            UpdateCamera();
        }
        else
        {
            cameras.GetChild(selectedCam).Find("ActualCamera").gameObject.SetActive(false);
        }
    }

    private void CameraCheck()
    {
        // For camera station
        if (Physics.CheckSphere(transform.position, 2, cameraLayer))
        {
            Ray ray = playerCam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 4f, cameraLayer))
            {
                // if the key E is pressed it will "pick up" the item
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (!isUsingCameras)
                    {
                        UseCameras();
                    }
                    else
                    {
                        DisableCameras();
                    }
                }
            }
        }
    }

    private void UseCameras()
    {
        Debug.Log("Cameras used");

        isUsingCameras = true;
    }

    private void DisableCameras()
    {
        Debug.Log("Cameras disabled");

        isUsingCameras = false;
    }

    private void ChangeCamera()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedCam--;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedCam++;
        }
    }

    /* Maybe used later to randomly disable some cameras, or with purpose
    private GameObject FindCamera(int camNum)
    {
        for (int i = 0; i < cameras.childCount; i++)
        {
            if (camNum == i)
            {
                return cameras.GetChild(i).gameObject;
            }
        }

        return null;
    }
    */

    private void UpdateCamera()
    {
        if (selectedCam < 0)
        {
            selectedCam = cameras.childCount - 1;
        }
        else if (selectedCam > cameras.childCount - 1)
        {
            selectedCam = 0;
        }

        for (int i = 0; i < cameras.childCount; i++)
        {
            if (i != selectedCam)
            {
                cameras.GetChild(i).Find("ActualCamera").gameObject.SetActive(false);
            }
            else
            {
                cameras.GetChild(i).Find("ActualCamera").gameObject.SetActive(true);
            }
        }
    }
}
