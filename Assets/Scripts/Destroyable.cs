using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO zmieniæ nazwê na coœ w stylu Playable, bo u¿ywamy tego do grania kart (co j¹ de facto "niszczy" ale mo¿e siê myliæ)
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


    //TODO mo¿e byæ na PlayMe() albo DiscardMe()
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

        //Odg³os
        SoundSystemSingleton.Instance.PlaySfxSound(card.cardScriptableObject.playSound);

        card.hasBeenPlayed = true;
        //Zmiana wartoœci zdrowia przeciwnika (jeœli przewiduje j¹ karta)
        if (card.cardScriptableObject.offensiveAction != OffensiveAction.none)
        {
            enemy.changeValueByCard(card.cardScriptableObject.damageNumber, card.cardScriptableObject.offensiveAction);
        }

        //Zmniejsz iloœæ many gracza o iloœæ many wymaganej do zagrania karty
        ManagerSingleton.Instance.consumeMana(card.cardScriptableObject.cost);

        //Zmiana stanu defensywy gracza (jeœli przewiduje j¹ karta)
        ManagerSingleton.Instance.ActivateDefensiveActionFromCard(card.cardScriptableObject.barricadeAmount, card.cardScriptableObject.blockAmount, card.cardScriptableObject.healAmount);

        //Wywo³anie funkcji specjalnej akcji (jeœli przewiduje j¹ karta)
        ManagerSingleton.Instance.ActivateSpecialActionFromCardOnPlayer(card.cardScriptableObject.drawAmount, card.cardScriptableObject.sacrificeAmount, card.cardScriptableObject.payAmount);

        //Wywo³anie funkcji unikatowej akcji (jeœli przewiduje j¹ karta)
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
