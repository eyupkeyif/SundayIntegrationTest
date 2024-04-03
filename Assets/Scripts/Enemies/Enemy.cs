using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    // public int currentLevel = 1;
    // public string sceneToLoad = "Level1";

    private void OnCollisionEnter(Collision collision)
    {
        //Find the gameObject itself with its Tag or Layer it is better way to trying to find its name
        if (collision.gameObject.CompareTag("PlayerBall"))
        {
            // MyEventSystem.I.FailLevel(currentLevel); **Moved this function into LevelManager script.
            // SceneManager.LoadScene(sceneToLoad);
            EventManager.LevelEvents.onLevelFailed?.Invoke();
        }
    }
}
