using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class End : Level
{
    public override string SceneName => "Scenes/DevScenes/Maxime/End";
    public override string NextLevelName => "Scenes/DevScenes/Maxime/Menu";

    public Animator Anim;

    public void BackMenu()
    {
        Anim.SetTrigger("Outro");
        var awaiter = Task.Delay(2500).GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            EndLevel(null);
        });
    }
}
