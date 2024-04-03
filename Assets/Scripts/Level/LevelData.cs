using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "LevelData", order = 0)]
public class LevelData : ScriptableObject 
{
    public Level level;
}

[Serializable]
public class Level
{
    public int levelNumber;
    public GameObject levelPrefab;
}
