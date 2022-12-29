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
    int bottleMaterialNumber;


    void Start()
    {
        gm = this.gameObject;
        mr = gm.GetComponent<MeshRenderer>();
        bottle = mr.material;
        bottleMaterialNumber = 1;
    }

    public void checkMaterial()
    {
        switch (bottleMaterialNumber)
        {
            case 1:
                mr.material = bottle;
                break;
            case 2:
                mr.material = bottle2;
                break;
            case 3:
                mr.material = bottle3;
                break;
            case 4:
                mr.material = bottle4;
                break;
            case 5:
                mr.material = bottle5;
                break;
            case 6:
                mr.material = bottle6;
                break;
            default:
                Debug.Log("Error in Switch-Case instruction in bottleChange " +
                    "script in changeMaterial() method");break;
        }
        
    }


    public void changeMaterialUp()
    {
        bottleMaterialNumber++;
    }

    public void changeMaterialDown()
    {
        if (bottleMaterialNumber > 1)
        {
            bottleMaterialNumber--;
        }
    }

    public int getBottleMaterialNumber()
    {
        return bottleMaterialNumber;
    }

    private void Update()
    {
        checkMaterial();
    }
}
