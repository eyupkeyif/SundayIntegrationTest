using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static LevelEvents LevelEvents= new LevelEvents();
    
}
public class LevelEvents
{
    public Action onLevelPassed;
    public Action onLevelFailed;
}
