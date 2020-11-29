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
            GameState.CurrentInteractionView.Active("Revive!");
        }
    }

    public void OnExitRange()
    {
        if (!BadGuy.IsActiveSingle)
        {
            GameState.CurrentInteractionView.Active("");
        }
    }

    public void OnInteract()
    {
      //  gameObject.SetActive(false);
        BadGuy.Activate();
        CharacterMovement._respawnBadGuy?.Invoke();
        CharacterMovement.Active = false;
        var awaiter = Task.Delay(1500).GetAwaiter();
        awaiter.OnCompleted(() => CharacterMovement.Active = true);
        GameState.CurrentInventory.WakeupBaddy();
        GameState.CurrentInteractionView.Active("");
    }
}
