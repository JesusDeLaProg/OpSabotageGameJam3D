using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Collider Collider;
    public Animator Anim;
    public bool IsActivated;

    private void Start()
    {
        Activate(IsActivated);
    }

    public void Activate(bool isActive)
    {
        Anim.SetBool("isOpen", !isActive);
        Collider.enabled = isActive;
    }
}
