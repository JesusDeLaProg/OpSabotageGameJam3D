using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject Collider;

    public void Activate(bool isActive)
    {
        Collider.SetActive(isActive);
    }
}
