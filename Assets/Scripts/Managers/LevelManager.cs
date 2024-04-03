using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    private int currentLevel;
    private GameObject playerBall;
    private List<LevelData> levelDatas = new List<LevelData>();

    private GameObject currentLevelPrefab=null;
    private void Awake() 
    {
        levelDatas.Clear();
        levelDatas = AssetManager.Instance.LoadAllLevels();

        //Set the Frame rate as 60 to make more stable FPS.
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        //Basic save system for level
        #region Level Save
        if (PlayerPrefs.HasKey("Level"))
        {
            currentLevel = PlayerPrefs.GetInt("Level");
        }
        else
        {
            currentLevel=1;
            PlayerPrefs.SetInt("Level",currentLevel);
        }
        #endregion

        playerBall = GameObject.FindGameObjectWithTag("PlayerBall");
        EventManager.LevelEvents.onLevelPassed += SuccessLevelHandler;
        EventManager.LevelEvents.onLevelFailed += FailLevelHandler;

        LoadLevel(currentLevel);
    }

    private void SuccessLevelHandler()
    {
        MyEventSystem.I.CompleteLevel(currentLevel);
        currentLevel++;

        if (currentLevel>levelDatas[levelDatas.Count-1].level.levelNumber)
        {
            currentLevel = Random.Range(1,levelDatas.Count);
        }

        PlayerPrefs.SetInt("Level",currentLevel);

        LoadLevel(currentLevel);
    }

    private void FailLevelHandler()
    {
        MyEventSystem.I.FailLevel(currentLevel);
        LoadLevel(currentLevel);
        
        
    }

    public void LoadLevel(int levelNumber)
    {
        if (currentLevelPrefab!=null)
        {
            Destroy(currentLevelPrefab);
        }

        GameObject levelObj = Instantiate(AssetManager.Instance.LoadLevel(currentLevel).level.levelPrefab);
        currentLevelPrefab = levelObj;
        MyEventSystem.I.StartLevel(currentLevel);
    }


}
