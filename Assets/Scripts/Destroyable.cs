using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO zmieniæ nazwê na coœ w stylu Playable, bo u¿ywamy tego do grania kart (co j¹ de facto "niszczy" wiêc wsm nie wiem)
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
        card.hasBeenPlayed = true;
        //Zmiana wartoœci liczby przeciwnika
        enemy.changeValueByCard(card.cardScriptableObject.number, card.cardScriptableObject.operation);

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
