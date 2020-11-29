using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryEvents;

public abstract class InventoryView : MonoBehaviour
{
    public ItemType Type;

    private void Start()
    {
        // TODO: Get in inventory
        GameState.CurrentInventory.InventoryChanged += OnAmountChanged;
        UpdateView();
    }

    private void OnDestroy()
    {
        GameState.CurrentInventory.InventoryChanged -= OnAmountChanged;
    }

    private void OnAmountChanged(InventoryChangedEventType eventType, ItemType itemType)
    {
        if (itemType == Type)
        {
            UpdateView();
        }
    }

    protected abstract void UpdateView();

    protected int GetAmount()
    {
        return GameState.CurrentInventory.CountOfType(Type);
    }
}
