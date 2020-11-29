using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class InventoryEvents
{
    public enum InventoryChangedEventType
    {
        ItemPickedUp,
        ItemUsed
    }
    public delegate void InventoryChangedHandler(InventoryChangedEventType eventType, ItemType type);
}

public class Inventory : MonoBehaviour
{
    public List<InventoryAmount> StartAmountList;
    public Dictionary<ItemType, int> Items;
    public int BaddiesToWakeup;

    public event InventoryEvents.InventoryChangedHandler InventoryChanged;

    private void Awake()
    {
        GameState.CurrentInventory = this;
        Items = new Dictionary<ItemType, int>();
        foreach (var item in StartAmountList)
        {
            Items.Add(item.type, item.startAmount);
        }
    }

    public void WakeupBaddy()
    {
        BaddiesToWakeup = Mathf.Max(0, BaddiesToWakeup - 1);
    }

    public bool Pickup(Item item)
    {
        item.GetComponent<AutoPickup>().Pickup();
        return Pickup(item.Type);
    }

    public bool Pickup(ItemType type)
    {
        Items[type] = Items[type] + 1;
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemPickedUp, type);
        return true;
    }

    public bool Drop(Item item)
    {
        item.GetComponent<AutoPickup>().Drop();
        return Use(item);
    }

    public bool Use(Item item)
    {
        return Use(item.Type);
    }

    public bool Use(ItemType type)
    {
        if (Items[type] <= 0) return false; // Inventory does not contain this item
        Items[type] = Items[type] - 1;
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemUsed, type);
        return true;
    }

    public bool HasItemOfType(ItemType type)
    {
        return Items[type] > 0;
    }

    public int CountOfType(ItemType type)
    {
        return Items[type];
    }
}

[System.Serializable]
public struct InventoryAmount
{
    public ItemType type;
    public int startAmount;
}