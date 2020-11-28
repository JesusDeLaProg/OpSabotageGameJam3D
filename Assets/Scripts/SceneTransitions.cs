using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitions
{
    public delegate void LevelEndedHandler(object sender, bool? victory); // True = Victory, False = Defeat, null = Neutral
    public delegate void LevelSetupFinishedHandler(object sender);
    public delegate void LevelTransitionFinishedHandler(object sender);
}
