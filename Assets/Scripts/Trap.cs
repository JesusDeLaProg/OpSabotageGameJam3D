using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Collider Collider;

    public void Activate(bool isActive)
    {
        Collider.enabled = isActive;
    }
}
