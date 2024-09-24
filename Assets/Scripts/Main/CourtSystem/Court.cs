using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court : MonoBehaviour
{
    public int evidenceCount;
    public int maxEvidenceCount;

    // Start is called before the first frame update
    void Start()
    {
        evidenceCount = 0;
        PlayerPrefs.GetInt("Evidence Count", evidenceCount);
        PlayerPrefs.GetInt("Max Evidence Count", maxEvidenceCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Loads number of evidence each time one is picked up to check when court is loaded if it is enough
    public void AddEvidence()
    {
        evidenceCount++;
        PlayerPrefs.SetInt("Evidence Count", evidenceCount);
    }
}
