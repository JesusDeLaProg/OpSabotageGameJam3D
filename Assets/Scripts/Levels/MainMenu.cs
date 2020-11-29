using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MainMenu : Level
{
    public override string SceneName => "Scenes/DevScenes/Maxime/Menu";
    public override string NextLevelName => "Scenes/DevScenes/Maxime/LevelTest";

    public Animator Anim;

    public void StartGame()
    {
        Anim.SetTrigger("Outro");
        var awaiter = Task.Delay(2500).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            EndLevel(null);
        });
    }
}
