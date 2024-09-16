using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class PickUpItem : MonoBehaviour
{
    // Private:
    // Is looking at item vars
    private Camera cam;
    private LayerMask itemMask;
    // Inventory UI
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
    }

    private void IsLookingAtItem()
    {
        // If item in radius
        if (Physics.CheckSphere(transform.position, 4, itemMask))
        {
            // Generate a ray in the middle of the screen
            // I might change this to be a wider range tho
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 6, Screen.height / 4, 0));
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
        if (slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName == "NO ITEM CURRENTLY HELD")
        {
            item.parent = heldItemsContainer;
            item.localPosition = item.GetComponent<Item>().holdPosition;

            slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName = item.gameObject.name;
            slots.GetChild(slotSelected - 1).GetChild(1).GetComponent<Image>().sprite = item.GetComponent<Item>().itemIcon;
        }
    }

    private void DropItem()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName != "NO ITEM CURRENTLY HELD")
            {
                Transform objectToRemove = heldItemsContainer.Find($"{slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName}");

                objectToRemove.position = transform.position;
                objectToRemove.parent = null;

                slots.GetChild(slotSelected - 1).GetChild(1).GetComponent<Image>().sprite = null;
                slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName = "NO ITEM CURRENTLY HELD";
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

                if (slots.GetChild(i - 1).GetComponent<SlotData>().itemName != "NO ITEM CURRENTLY HELD")
                {
                    Transform objectToShow = heldItemsContainer.Find(slots.GetChild(i - 1).GetComponent<SlotData>().itemName);
                    objectToShow.gameObject.SetActive(true);
                }
            }
            else
            {
                slots.GetChild(i - 1).GetChild(0).GetComponent<Image>().color = Color.white;

                if (slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName != "NO ITEM CURRENTLY HELD")
                {
                    Transform objectToShow = heldItemsContainer.Find($"{slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName}");
                    objectToShow.gameObject.SetActive(false);
                }
            }
        }
    }
}
