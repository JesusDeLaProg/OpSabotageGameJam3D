using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level Instance;

    public event SceneTransitions.LevelSetupFinishedHandler LevelSetupFinished;
    public event SceneTransitions.LevelEndedHandler LevelEnded;
    public event SceneTransitions.LevelTransitionFinishedHandler LevelTransitionFinished;

    public virtual string SceneName => "";
    public virtual string HUD => null;
    public virtual string VictoryHUD => null;
    public virtual string DefeatHUD => null;
    public virtual string NextLevelName => null;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    async void Start()
    {
        await Setup();
        LevelSetupFinished?.Invoke(this);
        AIController.Active = true;
        CharacterMovement.Active = true;
    }

    public async virtual Task Setup()
    {
        // Level Setup (Startup animations)
    }

    public async void EndLevel(bool? victory)
    {
        AIController.Active = false;
        CharacterMovement.Active = false;
        LevelEnded?.Invoke(this, victory);
        await PlayEndLevelTransition(victory);
        LevelTransitionFinished?.Invoke(this);
        CharacterMovement._levelEnded?.Invoke();
    }

    public async virtual Task PlayEndLevelTransition(bool? victory)
    {
        // Victory/Defeat animations
    }
}
