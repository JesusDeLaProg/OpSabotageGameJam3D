using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public Collider Collider;
    public Animator Anim;

    public void Activate(bool isActive)
    {
        Anim.SetBool("isOpen", !isActive);
        Collider.enabled = isActive;
    }
}
