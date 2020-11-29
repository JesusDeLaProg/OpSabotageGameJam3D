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
            GameState.CurrentInteractionView.Active("Activate!");
    }

    public void OnExitRange()
    {
            GameState.CurrentInteractionView.Active("");
    }

    public void OnInteract()
    {
        isActive = !isActive;
        AssociatedTrap.Activate(isActive);
    }
}
