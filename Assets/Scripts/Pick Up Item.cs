using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickUpItem : MonoBehaviour
{
    // Public:

    // Private:
    private Camera cam;
    // variables as always
    private LayerMask itemMask;
    
    public SpawnItemsRandomly sir;

    void Start()
    {
        cam = transform.Find("Main Camera").GetComponent<Camera>();

        itemMask = LayerMask.GetMask("Item");
    }

    void Update()
    {
        IsLookingAtItem();

        if (sir.numObjects == sir.numOfObjectsLeft)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void IsLookingAtItem()
    {
        // If item in radius
        if (Physics.CheckSphere(transform.position, 4, itemMask))
        {
            // Generate a ray in the middle of the screen
            // I might change this to be a wider range tho
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;
            // check if the ray has molested an item WOOOAHHHH
            if (Physics.Raycast(ray, out hit, 4f, itemMask))
            {
                // if the key E is pressed it will "pick up" the item
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    PickUp();
                }
            }
        }
    }

    // update the counter
    private void PickUp()
    {

    }
}
