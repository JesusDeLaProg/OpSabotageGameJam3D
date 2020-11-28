using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractble
{
    float interactionRange { get; }
    bool isAutoPickup { get; }
    void OnEnterRange();
    void OnInteract();
    void OnExitRange();
}
