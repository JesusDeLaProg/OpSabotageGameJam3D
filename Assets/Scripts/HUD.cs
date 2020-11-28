using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public event SceneTransitions.LevelTransitionFinishedHandler HUDAnimationEnded;

    public string SceneName => "";

    public async void Start()
    {
        await PlayTransition();
        HUDAnimationEnded?.Invoke(this);
    }

    public async virtual Task PlayTransition()
    {

    }
}
