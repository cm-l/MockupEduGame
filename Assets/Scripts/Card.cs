using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    //Animation
    private float upAmount = 0.05f;
    private float speed = 0.4f;

    // Float-up animation (first version)
    [HideInInspector] public Vector3 dnPos;
    [HideInInspector] public Vector3 upPos;
    [HideInInspector] public Vector3 currPos;
    [HideInInspector] public Vector3 initialPos;

    // Float-up animation (second version with plugin)
    private MoveCard cardAnimation;

    //Card Scriptable Object
    public SO_Card cardScriptableObject;

    //Deck of cards
    public DeckAvailable deckAvailable;

    //Which card is it? (leftmost = 0, rightmost = 4)
    public int whichCard;


    private void Awake()
    {
        // Refer to the Deck of available cards
        deckAvailable = GameObject.Find("Deck Object").GetComponent<DeckAvailable>();
        initialPos = transform.position;

        // Refer to animation script of card
        cardAnimation = gameObject.GetComponent<MoveCard>();
    }

    void Start()
    {
        //For animations
        dnPos = transform.position;
        upPos = transform.position + Vector3.up*upAmount;
        currPos = dnPos;

        //Dealing hands
        dealHand();



    }

    // Update is called once per frame
    void Update()
    {
        //Hover animation
        //floatUp();

        // Deal hand on R press for debugging only
        if (Input.GetKeyDown(KeyCode.R))
        {
            dealHand();
        }
    }

    private void OnMouseEnter() {
        // First way of doing  this
        //currPos=upPos;

        // Different way of doing this with plugin:
        cardAnimation.highlightUp();
    }
    private void OnMouseExit() {
        // First way of doing this
        //currPos=dnPos;

        // Different way with plugin again
        cardAnimation.highlightUp();
    }

    void floatUp()
    {
        //transform.position = Vector3.MoveTowards(transform.position, currPos, speed * Time.deltaTime);
    }

    public void dealHand()
    {
        //Reset position (instead of SetActive or Instantiating/Destroying objects)
        //transform.position = initialPos;
        //dnPos = initialPos;

        // A dealt hand resets the ENTIRE hand (you dont get to keep cards between turns)
        // Like in: Slay the Spire
        gameObject.GetComponent<Destroyable>().RemoveMe();

        // A dealt hand resets the MISSING cards or a SET NUMBER of cards - not implemented
        // Like in: Hearthstone or Magic: The Gathering
        // jak ktoœ chce to mo¿e spróbowaæ to napisaæ, mi siê troszkê ju¿ nie chce :(


        cardAnimation.drawCardAnimation(whichCard);

        //Set Card SO based on what you draw from the Deck
        try
        {
            //Get a card from the deck
            cardScriptableObject = deckAvailable.availableCards[whichCard];

            //Remove card from available cards
            //TODO add a discard pile (maybe it gets reshuffled like in slay the spire?)
            deckAvailable.availableCards.RemoveAt(whichCard);
        }
        catch
        {
            //Or if there's no more cards in the deck, give the player a "burned" card
            cardScriptableObject = DeckTracker.Instance.burnedCard;
        }


        // Refer to SO
        // to set material:
        gameObject.GetComponent<MeshRenderer>().material = cardScriptableObject.cardImage;
        // to set equation displayed on card:
        transform.GetChild(0).GetComponent<TextMeshPro>().SetText(cardScriptableObject.equationDisplayed);
    }
}
