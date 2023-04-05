using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpecialCardAction : MonoBehaviour
{
 public void doSpecialAction(SO_Card socard)
    {

        for (int i = 0; i < socard.effect.Count; i++)
        {
            if (socard.effect[i] == "toxic")
            {
                applyToxic(socard.value[i]);
            }

            if (socard.effect[i] == "weak")
            {
                applyWeak(socard.value[i]);
            }

            if (socard.effect[i] == "fragile")
            {
                applyFragile(socard.value[i]);
            }
        }

        Debug.Log("Yeah");
    }

    public void applyToxic(float value)
    {
        Debug.Log("Applied toxic for " + value);
    }

    public void applyFragile(float value)
    {
        Debug.Log("Applied fragile for " + value);
    }

    public void applyWeak(float value)
    {
        Debug.Log("Applied weak for " + value);
    }
}
