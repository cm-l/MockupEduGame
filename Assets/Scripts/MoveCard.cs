using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCard : MonoBehaviour
{
    [Header("\nHovering over card")]
    private Vector3 selectedPosition;
    private Vector3 initialPosition;
    [SerializeField] private float selectedHeight = 0.05f;
    [SerializeField] private float selectionSpeed = 0.4f;
    [SerializeField] private LeanTweenType easingUp;
    [SerializeField] private LeanTweenType easingDown;
    [HideInInspector] public bool wentUp = false;

    [Header("\nDrawing card")]
    [SerializeField] private float drawingSpeed = 0.8f;
    [SerializeField] private LeanTweenType easingDrawing;
    [SerializeField] private AudioClip cardSwish;

    // Start is called before the first frame update
    void Awake()
    {
        initialPosition = transform.position;
        selectedPosition = initialPosition + Vector3.up * selectedHeight;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void highlightUp()
    {
        if (!wentUp)
        {
            LeanTween.moveLocalY(gameObject, selectedHeight, selectionSpeed).setEase(easingUp).setOnCompleteParam(wentUp = true);
        }
        else
        {
            LeanTween.moveY(gameObject, initialPosition.y, selectionSpeed).setEase(easingDown).setOnCompleteParam(wentUp = false);
        }
    }

    public void drawCardAnimation(int delayedBy)
    {
        LeanTween.move(gameObject, initialPosition, drawingSpeed).setEase(easingDrawing).setDelay((float)delayedBy / 8).setOnComplete(SwishCard);
        SoundSystemSingleton.Instance.PlaySfxSound(cardSwish);
    }

    private void SwishCard()
    {
        // shhwwwsh sound
        SoundSystemSingleton.Instance.PlaySfxSound(cardSwish);
    }
}
