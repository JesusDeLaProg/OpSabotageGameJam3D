using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InventoryEvents;

public class CoinsView : InventoryView
{
    public GameObject[] CoinsUI;

    private void Start()
    {
        int coinAmount = Inventory.Instance.CountOfType(Type);
        for (int i = 0; i < coinAmount; i++)
        {
            //Coins are active by default
            CoinsUI[i].SetActive(true);
        }
    }

    protected override void UpdateView()
    {
        int coinAmount = GetAmount();
        for (int i = 0; i < coinAmount; i++)
        {
            CoinsUI[i].SetActive(i < coinAmount);
        }
    }
}
