using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainMenu : Level
{
    public override string SceneName => "Scenes/DevScenes/Maxime/Menu";
    public override string NextLevelName => "Scenes/DevScenes/Maxime/Level1";

    public void StartGame()
    {
        EndLevel(null);
    }
}
