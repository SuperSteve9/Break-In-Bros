using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Steamworks;

public class LobbyManagement : MonoBehaviour
{
    [Header("UI Elements - Title")]
    public GameObject GameText;
    public GameObject CreateLobbyButton;

    [Header("UI Elements - Create Lobby")]
    public GameObject LobbyIdTextObject;
    public TMP_Text LobbyIdText;
    public GameObject hostTextObject;
    public GameObject player2TextObject;
    public GameObject player3TextObject;
    public GameObject player4TextObject;

    [Header("UI Elements - Join Lobby")]
    public GameObject lobbyIDInputField;
    public GameObject joinLobbyIDButton;

    [Header("Player Info")]
    public TMP_Text hostName;
    public TMP_Text player2Name;
    public TMP_Text player3Name;
    public TMP_Text player4Name;

    public int lobbyID;

    private void Start()
    {
        GameText.SetActive(true);
        CreateLobbyButton.SetActive(true);
        LobbyIdTextObject.SetActive(false);
        hostTextObject.SetActive(false);
        player2TextObject.SetActive(false);
        player3TextObject.SetActive(false);
        player4TextObject.SetActive(false);

    }
    public void CreateLobby()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log("Steam loaded correctly.");
        }
        else
        {
            Debug.Log("Steam didn't load correctly.");
            return;
        }
        lobbyID = Random.Range(0, 999999);
        Debug.Log(lobbyID);
        GameText.SetActive(false);
        CreateLobbyButton.SetActive(false);
        LobbyIdText.text = $"Lobby ID: {lobbyID}";
        LobbyIdTextObject.SetActive(true);
        hostName.text = SteamFriends.GetPersonaName();
        hostTextObject.SetActive(true);
    }

    public void AddPlayerToLobby(CSteamID player)
    {
        player2Name.text = SteamFriends.GetFriendPersonaName(player);
    }

}
