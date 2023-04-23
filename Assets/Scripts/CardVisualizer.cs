using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardVisualizer : MonoBehaviour
{


    //Card Scriptable Object
    public SO_Card cardScriptableObject;

    private void Start()
    {
        // Refer to SO
        cardScriptableObject = transform.parent.GetComponent<ShopCard>().SOcard;

        // to set material:
        gameObject.GetComponent<MeshRenderer>().material = cardScriptableObject.cardImage;
        // to set equation displayed on card:
        //transform.GetChild(0).GetComponent<TextMeshPro>().SetText(cardScriptableObject.equationDisplayed);
        transform.GetChild(0).GetComponent<TextMeshPro>().SetText(cardScriptableObject.cardText);

        //Set mana/whatever cost on card display
        transform.GetChild(1).GetComponent<TextMeshPro>().SetText(cardScriptableObject.cost.ToString());

        transform.GetChild(2).GetComponent<TextMeshPro>().SetText(cardScriptableObject.name);

        //Set art
        transform.GetChild(3).GetComponent<MeshRenderer>().material = cardScriptableObject.cardArt;
    }

    // Update is called once per frame
    void Update()
    {

    }




    }

