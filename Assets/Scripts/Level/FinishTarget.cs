using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTarget : MonoBehaviour
{
    // public int currentLevel = 1;
    // public string sceneToLoad = "Level2";
    private void OnTriggerEnter(Collider other)
    {
        //Find the gameObject itself with its Tag or Layer it is better way to trying to find its name
        if (other.gameObject.CompareTag("PlayerBall"))
        {
            // MyEventSystem.I.CompleteLevel(1); **Moved this function into LevelManager script
            // SceneManager.LoadSceneAsync(sceneToLoad,LoadSceneMode.Single);
            EventManager.LevelEvents.onLevelPassed?.Invoke();
        }
    }
}
