using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpItem : MonoBehaviour
{
    // variables as always
    public Transform player;
    public LayerMask item;
    public Camera Camera;
    public GameObject pickupText;
    public TMP_Text pickupTextText;
    public TMP_Text count;
    public SpawnItemsRandomly sir;

    void Update()
    {
        // check if an item is in radius
        // it'd be pretty stupid to be constantly raycasting if not necessary
        if (Physics.CheckSphere(player.position, 4, item))
        {
            Debug.Log("Pickupable item in range");
            // generate a ray in the middle of the screen
            // I might change this to be a wider range tho
            Ray ray = Camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            // check if the ray has molested an item
            if (Physics.Raycast(ray, out hit, 4f, item)) 
            {
                Debug.Log("Looking at item: " + hit.collider.gameObject.name);
                pickupTextText.text = "Press \'E\' to pick up " + hit.collider.gameObject.name;
                // if the key E is pressed it will "pick up" the item
                pickupText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    UpdateCount();
                }
            } else
            {
                pickupText.SetActive(false);
            }
        } else
        {
            pickupText.SetActive(false);
        }

        if (sir.numObjects == sir.numOfObjectsLeft)
        {
            SceneManager.LoadScene(2);
        }
 
    }

    // update the counter
    public void UpdateCount()
    {
        sir.numOfObjectsLeft++;
        count.text = sir.numOfObjectsLeft.ToString() + "/" + sir.numObjects.ToString();
    }
}
