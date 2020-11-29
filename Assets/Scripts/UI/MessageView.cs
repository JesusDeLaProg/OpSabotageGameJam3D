using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    public TextMeshProUGUI MessageText;

    private void Awake()
    {
        GameState.CurrentMessageView = this;
        gameObject.SetActive(false);
    }

    public void SetMessage(string message)
    {
        gameObject.SetActive(message != "");
        MessageText.text = message;
    }
}
