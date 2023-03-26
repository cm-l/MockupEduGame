using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopCard : MonoBehaviour
{

    public SO_Card card;
    public TextMeshPro priceText;
    public TextMeshPro cardText;
    public Collider coll;
    public int price = 5;

    // Start is called before the first frame update
    void Start()
    {
        PriceSetter();
        cardText.SetText(card.uniqueActionSuffix);        
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
             }
            }
            
        }
    }

//skdfjksf
    void PriceSetter() {
        priceText.SetText("$"+price.ToString());
    }
}
