using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class Level2 : Level
{
    public override string SceneName => "Scenes/DevScenes/Maxime/Level2";
    public override string NextLevelName => "";
    public override string HUD => "Scenes/DevScenes/Maxime/HUDs/HUD2";

    public async override Task Setup()
    {
        await Task.Delay(1000);
    }
}
