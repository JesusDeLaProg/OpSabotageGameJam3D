using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public uint UID = 0;     // Unique ID
    public uint TID = 0;      // Type ID (Star #1, Key #2, etc)
    public string Type = ""; // Type (Key, Star, etc.)
}
