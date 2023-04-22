using TMPro;
using UnityEngine;

public class bubbleMath : MonoBehaviour
{
    public int rValue;
    public TextMeshPro bubbleValue;
    GameObject gmText;
    int currentGameStage;

    void Start()
    {
        currentGameStage = GameProgression.GetCurrentGameStage();
        //currentGameStage = 3;
        rValue = createRValue();
        gmText = gameObject.transform.GetChild(0).gameObject;
        bubbleValue = gmText.GetComponent<TextMeshPro>();
        bubbleValue.text = "" + rValue;

    }

    private int createRValue()
    {
        int maxValue;

        if (currentGameStage == 1)
        {
            maxValue = 20;
        } else if (currentGameStage == 2)
        {
            maxValue = 30;
        } else
        {
            maxValue = 50;
        }

        //Debug.Log("Current maxValue: " + maxValue);

        return Random.Range(0, maxValue);
    }

    public int GetrVal()
    {
        return rValue;
    }
}
