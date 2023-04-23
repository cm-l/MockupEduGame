using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayEndAnimation : MonoBehaviour
{
    public Button myButton1;
    public Button myButton2;
    public Button myButton3;
    public Animator animator;
    public string triggerName;

    void Start()
    {
        myButton1.onClick.AddListener(PlayAnimation);
        myButton2.onClick.AddListener(PlayAnimation);
        myButton3.onClick.AddListener(PlayAnimation);
    }

    void PlayAnimation()
    {
        Debug.Log("Button changing animation clicked!");
        animator.SetTrigger(triggerName);
    }
}
