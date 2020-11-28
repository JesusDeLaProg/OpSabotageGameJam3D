using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    private const int COIN_AMOUNT = 3;

    public GameObject[] CoinsUI;

    private void Start()
    {
        for (int i = 0; i < COIN_AMOUNT; i++)
        {
            //Coins are active by default
            CoinsUI[i].SetActive(true);
        }
    }

    //Will be activated with inventory
    private void OnCoinAmountChanged()
    {
        int coinAmount = 2;
        for (int i = 0; i < COIN_AMOUNT; i++)
        {
            CoinsUI[i].SetActive(i < coinAmount);
        }
    }
}
