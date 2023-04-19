using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour {

    [SerializeField] private static int levelsCompleted = 0;
    [SerializeField] private static int currentGameStage = 1;
    
    public static void AddLevelsCompleted() {
        levelsCompleted++;
    }

    public static int GetLevelsCompleted() {
        return levelsCompleted;
    }

    public static int GetCurrentGameStage() {
        return currentGameStage;
    }

    public static void UpdateGameStage() {
        if (levelsCompleted == 12) {
            currentGameStage = 4;
        }
        else if (levelsCompleted >= 8)
            currentGameStage = 3;
        else if (levelsCompleted >= 4)
            currentGameStage = 2;
        else
            currentGameStage = 1;
    }
}
