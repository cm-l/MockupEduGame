using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    public List<GameObject> cardSlots;

    // Refer to deck
    [HideInInspector] public DeckAvailable deck;

    private void Awake()
    {
        deck = GameObject.Find("Deck Object").GetComponent<DeckAvailable>();
    }

    //TODO przenieœæ klikanie z tej klasy do poszczególnych klas (czyli np. logika klikania w destroyable jest w klasie Destroyable)
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            Ray toMouse = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);

            if (didHit) {
                Debug.Log(rhInfo.collider.name + " " + rhInfo.point);

                //Play (destroy) cards
                Destroyable destScript = rhInfo.collider.GetComponent<Destroyable>();

                //Press next turn button
                TurnButtonMovement turnButtonAnimation = rhInfo.collider.GetComponent<TurnButtonMovement>();


                //ON PLAYING CARD:
                if (destScript) {
                    destScript.playThisCard();
                }

                //ON ENDING TURN
                //TODO zmieniæ to co napisa³em bo to nie wygl¹da jak najlepsza metoda na robienie tego
                if (turnButtonAnimation)
                {
                    //BUTTON ANIMATION
                    turnButtonAnimation.clickedOnAnimation();

                    //CARD LOGIC
                    for (int i = 0; i < cardSlots.Count; i++)
                    {
                        cardSlots[i].GetComponent<Destroyable>().discardThisCard();
                        cardSlots[i].GetComponent<Card>().dealHand();
                    }

                    //IF DECK IS EMPTY -> REFILL USING CARDS FROM DISCARD PILE
                    if (deck.availableCards.Count == 0)
                    {
                        deck.Refill();
                    }
                }

            } else {
                Debug.Log("clicked on empty space");
            }
        }
    }
}
