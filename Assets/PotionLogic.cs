using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionLogic : MonoBehaviour
{
    public int potionIndex;
    [SerializeField] private SO_Potion scriptablePotion;
    private TooltipDisplay tooltip;
    private Image potionSprite;
    [SerializeField] Sprite emptyPotion;

    private void Awake()
    {
        // Grabbing references
        potionSprite = gameObject.GetComponent<Image>();
        tooltip = gameObject.GetComponent<TooltipDisplay>();
    }


    // Start is called before the first frame update
    void Start()
    {

        // n-th potion
        scriptablePotion = DeckTracker.Instance.collectedPotions[potionIndex];

        if (scriptablePotion != null)
        {

            // image
            potionSprite.sprite = scriptablePotion.potionSprite;



            // Tooltip gets filled with info relating to potion
            tooltip.header = scriptablePotion.nameOfPotion;
            tooltip.content = scriptablePotion.description;

        }

        // empty potion display
        else if (scriptablePotion == null)
        {
            tooltip.header = "No potion!";
            tooltip.content = "Either you already drank it or haven't collected any. :(";
            potionSprite.sprite = emptyPotion;
            potionSprite.color = Color.black;

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Effect invoker
    public void callPotionBehaviours()
    {

    }

     // --- POTION BEHAVIOURS ---
    public void healthPotion(int health)
    {
        ManagerSingleton.Instance.Heal(health);
    }
}
