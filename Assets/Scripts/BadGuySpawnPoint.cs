using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BadGuySpawnPoint : MonoBehaviour, IInteractble
{
    public AIController BadGuy;

    public float interactionRange => 2f;

    public bool isAutoPickup => false;

    public void OnEnterRange() {}

    public void OnExitRange() {}

    public void OnInteract()
    {
      //  gameObject.SetActive(false);
        BadGuy.Activate();
        
    }
}
