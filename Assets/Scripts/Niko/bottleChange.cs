using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleChange : MonoBehaviour
{
    GameObject gm;
    MeshRenderer mr;
    Material bottle;
    public Material bottle2;
    public Material bottle3;
    public Material bottle4;
    public Material bottle5;
    public Material bottle6;
    int bottleMaterialNumber = 0;


    void Start()
    {
        gm = this.gameObject;
        mr = gm.GetComponent<MeshRenderer>();
        bottle = mr.material;
    }

    public void changeMaterial()
    {
        switch (bottleMaterialNumber)
        {
            case 0:
                Debug.Log("bottle");
                break;
            case 1:
                Debug.Log("Bottle1");
                break;
            case 2:
                Debug.Log("Bottle2");
                break;
            case 3:
                Debug.Log("Bottle3");
                break;
            case 4:
                Debug.Log("Bottle 4");
                break;
            case 5:
                Debug.Log("Bottle 5");
                break;
            case 6:
                Debug.Log("Bottle6");
                break;
        }
        
    }
}
