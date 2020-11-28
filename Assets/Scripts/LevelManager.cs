using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    Level currentLevel;
    HUD currentHUD;

    private bool LevelEndTransitionStarted = false;
    private bool LevelEndTransitionEnded = false;
    private bool HUDTransitionStarted = false;
    private bool HUDTransitionEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        SceneManager.sceneLoaded += (Scene scene, LoadSceneMode mode) =>
        {
            Debug.Log("Level Manager : " + (mode == LoadSceneMode.Single ? "Scene" : "HUD") + " Loaded");
            if (mode == LoadSceneMode.Single) SetupLevelEvents();
            else SetupHUDEvents();
        };
        SetupLevelEvents();
    }

    void SetupLevelEvents()
    {
        LevelEndTransitionStarted = false;
        LevelEndTransitionEnded = false;
        HUDTransitionStarted = false;
        HUDTransitionEnded = false;
        currentLevel = FindObjectOfType<Level>();
        LoadHUD(currentLevel.HUD);
        currentLevel.LevelSetupFinished += (object level) => { Debug.Log("Level Manager : Level setup finished"); }; // Activate Player Controller

        currentLevel.LevelEnded += (object level, bool? victory) =>
        {
            Debug.Log("Level Manager : Level Ended (" + (victory.HasValue ? (victory.Value ? "Victory" : "Defeat") : "Neutral") + ")");
            // Deactivate Player controler
            LevelEndTransitionStarted = true;
            if (victory.HasValue)
            {
                if (victory.Value && currentLevel.VictoryHUD != null)
                {
                    Debug.Log("Level Manager : HUD Loaded");
                    HUDTransitionStarted = true;
                    LoadHUD(currentLevel.VictoryHUD);
                }
                else if (!victory.Value && currentLevel.DefeatHUD != null)
                {
                    Debug.Log("Level Manager : HUD Loaded");
                    HUDTransitionStarted = true;
                    LoadHUD(currentLevel.DefeatHUD);
                }
            }
        };
        currentLevel.LevelTransitionFinished += (object level) =>
        {
            Debug.Log("Level Manager : Level transition ended");
            LevelEndTransitionEnded = true;
            if (!HUDTransitionStarted || HUDTransitionEnded) LoadScene(currentLevel.NextLevelName);
        };
    }

    void SetupHUDEvents()
    {
        currentHUD = FindObjectOfType<HUD>();
        currentHUD.HUDAnimationEnded += (object hud) =>
        {
            Debug.Log("Level Manager : HUD transition ended");
            HUDTransitionEnded = true;
            if (LevelEndTransitionStarted && LevelEndTransitionEnded) LoadScene(currentLevel.NextLevelName);
        };
    }

    void LoadScene(string sceneName)
    {
        if (sceneName == null || sceneName.Length == 0) return;
        SceneManager.LoadSceneAsync(sceneName);
    }

    void LoadHUD(string HUDName)
    {
        if(currentHUD)
        {
            var unloadTask = SceneManager.UnloadSceneAsync(currentHUD.SceneName);
            if (HUDName == null || HUDName.Length == 0) return;
            unloadTask.completed += (AsyncOperation op) =>
            {
                Debug.Log("Level Manager : HUD unloaded");
                SceneManager.LoadSceneAsync(HUDName, LoadSceneMode.Additive);
            };
        }
        else if(HUDName != null && HUDName.Length != 0)
        {
            SceneManager.LoadSceneAsync(HUDName, LoadSceneMode.Additive);
        }
    }
}
