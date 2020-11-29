using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BadGuySpawnPoint : MonoBehaviour, IInteractble
{
    public AIController BadGuy;

    public float interactionRange => 2f;

    public bool isAutoPickup => false;

    public void OnEnterRange() 
    {
        if (!BadGuy.IsActiveSingle)
        {
            InteractionView.Instance.Active("Revive!");
        }
    }

    public void OnExitRange()
    {
        if (!BadGuy.IsActiveSingle)
        {
            InteractionView.Instance.Active("");
        }
    }

    public void OnInteract()
    {
      //  gameObject.SetActive(false);
        BadGuy.Activate();
        InteractionView.Instance.Active("");
    }
}
