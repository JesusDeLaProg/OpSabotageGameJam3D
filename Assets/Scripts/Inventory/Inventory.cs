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
    public delegate void InventoryChangedHandler(InventoryChangedEventType eventType, ItemData item);
}

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemData[] Items;

    public event InventoryEvents.InventoryChangedHandler InventoryChanged;

    public bool Pickup(Item item)
    {
        if (Items.Any(i => i.UID == item.UID)) return false; // Inventory already contains this item

        Items = Items.Append(item.Data).ToArray();
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemPickedUp, item.Data);
        return true;
    }

    public bool Use(ItemData Data)
    {
        if (!Items.Any(i => i.UID == Data.UID)) return false; // Inventory does not contain this item

        Items = Items.Where(i => i.UID != Data.UID).ToArray();
        InventoryChanged?.Invoke(InventoryEvents.InventoryChangedEventType.ItemUsed, Data);
        return true;
    }

    public bool Use(string type)
    {
        var item = Items.FirstOrDefault(i => i.Type == type);
        if (item.UID == 0) return false;
        return Use(item);
    }

    public bool HasItemOfType(string type)
    {
        return Items.Any(i => i.Type == type);
    }
}
