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

        UpdateSlot();
    }

    void Update()
    {
        IsLookingAtItem();
        DropItem();

        SelectSlot();

        print(itemCount);
    }

    private void IsLookingAtItem()
    {
        // If item in radius
        if (Physics.CheckSphere(transform.position, 4, itemMask))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));
            RaycastHit hit;

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
        if (itemCount == 4)
            return;

        if (item.CompareTag("Evidence"))


        if (slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName == "NO ITEM CURRENTLY HELD")
        {
            item.parent = heldItemsContainer;
            item.localPosition = item.GetComponent<Item>().holdPosition;

            slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName = item.gameObject.name;
            slots.GetChild(slotSelected - 1).GetChild(1).GetComponent<Image>().sprite = item.GetComponent<Item>().itemIcon;

            itemCount++;
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

                itemCount--;
            }
        }
    }

    private void SelectSlot()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotSelected = 1;
            UpdateSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotSelected = 2;
            UpdateSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotSelected = 3;
            UpdateSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotSelected = 4;
            UpdateSlot();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotSelected = 5;
            UpdateSlot();
        }
    }

    private void UpdateSlot()
    {
        for (int i = 1; i < 6; i++)
        {
            if (i == slotSelected)
            {
                slots.GetChild(i - 1).GetChild(0).GetComponent<Image>().color = Color.red;

                /*
                // If the selected slot has an item, show that item
                if (slots.GetChild(i - 1).GetComponent<SlotData>().itemName != "NO ITEM CURRENTLY HELD")
                {
                    Debug.Log("On");
                    Transform objectToShow = heldItemsContainer.Find(slots.GetChild(i - 1).GetComponent<SlotData>().itemName);
                    objectToShow.gameObject.SetActive(true);
                }
                */
            }
            else
            {
                slots.GetChild(i - 1).GetChild(0).GetComponent<Image>().color = Color.white;

                /*
                if (slots.GetChild(i - 1).GetComponent<SlotData>().itemName != "NO ITEM CURRENTLY HELD")
                {
                    Debug.Log("Off");
                    Transform objectToHide = heldItemsContainer.Find($"{slots.GetChild(slotSelected - 1).GetComponent<SlotData>().itemName}");
                    objectToHide.gameObject.SetActive(false);
                }
                */
            }
        }
    }
}
