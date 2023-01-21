using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArtifactDetailsUI : MonoBehaviour
{

    public SO_Artifact artifactSO;
    public Image image;

    void Awake()
    {
        //Refer to image
        image = gameObject.GetComponent<Image>();
    }

    void Start()
    {
        //Set upper corner image
        image.sprite = artifactSO.artifactSprite;

        //Set tooltip to the artifact info
        gameObject.GetComponent<TooltipDisplay>().content = artifactSO.description;
        gameObject.GetComponent<TooltipDisplay>().header = artifactSO.nameOfArtifact;
    }
}
