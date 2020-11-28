using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Inventory.Instance.HasItemOfType(ItemType.Coin))
        {
            MessageView.Instance.SetMessage("Hey! Don’t forget to place all coins in the level. Otherwise the next adventurer will be unable to complete the puzzle");
        }
        else
        {
            Level.Instance.EndLevel(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
         MessageView.Instance.SetMessage("");
    }
}
