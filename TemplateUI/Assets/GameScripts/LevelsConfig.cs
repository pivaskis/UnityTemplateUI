using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Game/Config/LevelsConfig")]
public class LevelsConfig : ScriptableObject
{
    public List<LevelConfig> Levels;
}

[Serializable]
public class LevelConfig
{
    public int levelNumber;
    public int ballsCount;
    public int winnableScore;
    public int LevelScore=10;
}
