using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO zmieni� nazw� na co� w stylu Playable, bo u�ywamy tego do grania kart (co j� de facto "niszczy" ale mo�e si� myli�)
public class Destroyable : MonoBehaviour
{
    public Card card;
    public ParticleSystem ps;
    public EnemyBehaviuur enemy;

    public void Awake()
    {
        card = gameObject.GetComponent<Card>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();
    }


    //TODO mo�e by� na PlayMe() albo DiscardMe()
    public void RemoveMe() {
        Debug.Log("Destroyable's remove function is called on " + name);
        GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
        Destroy(go, 2.0f);

        //Destroy(this.gameObject);

        // "soft" destroy
        // Not actually deleting anything, just move it away
        card.dnPos = new Vector3(100, 100, 100);
        transform.position = new Vector3(0, -75, 0);
    }

    public void playThisCard()
    {

        //Odg�os
        SoundSystemSingleton.Instance.PlaySfxSound(card.cardScriptableObject.playSound);

        card.hasBeenPlayed = true;
        //Zmiana warto�ci zdrowia przeciwnika (je�li przewiduje j� karta)
        if (card.cardScriptableObject.offensiveAction != OffensiveAction.none)
        {
            enemy.changeValueByCard(card.cardScriptableObject.damageNumber, card.cardScriptableObject.offensiveAction);
        }

        //Zmniejsz ilo�� many gracza o ilo�� many wymaganej do zagrania karty
        ManagerSingleton.Instance.consumeMana(card.cardScriptableObject.cost);

        //Zmiana stanu defensywy gracza (je�li przewiduje j� karta)
        ManagerSingleton.Instance.ActivateDefensiveActionFromCard(card.cardScriptableObject.barricadeAmount, card.cardScriptableObject.blockAmount, card.cardScriptableObject.healAmount);

        //Wywo�anie funkcji specjalnej akcji (je�li przewiduje j� karta)
        ManagerSingleton.Instance.ActivateSpecialActionFromCardOnPlayer(card.cardScriptableObject.drawAmount, card.cardScriptableObject.sacrificeAmount, card.cardScriptableObject.payAmount);

        //Wywo�anie funkcji unikatowej akcji (je�li przewiduje j� karta)
        //ManagerSingleton.Instance.funkcjaoileistniejetojestwywolywanawtymmiejscu();



        //Usuwanie karty
        RemoveMe();
        card.addToDiscardPile();
    }

    public void discardThisCard()
    {
        if (card.hasBeenPlayed == false)
        {
            RemoveMe();
            card.addToDiscardPile();
        }
    }
}
