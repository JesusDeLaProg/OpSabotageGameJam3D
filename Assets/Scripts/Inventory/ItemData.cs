using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ItemData", order = 1)]
public class ItemData : ScriptableObject
{
    public uint UID = 0;     // Unique ID
    public uint TID = 0;      // Type ID (Star #1, Key #2, etc)
    public ItemType Type = ItemType.None; // Type (Key, Star, etc.)
}

public enum ItemType
{
    None,
    Key,
    Coin
}
