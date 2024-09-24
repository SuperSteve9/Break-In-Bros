using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    [Header("Game Settings")]
    public int selectedScene;

    private int playerCount = 1;
    private Transform players;

    // Start is called before the first frame update
    void Start()
    {
        players = GameObject.Find("Players").transform;
        playerCount = players.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // This function generates a random number out of all of the total players to pick one to be the homeowner (multiplayer only)
    // This function generates a 0 or 1 to determine if player is homeowner or not (singleplayer only), other role is an AI
    public void LoadMain()
    {
        if (playerCount != 1)
        {
            int chosenPlayer = Random.Range(0, playerCount);
            PlayerPrefs.GetString("Homeowner", players.GetChild(chosenPlayer).name);

            SceneManager.LoadScene(selectedScene);
        }
        else
        {
            int chosenMode = Random.Range(0, 2);

            if (chosenMode == 1)
            {
                PlayerPrefs.GetString("Homeowner", players.GetChild(0).name);
            }
        }
    }
}
