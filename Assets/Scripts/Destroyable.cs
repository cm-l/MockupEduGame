using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SO_Card;

//TODO zmieniďż˝ nazwďż˝ na coďż˝ w stylu Playable, bo uďż˝ywamy tego do grania kart (co jďż˝ de facto "niszczy" ale moďż˝e siďż˝ myliďż˝)
public class Destroyable : MonoBehaviour
{
    public Card card;
    public ParticleSystem ps;
    public EnemyBehaviuur enemy;
    public SpecialCardAction specialDo;

    public void Awake()
    {
        card = gameObject.GetComponent<Card>();
        enemy = GameObject.Find("Enemy").GetComponent<EnemyBehaviuur>();

        specialDo = gameObject.GetComponent<SpecialCardAction>();
    }


    //TODO moďż˝e byďż˝ na PlayMe() albo DiscardMe()
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

        //Odgďż˝os
        SoundSystemSingleton.Instance.PlaySfxSound(card.cardScriptableObject.playSound);

        card.hasBeenPlayed = true;
        //Zmiana wartoďż˝ci zdrowia przeciwnika (jeďż˝li przewiduje jďż˝ karta)
        if (card.cardScriptableObject.offensiveAction != OffensiveAction.none)
        {
            enemy.changeValueByCard(card.cardScriptableObject.damageNumber, card.cardScriptableObject.offensiveAction);
        }

        //Zmniejsz iloďż˝ďż˝ many gracza o iloďż˝ďż˝ many wymaganej do zagrania karty
        ManagerSingleton.Instance.consumeMana(card.cardScriptableObject.cost);

        //Zmiana stanu defensywy gracza (jeďż˝li przewiduje jďż˝ karta)
        ManagerSingleton.Instance.ActivateDefensiveActionFromCard(card.cardScriptableObject.barricadeAmount, card.cardScriptableObject.blockAmount, card.cardScriptableObject.healAmount);

        //Wywoďż˝anie funkcji specjalnej akcji (jeďż˝li przewiduje jďż˝ karta)
        ManagerSingleton.Instance.ActivateSpecialActionFromCardOnPlayer(card.cardScriptableObject.drawAmount, card.cardScriptableObject.sacrificeAmount, card.cardScriptableObject.payAmount);


        //Wywoďż˝anie funkcji unikatowej akcji (jeďż˝li przewiduje jďż˝ karta)
        //ManagerSingleton.Instance.funkcjaoileistniejetojestwywolywanawtymmiejscu();


        //Wywołanie funkcji unikatowej akcji (jeśli przewiduje ją karta)
        if (card.cardScriptableObject.effect.Count > 0 && card.cardScriptableObject.value.Count > 0)
        {
            specialDo.doSpecialAction(card.cardScriptableObject);
        }
        
        
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
