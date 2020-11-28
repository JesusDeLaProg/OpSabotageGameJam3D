using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public ItemData Data;

    public ItemType Type => Data.Type;
    public uint UID => Data.UID;
    public uint TID => Data.TID;
}
