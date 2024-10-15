using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsConfig", menuName = "Game/Config/LevelsConfig")]
public class LevelsConfig : ScriptableObject
{
    public List<LevelConfig> Levels;

    public LevelConfig GetNextLevelConfig(int currentLevel) => 
        Levels.Count>currentLevel 
            ? Levels[currentLevel+1] 
            : null;
    
}

[Serializable]
public class LevelConfig
{
    public int levelNumber;
    public int ballsCount;
    public int winnableScore;
}
