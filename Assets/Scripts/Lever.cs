using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour, IInteractble
{
    public bool isActive;
    public Trap AssociatedTrap;

    void Start()
    {
        AssociatedTrap.Activate(isActive);
    }

    public float interactionRange => 2f;

    public bool isAutoPickup => false;

    public void OnEnterRange()
    {
        Debug.Log("Entering Interaction Range");
    }

    public void OnExitRange()
    {
        Debug.Log("Exiting Interaction Range");
    }

    public void OnInteract()
    {
        isActive = !isActive;
        AssociatedTrap.Activate(isActive);
    }
}
