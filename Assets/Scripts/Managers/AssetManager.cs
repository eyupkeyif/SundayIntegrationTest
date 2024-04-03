using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class AssetManager : Singleton<AssetManager>
{
    private const string LEVEL_PATH = "Levels";
    public LevelData LoadLevel(int levelIndex)
    {
        return Resources.Load<LevelData>(LEVEL_PATH + "/Level" + levelIndex);
    }
    public List<LevelData> LoadAllLevels()
    {
        return Resources.LoadAll<LevelData>(LEVEL_PATH).ToList();
    }
}
