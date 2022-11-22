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

    //Pile of discarded (and already played) cards
    public DiscardPile discardPile;

    //Which card is it? (leftmost = 0, rightmost = 4)
    public int whichCard;

    //Is it the first turn? has it been played?
    public bool firstTurn = true;
    public bool hasBeenPlayed = false;
    public int turnNumber;


    private void Awake()
    {
        // Refer to the Deck of available cards
        deckAvailable = GameObject.Find("Deck Object").GetComponent<DeckAvailable>();

        // Refer to the discard pile (graveyard)
        discardPile = GameObject.Find("Graveyard").GetComponent<DiscardPile>();

        //Refer to where the card position starts (ju¿ nie pamiêtam po co)
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

        cardAnimation.drawCardAnimation(whichCard);

        //Reset card's played state
        hasBeenPlayed = false;

        //Set Card SO based on what you draw from the Deck
        try
        {
            //Get a card from the deck
            cardScriptableObject = deckAvailable.availableCards[whichCard];            

            //Remove card from available cards
            deckAvailable.availableCards.RemoveAt(whichCard);
        }
        catch
        {
                //TODO zrobiæ coœ z tym!!!!!!!!!! ktoœ m¹drzejszy musi to naprawiæ :(
                Debug.Log("Card needed at index: " + whichCard);
                Debug.Log("Largest remaining index: (none if -1) " + (deckAvailable.availableCards.Count-1) + ". Inserting burned card.");
                //Or if there's no more cards in the deck, give the player a "burned" card
                cardScriptableObject = DeckTracker.Instance.burnedCard;
        }


        // Refer to SO
        // to set material:
        gameObject.GetComponent<MeshRenderer>().material = cardScriptableObject.cardImage;
        // to set equation displayed on card:
        transform.GetChild(0).GetComponent<TextMeshPro>().SetText(cardScriptableObject.equationDisplayed);
    }

    public void addToDiscardPile()
    {
        discardPile.discardedCards.Add(cardScriptableObject);
    }

    public void discardHand()
    {
        // A dealt hand resets the ENTIRE hand (you dont get to keep cards between turns)
        // Like in: Slay the Spire
        gameObject.GetComponent<Destroyable>().RemoveMe();
        firstTurn = false;
    }
}
