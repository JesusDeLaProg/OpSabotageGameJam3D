using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        if (!GameState.CurrentLevel.WinConditionMet)
        {
            GameState.CurrentMessageView.SetMessage("Hey! Don’t forget to place all the keys and coins in the level. Otherwise the next adventurer will be unable to complete the puzzle");
        }
        else
        {
            GameState.CurrentLevel.EndLevel(true);
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player")
        {
            return;
        }
        GameState.CurrentMessageView.SetMessage("");
    }
}
