using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoPickup : MonoBehaviour, IInteractble
{
    public Material Transparant;
    public Material Normal;
    public MeshRenderer Mesh;
    public GameObject Particles;

    public float interactionRange => 0.2f;

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
        Particles.SetActive(true);
        UpdateMesh();
    }

    public void Drop()
    {
        isThere = true;
        Particles.SetActive(true);
        UpdateMesh();
    }

    private void UpdateMesh()
    {
        Mesh.material = isThere ? Normal : Transparant;
    }
}
