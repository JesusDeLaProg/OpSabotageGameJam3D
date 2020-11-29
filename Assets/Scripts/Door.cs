using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject Collider;
    public bool isOpen;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (isOpen)
        {
            GameState.CurrentInventory.Pickup(ItemType.Key);
        }
        else
        {
            if (!GameState.CurrentInventory.HasItemOfType(ItemType.Key))
            {
                GameState.CurrentMessageView.SetMessage("The door is locked! Go get a key if you want to get through it.");
                return;
            }
            GameState.CurrentInventory.Use(ItemType.Key);
        }
        isOpen = !isOpen;
        Collider.SetActive(!isOpen);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        GameState.CurrentMessageView.SetMessage("");
    }
}
