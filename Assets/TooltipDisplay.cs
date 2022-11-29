using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipDisplay : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //Contents
    public string header;
    [TextArea(12, 12)]
    public string content;

    //Delay coroutine 
    //Pls dont use delay() anywhere in the game
    private static LTDescr delay;

    //Using UI Event Systems (for UI canvas elements)
    public void OnPointerEnter(PointerEventData eventData)
    {
        delay = LeanTween.delayedCall(0.5f, () =>
        {
            TooltipSystem.Show(content, header);
        });
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }

    //Using normal rays (for everything else)
    public void OnMouseEnter()
    {
        delay = LeanTween.delayedCall(0.99f, () =>
        {
            TooltipSystem.Show(content, header);
        });
    }

    public void OnMouseExit()
    {
        LeanTween.cancel(delay.uniqueId);
        TooltipSystem.Hide();
    }
}
