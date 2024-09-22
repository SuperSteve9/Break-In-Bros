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

    public void AddEvidence()
    {
        evidenceCount++;
        PlayerPrefs.SetInt("Evidence Count", evidenceCount);
    }
}
