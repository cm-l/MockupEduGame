using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    // What is in the tooltip?
    public TextMeshProUGUI headerText;
    public TextMeshProUGUI contentText;

    //Layout
    public LayoutElement layoutElement;

    //Wrap
    public int wrapLimit;

    //Dynamic anchoring
    public RectTransform reTrans;

    //Contextual tips
    public void SetTip(string content, string header = "")
    {
        //Disable header if empty (no reason to put spaces in it)
        if (string.IsNullOrEmpty(header))
        {
            headerText.gameObject.SetActive(false);
        }
        else
        {
            headerText.gameObject.SetActive(true);
            headerText.text = header;
        }

        contentText.text = content;
    }



    // Start is called before the first frame update
    void Awake()
    {
        headerText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        contentText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        layoutElement = gameObject.GetComponent<LayoutElement>();

        //Anchors
        reTrans = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        // for previewing in edit mode
        if (Application.isEditor)
        {
            int headerLength = headerText.text.Length;
            int contentLength = contentText.text.Length;

            //Disable or enable layout based on the amount of characters included in our tooltips
            if (headerLength > wrapLimit || contentLength > wrapLimit)
            {
                layoutElement.enabled = true;
            }
            else
            {
                layoutElement.enabled = false;
            }
        }

        // Move towards cursor
        Vector2 mouseVector = Input.mousePosition;
        float pivotX = mouseVector.x / Screen.width;
        float pivotY = mouseVector.y / Screen.height;
        // Change anchor towards the middle of the screen
        reTrans.pivot = new Vector2(pivotX, pivotY);
        transform.position = mouseVector;
    }

}
