using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooltipSystem : MonoBehaviour
{

    //Tooltip popup
    public Tooltip tooltip;

    //Animation
    public static float showSpeed = 0.72f;
    public static LeanTweenType easingCurve = LeanTweenType.easeInOutQuart;

    public static TooltipSystem Instance { get; private set; }

    private void Awake()
    {
        // start of singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        // end of singleton pattern
    }



    // Start is called before the first frame update
    void Start()
    {
        tooltip = transform.GetChild(0).GetComponent<Tooltip>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Show(string content, string header = "")
    {
        //Debug.Log("Shown.");
        easyIn();
        Instance.tooltip.SetTip(content, header);
        Instance.tooltip.gameObject.SetActive(true);
    }

    public static void Hide()
    {
        //Debug.Log("Hid.");
        Instance.tooltip.gameObject.transform.localScale = new Vector3(0, 0, 0);
        Instance.tooltip.gameObject.SetActive(false);
    }

    public static void easyIn()
    {
        LeanTween.scale(Instance.tooltip.gameObject, new Vector2(1,1), showSpeed).setEase(easingCurve);
    }
}
