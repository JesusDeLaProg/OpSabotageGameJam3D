using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BadGuySpawnPoint : MonoBehaviour, IInteractble
{
    public GameObject BadGuy;

    public float interactionRange => 2f;

    public bool isAutoPickup => false;

    public void OnEnterRange() {}

    public void OnExitRange() {}

    public void OnInteract()
    {
        CharacterMovement._respawnBadGuy?.Invoke();
        CharacterMovement.Active = false;
        var awaiter = Task.Delay(1500).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            gameObject.SetActive(false);
            BadGuy.SetActive(true);
            CharacterMovement.Active = true;
        });
    }
}
