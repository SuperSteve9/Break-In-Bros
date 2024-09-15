using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{

    public GameObject menu;
    public bool isInMenu = false;

    private void Start()
    {
        menu.SetActive(false);
        isInMenu = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!menu.activeSelf)
            {
                menu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                isInMenu = true;
            } else
            {
                menu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                isInMenu = false;   
            }
        }
    }
}
