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
<<<<<<< HEAD
=======
        CharacterMovement._respawnBadGuy?.Invoke();
        CharacterMovement.Active = false;
        var awaiter = Task.Delay(1500).GetAwaiter();
        awaiter.OnCompleted(() => CharacterMovement.Active = true);
>>>>>>> 319d0e4c716368647b8b2e407be2924c19f194ae
        InteractionView.Instance.Active("");
    }
}
