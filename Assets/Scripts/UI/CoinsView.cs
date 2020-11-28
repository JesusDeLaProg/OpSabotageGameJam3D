using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryEvents;

public class CoinsView : InventoryView
{
    public GameObject[] CoinsUI;

    protected override void UpdateView()
    {
        int coinAmount = GetAmount();
        for (int i = 0; i < 3; i++)
        {
            CoinsUI[i].SetActive(i < coinAmount);
        }
    }
}
