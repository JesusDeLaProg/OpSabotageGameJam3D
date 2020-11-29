using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Level1 : Level
{
    public override string SceneName => "Scenes/DevScenes/Maxime/Level1";
    public override string NextLevelName => "Scenes/DevScenes/Maxime/Level2";
    public override string HUD => "Scenes/DevScenes/Maxime/HUDs/HUD1";

    public async override Task Setup()
    {
        GameState.CurrentInventory.Items = new Dictionary<ItemType, int>
        {
            { ItemType.Key, 0 },
            { ItemType.Coin, 3 }
        };
        GameState.CurrentInventory.BaddiesToWakeup = 1;
    }

<<<<<<< HEAD
=======
    public async override Task PlayEndLevelTransition(bool? victory)
    {

    }

    public override bool WinConditionMet
    {
        get
        {
            if(GameState.CurrentInventory)
            {
                return GameState.CurrentInventory.Items[ItemType.Coin] == 0 &&
                    GameState.CurrentInventory.Items[ItemType.Key] == 0 &&
                    GameState.CurrentInventory.BaddiesToWakeup == 0;
            }
            return false;
        }
    }
>>>>>>> 566860a766602115cdb44ee038f7821b11212e08
}
