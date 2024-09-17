using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Court : MonoBehaviour
{
    public class CourtItem
    {
        int str;

        public CourtItem(GameObject evi)
        {
            this.str = evi.GetComponent<Evidence>().strength;
        }
    }

    public List<CourtItem> courtItems;

    public static Court Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadItem(GameObject evidence)
    {
        courtItems.Add(new CourtItem(evidence));
    }
}
