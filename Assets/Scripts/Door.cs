using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Collider;
    public bool isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpen)
        {
            Inventory.Instance.Pickup(ItemType.Key);
        }
        else
        {
            if (!Inventory.Instance.HasItemOfType(ItemType.Key))
            {
                MessageView.Instance.SetMessage("The door is locked! Go get a key if you want to get through it.");
                return;
            }
            Inventory.Instance.Use(ItemType.Key);
        }
        isOpen = !isOpen;
        Collider.SetActive(!isOpen);
    }

    private void OnTriggerExit(Collider other)
    {
        MessageView.Instance.SetMessage("");
    }
}
