using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickUpItem : MonoBehaviour
{
    // Public:

    // Private:
    // Is looking at item vars
    private Camera cam;
    private LayerMask itemMask;
    // Inventory UI
    private int itemCount = 0;
    private int slotSelected = 1;

    private Transform canvas;
    private Transform slots;

    private Transform heldItemsContainer;

    void Start()
    {
        cam = transform.Find("Main Camera").GetComponent<Camera>();
        itemMask = LayerMask.GetMask("Item");

        canvas = GameObject.Find("Canvas").transform;
        slots = canvas.Find("Inventory").GetChild(0).transform;

        heldItemsContainer = transform.Find("HeldItems");
    }

    void Update()
    {
        IsLookingAtItem();
        DropItem();

        UpdateSlot();
        SelectSlot();

        print($"slot: {slotSelected}");
        print($"item count: {itemCount}");
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
                    PickUp(hit.collider.gameObject.transform);
                }
            }
        }
    }

    // update the counter
    private void PickUp(Transform item)
    {
        if (itemCount == 5)
            return;

        itemCount++;

        item.parent = heldItemsContainer;
        item.localPosition = item.GetComponent<Item>().holdPosition;

        slots.GetChild(slotSelected - 1).GetChild(1).GetComponent<Image>().sprite = item.GetComponent<Item>().itemIcon;
        slotSelected++;
    }

    private void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (itemCount != 0)
            {
                heldItemsContainer.GetChild(slotSelected - 1).position = transform.position;
                heldItemsContainer.GetChild(slotSelected - 1).parent = null;

                slots.GetChild(slotSelected - 1).GetChild(1).GetComponent<Image>().sprite = null;
                slotSelected--;

                itemCount--;
            }
        }
    }

    private void SelectSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotSelected = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotSelected = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotSelected = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotSelected = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotSelected = 5;
        }
    }

    private void UpdateSlot()
    {
        for (int i = 1; i < 6; i++)
        {
            if (i == slotSelected)
            {
                slots.GetChild(i - 1).GetChild(0).GetComponent<Image>().color = Color.red;
            }
            else
            {
                slots.GetChild(i - 1).GetChild(0).GetComponent<Image>().color = Color.white;
            }
        }
    }
}
