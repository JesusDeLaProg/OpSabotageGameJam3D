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
    public static Inventory Instance;

    public List<InventoryAmount> StartAmountList;
    private Dictionary<ItemType, int> Items;

    public event InventoryEvents.InventoryChangedHandler InventoryChanged;

    private void Awake()
    {
        Instance = this;
        Items = new Dictionary<ItemType, int>();
        foreach (var item in StartAmountList)
        {
            Items.Add(item.type, item.startAmount);
        }
    }

    public bool Pickup(Item item)
    {
        Items[item.Type] = Items[item.Type] + 1;
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemPickedUp, item.Type);
        item.GetComponent<AutoPickup>().Pickup();
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