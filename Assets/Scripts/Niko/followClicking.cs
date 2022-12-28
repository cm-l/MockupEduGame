using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followClicking : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray toMouse = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit rhInfo;
            bool didHit = Physics.Raycast(toMouse, out rhInfo, 10f);

            if (didHit)
            {
                Debug.Log(rhInfo.collider.name + " " + rhInfo.point);
                bubbleDestroy destScript = rhInfo.collider.GetComponent<bubbleDestroy>();

                if (destScript)
                {
                    destScript.RemoveMe();
                }
            }
            else
            {
                Debug.Log("clicked on empty space");
            }
        }
    }
}
