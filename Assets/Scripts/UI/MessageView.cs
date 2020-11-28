using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MessageView : MonoBehaviour
{
    public static MessageView Instance;

    public TextMeshProUGUI MessageText;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void SetMessage(string message)
    {
        gameObject.SetActive(message != "");
        MessageText.text = message;
    }
}
