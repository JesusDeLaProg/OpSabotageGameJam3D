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
    public delegate void InventoryChangedHandler(InventoryChangedEventType eventType, Item item);
}

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private Item[] Items;

    public event InventoryEvents.InventoryChangedHandler InventoryChanged;

    private void Awake()
    {
        Instance = this;
    }

    public bool Pickup(Item item)
    {
        if (Items.Any(i => i.UID == item.UID)) return false; // Inventory already contains this item

        Items = Items.Append(item).ToArray();
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemPickedUp, item);
        return true;
    }

    public bool Use(Item item)
    {
        if (!Items.Any(i => i.UID == item.UID)) return false; // Inventory does not contain this item

        Items = Items.Where(i => i.UID != item.UID).ToArray();
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemUsed, item);
        return true;
    }

    public bool Use(ItemType type)
    {
        var item = Items.FirstOrDefault(i => i.Type == type);
        if (item.UID == 0) return false;
        return Use(item);
    }

    public bool HasItemOfType(ItemType type)
    {
        return Items.Any(i => i.Type == type);
    }

    public int CountOfType(ItemType type)
    {
        return Items.Where(i => i.Type == type).Count();
    }
}
