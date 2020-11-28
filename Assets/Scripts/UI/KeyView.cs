using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static InventoryEvents;

public class KeyView : InventoryView
{
    public TextMeshProUGUI KeysAmountText;

    //Will be activated with inventory
    private void OnKeyAmountChanged(InventoryChangedEventType eventType, ItemData item)
    {
        if (Type != item.Type)
        {
            return;
        }
        int keyAmount = Inventory.Instance.CountOfType(Type);
        KeysAmountText.text = $"x{keyAmount}";
    }

    protected override void UpdateView()
    {
        KeysAmountText.text = $"x{GetAmount()}";
    }
}
