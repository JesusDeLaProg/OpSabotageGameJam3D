using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Collider Collider;
    public Animator Anim;
    public Animator Anim2;
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
        Debug.Log("isOpen: "+isOpen);
        isOpen = !isOpen;
        StartCoroutine(WaitAndEnable(isOpen));
        Anim.SetBool("isOpen", !isOpen);
        Anim2.SetBool("isOpen", !isOpen);
    }

    private IEnumerator WaitAndEnable(bool isOpen)
    {
        yield return new WaitForSeconds(1f);
        Collider.enabled = !isOpen;
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
