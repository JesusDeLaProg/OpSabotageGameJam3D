using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Level3 : Level
{
    public override string SceneName => "Scenes/DevScenes/Maxime/Level3";
    public override string NextLevelName => "End";
    public override string HUD => "Scenes/DevScenes/Maxime/HUDs/HUD1";

    public async override Task Setup()
    {
        await Task.Delay(1000);
    }
}
