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
        await Task.Delay(1000);
        var awaiter = Task.Delay(5000).GetAwaiter();
     //   awaiter.OnCompleted(() => EndLevel(true));
    }
}
