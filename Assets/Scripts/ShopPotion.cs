using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopPotion : MonoBehaviour
{
    public SO_Potion SOPotion;
    public GameObject destroyThisPotion;
    public TextMeshPro priceText;
    public TextMeshPro potionText;
    public SpriteRenderer spriteRenderer;
    public Collider coll;
    public ParticleSystem ps;
    private int price;
    void Start()
    {
        PriceSetter();
        potionText.SetText(SOPotion.description);
        spriteRenderer.sprite = SOPotion.potionSprite;
        
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
                    DeckTracker.Instance.buy(SOPotion);
                    GameObject go = Instantiate(ps.gameObject, transform.position, Quaternion.identity);
                    Destroy(go, 5.0f);
                    Destroy(destroyThisPotion);
                  
             }
            }
            
        }
    }

    void PriceSetter() {
        priceText.SetText("$"+SOPotion.costInShop.ToString());
        price = SOPotion.costInShop;
    }
}
