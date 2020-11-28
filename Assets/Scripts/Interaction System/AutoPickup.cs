using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPickup : MonoBehaviour, IInteractble
{
    public Material Transparant;
    public Material Normal;

    public float interactionRange => 2f;

    public bool isAutoPickup => true;

    public bool isThere;

    private void Start()
    {
        UpdateMesh();
    }

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
        if (isThere)
        {
            Inventory.Instance.Pickup(GetComponent<Item>());
        }
        else
        {
            Inventory.Instance.Drop(GetComponent<Item>());
        }
        //Destroy(gameObject);
    }

    public void Pickup()
    {
        isThere = false;
        UpdateMesh();
    }

    public void Drop()
    {
        isThere = true;
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        GetComponent<MeshRenderer>().material = isThere ? Normal : Transparant;
    }
}
