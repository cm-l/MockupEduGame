using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawArtifactsUI : MonoBehaviour
{

    private List<SO_Artifact> displayedArtifacts;
    public GameObject artifact;

    // Start is called before the first frame update
    void Start()
    {
        displayedArtifacts = DeckTracker.Instance.collectedArtifacts;

        for (int i = 0; i < displayedArtifacts.Count; i++)
        {
            GameObject artifactDrawn = Instantiate(artifact, transform);
            artifactDrawn.GetComponent<ArtifactDetailsUI>().artifactSO = displayedArtifacts[i];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
