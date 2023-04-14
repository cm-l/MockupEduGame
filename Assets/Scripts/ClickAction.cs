using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAction : MonoBehaviour
{
    public List<GameObject> cardSlots;

    // Refer to deck
    [HideInInspector] public DeckAvailable deck;
    [HideInInspector] public EnemyBehaviuur enemy;

    // Refer to enemy's attack/action
    [HideInInspector] public bool hasTheEnemyActed;

    private void Awake()
    {
        deck = GameObject.Find("Deck Object").GetComponent<DeckAvailable>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();
    }

    //TODO przenie�� klikanie z tej klasy do poszczeg�lnych klas (czyli np. logika klikania w destroyable jest w klasie Destroyable)
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 500.0f);

            if (didHit)
            {
                Debug.Log(rhInfo.collider.name + " " + rhInfo.point);

                //Play (destroy) cards
                Destroyable destScript = rhInfo.collider.GetComponent<Destroyable>();

                //Press next turn button
                TurnButtonMovement turnButtonAnimation = rhInfo.collider.GetComponent<TurnButtonMovement>();


                //ON PLAYING CARD:
                //check if you have the mana
                if (destScript)
                {
                    if ((destScript.card.cardScriptableObject.cost <= ManagerSingleton.Instance.manaCurrentPoints) && destScript.card.cardScriptableObject.payAmount <= ManagerSingleton.Instance.playerGold)
                    {
                        destScript.playThisCard();
                    }
                }


                // ----------- TURN LOGIC ---------
                //ON ENDING TURN
                //TODO caaaaa�� t� logik� przenie�� do osobnej klasy, albo chocia� do osobnej funkcji
                //TODO zmieni� to co napisa�em bo to nie wygl�da jak najlepsza metoda na robienie tego
                // to na pewno nie jest najlepsza metoda
                if (turnButtonAnimation)
                {
                    //BUTTON ANIMATION
                    turnButtonAnimation.clickedOnAnimation();
                    //Give back all the mana the player can have
                    ManagerSingleton.Instance.manaCurrentPoints += (ManagerSingleton.Instance.manaMaxPoints - ManagerSingleton.Instance.manaCurrentPoints);

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

                    //Check just how much HP the player ends the turn with
                    ManagerSingleton.Instance.endedTurnWithHealth = ManagerSingleton.Instance.playerCurrentHealth - ManagerSingleton.Instance.playerBlockade;

                    if (enemy.poisonAmount > 0)
                    {
                        enemy.takePoisonDamage();
                    }

                    // Engage enemy action
                    // If it is alive
                    if (!enemy.isEnemyDead && hasTheEnemyActed == false)
                    {
                        enemy.enemyActionAttack();
                        hasTheEnemyActed = true;
                    }

                    //BETWEEN TURNS (AFTER ENEMY ATTACK, BUT BEFORE BEING ABLE TO DO ANYTHING)
                    enemy.damageCapability = enemy.enemyScriptableObject.damage;

                    //reset blockade and players HP back
                    ManagerSingleton.Instance.playerBlockade = 0;


                    // check how much starting HP the player has
                    ManagerSingleton.Instance.startedTurnWithHealth = ManagerSingleton.Instance.playerCurrentHealth;
                }
                //Reset has acted state of enemy
                hasTheEnemyActed = false;

                //Reset blocking state
                ManagerSingleton.Instance.hasBlockedAlready = false;

            }

        }
    }
}
