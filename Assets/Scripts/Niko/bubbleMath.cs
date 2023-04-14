using TMPro;
using UnityEngine;

public class bubbleMath : MonoBehaviour
{
    public int rValue;
    public TextMeshPro bubbleValue;
    GameObject gmText;

    void Start()
    {
        int rand = Random.Range(0, 20);
        rValue = rand;
        gmText = gameObject.transform.GetChild(0).gameObject;
        bubbleValue = gmText.GetComponent<TextMeshPro>();
        bubbleValue.text = "" + rValue;
    }

    public int GetrVal()
    {
        return rValue;
    }
}
