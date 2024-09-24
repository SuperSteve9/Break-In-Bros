using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Transform players;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("Players").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DetermineMode()
    {
        // For when player is loaded into map scene lobby selected
        // Determines whether a player is homeowner or not

        // a player prefab is instanitated with the a player's steam user name
        // Then a for loop iterating through each player in Players sees whether a player in Players matches the randomly generated number in LoadGame.cs
        // If the name matches the name stored in PlayerPrefs, that player is the homeowner (since theres only one homeowner)
    }
}
