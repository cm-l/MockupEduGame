using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressUI : MonoBehaviour {

    private static TextMeshProUGUI gameStageValue;
    private static TextMeshProUGUI levelTextValue;
    
    void Awake() {
        gameStageValue = GameObject.Find("GameStageValue").GetComponent<TextMeshProUGUI>();
        levelTextValue = GameObject.Find("LevelValue").GetComponent<TextMeshProUGUI>();

        if (GameProgression.GetCurrentGameStage() == 4)
            gameStageValue.text = "3";
        else
            gameStageValue.text = GameProgression.GetCurrentGameStage().ToString();


        if (GameProgression.GetLevelsCompleted() == 12)
            levelTextValue.text = "12/12";
        else
            levelTextValue.text = (GameProgression.GetLevelsCompleted() + 1).ToString() + "/12";
    }
}
