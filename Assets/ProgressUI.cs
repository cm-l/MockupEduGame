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
    }

    // Update is called once per frame
    void Update() {
        gameStageValue.text = GameProgression.GetCurrentGameStage().ToString();
        levelTextValue.text = (GameProgression.GetLevelsCompleted() + 1).ToString();
    }
}
