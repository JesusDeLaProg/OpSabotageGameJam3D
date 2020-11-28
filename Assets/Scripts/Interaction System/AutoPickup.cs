using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPickup : MonoBehaviour, IInteractble
{
    public float interactionRange => 2f;

    public bool isAutoPickup => true;

    public void OnExitRange()
    {
        return;
    }

    public void OnEnterRange()
    {
        return;
    }

    public void OnInteract()
    {
        Debug.Log("Auto Pickup");
    }
}
