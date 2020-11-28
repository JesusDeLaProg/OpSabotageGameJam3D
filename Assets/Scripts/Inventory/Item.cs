using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    None,
    Key,
    Coin
}

public class Item : MonoBehaviour
{
    private static uint lastUID = 0;
    private Dictionary<ItemType, uint> lastTID =
    new Dictionary<ItemType, uint>{
        {ItemType.None, 0},
        {ItemType.Key, 0},
        {ItemType.Coin, 0}
    };

    public uint UID { get; private set; } = 0; // Unique ID
    public uint TID { get; private set; } = 0; // Type ID
    public ItemType Type;

    public void Start()
    {
        UID = ++lastUID;
        uint lastTypeId = lastTID[Type];
        ++lastTypeId;
        TID = lastTypeId;
        lastTID[Type] = lastTypeId;
    }

}
