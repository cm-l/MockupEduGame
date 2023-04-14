using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCard : MonoBehaviour
{
    public SO_Card SOcard;
    public GameObject destroyThisCard;
    public TextMeshPro priceText;
    public TextMeshPro cardText;
    public Collider coll;
    public ParticleSystem ps;
    private int price;

    // Start is called before the first frame update
    void Start()
    {
        PriceSetter();
        cardText.SetText(SOcard.uniqueActionSuffix);        
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = coll.Raycast(toMouse, out rhInfo, 500.0f);

            if (ManagerSingleton.Instance.playerGold >= price) {
             if (didHit)
                {
                    Debug.Log(rhInfo.collider.name + " 00000 " + rhInfo.point);
                    ManagerSingleton.Instance.spendGold(price);
                    DeckTracker.Instance.buy(SOcard);
                    GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
                    Destroy(go, 5.0f);
                    Destroy(destroyThisCard);
                  
             }
            }
            
        }
    }
    
    void PriceSetter() {
        if (SOcard.rarity == Rarity.rare) {
            priceText.SetText("$240");
            price = 240;
        } else if (SOcard.rarity == Rarity.special) {
            priceText.SetText("$500");
            price = 500;
        } else { 
            priceText.SetText("$120");
            price = 120;

        }

    }

}
