using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevScripts : MonoBehaviour
{
    private int counter = 0;

    public Transform homeownerPos;
    private Transform startPosition;

    void Start()
    {
        homeownerPos = GameObject.Find("HomeownerPosition").transform;
        startPosition = GameObject.Find("SpawnPosition").transform;

        RobberMode();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (counter == 0)
            {
                HomeMode();
                counter++;
            }
            else if (counter == 1)
            {
                RobberMode();
                counter--;
            }
        }
    }

    public void RobberMode()
    {
        Debug.Log("Switching to Robber Mode");

        GetComponent<CharacterController>().enabled = false;
        transform.position = startPosition.position;
        GetComponent<CharacterController>().enabled = true;
    }

    public void HomeMode()
    {
        Debug.Log("Switching To home owner Mode");

        GetComponent<CharacterController>().enabled = false;
        transform.position = homeownerPos.position;
        GetComponent<CharacterController>().enabled = true;
    }
}
