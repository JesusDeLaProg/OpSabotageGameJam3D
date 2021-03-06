﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionView : MonoBehaviour
{
    public TextMeshProUGUI Message;

    public CanvasGroup Opacity;
    private Transform cam;

    private void Awake()
    {
        GameState.CurrentInteractionView = this;
        Opacity.alpha = 0;
        cam = Camera.main.transform;
    }

    private void Update()
    {
        transform.LookAt(cam);
    }

    public void Active(string message)
    {
        Opacity.alpha = message == "" ? 0 : 1;
        Message.text = message;
    }
}
