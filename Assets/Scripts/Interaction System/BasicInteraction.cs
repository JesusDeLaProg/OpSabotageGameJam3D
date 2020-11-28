using UnityEngine;

public class BasicInteraction : MonoBehaviour,IInteractble
{
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
        Debug.Log("Interacting");
    }
}
