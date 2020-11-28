using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyView : MonoBehaviour
{
    public TextMeshProUGUI KeysAmountText;

    private void Start()
    {
        // TODO: Get in inventory
        int amount = 2;
        KeysAmountText.text = $"x{amount}";
    }

    //Will be activated with inventory
    private void OnKeyAmountChanged()
    {
        int keyAmount = 2;
        KeysAmountText.text = $"x{keyAmount}";
    }
}
