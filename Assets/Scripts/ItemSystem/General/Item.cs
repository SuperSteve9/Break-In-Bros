using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("General")]
    public int ID;
    public Sprite itemIcon;
    public Vector3 holdPosition;

    [Header("Details")]
    public int sellPrice;
    public bool isEvidence;
    public bool isUsable;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
