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
    public Material bottle7;
    public Material bottle8;
    public Material bottle9;
    public static int bottleMaterialNumber;

    void Start()
    {
        gm = gameObject;
        mr = gm.GetComponent<MeshRenderer>();
        bottle = mr.material;
        bottleMaterialNumber = 1;
    }

    public void CheckMaterial()
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
            case 7:
                mr.material = bottle7;
                break;
            case 8:
                mr.material = bottle8;
                break;
            case 9:
                mr.material = bottle9;
                break;
            default:
                Debug.Log("Error in Switch-Case instruction in bottleChange " +
                    "script in CheckMaterial() method");break;
        }
        
    }


    public void ChangeMaterialUp()
    {
        bottleMaterialNumber++;
    }

    public void ChangeMaterialDown()
    {
        if (bottleMaterialNumber > 1)
        {
            bottleMaterialNumber--;
        }
    }

    public int GetBottleMaterialNumber()
    {
        return bottleMaterialNumber;
    }

    private void Update()
    {
        CheckMaterial();
    }
}
