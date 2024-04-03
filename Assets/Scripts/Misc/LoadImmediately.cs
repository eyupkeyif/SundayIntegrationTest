using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadImmediately : MonoBehaviour
{
    private void Awake()
    {
        //Use async method to reduce memory usage.
        SceneManager.LoadSceneAsync("LevelScene",LoadSceneMode.Single);
    }
}
