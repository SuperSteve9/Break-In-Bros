using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevScripts : MonoBehaviour
{
    public GameObject mainCameraObject;
    public GameObject homeCameraObject;
    public bool isInHomeOwnerMode = false;
    public bool isInRobberMode = true;

    private void Start()
    {
        isInHomeOwnerMode = false;
        isInRobberMode = true;
        mainCameraObject.SetActive(true);
        homeCameraObject.SetActive(false);
    }
    public void RobberMode()
    {
        isInHomeOwnerMode = false;
        isInRobberMode = true;
        Debug.Log("Switching to Robber Mode");
        mainCameraObject.SetActive(true);
        homeCameraObject.SetActive(false);
    }

    public void HomeMode()
    {
        isInHomeOwnerMode = true;
        isInRobberMode = false;
        Debug.Log("Switching To home owner Mode");
        mainCameraObject.SetActive(false);
        homeCameraObject.SetActive(true);
    }
}
