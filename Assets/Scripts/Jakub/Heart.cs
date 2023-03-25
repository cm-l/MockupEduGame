using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    private bool isEmpty;
    public Texture[] texture;
    private RawImage img;

    private void Start()
    {
        img = GetComponent<RawImage>();
        img.texture = texture[1];
    }

    public void SetEmpty(bool state)
    {
        isEmpty = state;
        img.texture = texture[state ? 0 : 1];
    }

    public bool IsEmpty()
    {
        return isEmpty;
    }
}
