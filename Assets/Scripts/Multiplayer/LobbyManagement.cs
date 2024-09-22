using TMPro;
using UnityEngine;
using Steamworks;

public class LobbyManagement : MonoBehaviour
{
    [Header("UI Elements - Title")]
    public GameObject GameText;
    public GameObject CreateLobbyButton;
    public GameObject JoinLobbyButton;
    public GameObject LobbyIDInputField;
    public GameObject HostIDInputField;

    [Header("UI Elements - Create Lobby")]
    public GameObject LobbyIdTextObject;
    public TMP_Text LobbyIdText;
    public GameObject hostTextObject;
    public GameObject player2TextObject;
    public GameObject player3TextObject;
    public GameObject player4TextObject;
    public GameObject player5TextObject;

    [Header("UI Elements - Join Lobby")]
    public GameObject lobbyIDInputField;
    public GameObject joinLobbyIDButton;

    [Header("Player Info")]
    public TMP_Text hostName;
    public TMP_Text player2Name;
    public TMP_Text player3Name;
    public TMP_Text player4Name;
    public TMP_Text player5Name;

    public int lobbyID;

    private bool slot0 = false;
    private bool slot1 = false;      
    private bool slot2 = false;
    private bool slot3 = false;
    private bool slot4 = false;

    private void Start()
    {
        GameText.SetActive(true);
        CreateLobbyButton.SetActive(true);
        lobbyIDInputField.SetActive(true);
        JoinLobbyButton.SetActive(true);
        HostIDInputField.SetActive(true);
        LobbyIdTextObject.SetActive(false);
        hostTextObject.SetActive(false);
        player2TextObject.SetActive(false);
        player3TextObject.SetActive(false);
        player4TextObject.SetActive(false);
        player5TextObject.SetActive(false);
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
        lobbyID = Random.Range(0, 2147483647);
        Debug.Log(lobbyID);
        GameText.SetActive(false);
        CreateLobbyButton.SetActive(false);
        lobbyIDInputField.SetActive(false);
        JoinLobbyButton.SetActive(false);
        HostIDInputField.SetActive(false);
        LobbyIdText.text = $"Lobby ID: {lobbyID}";
        LobbyIdTextObject.SetActive(true);
        hostName.text = SteamFriends.GetPersonaName();
        hostTextObject.SetActive(true);
        slot0 = true;
    }

    public void AddPlayerToLobby(CSteamID player)
    {
        if (!slot1)
        {
            player2Name.text = SteamFriends.GetFriendPersonaName(player);
            player2TextObject.SetActive(true);
        }
        if (!slot2)
        {
            player3Name.text = SteamFriends.GetFriendPersonaName(player);
            player3TextObject.SetActive(true);
        }
        if (!slot3)
        {
            player4Name.text = SteamFriends.GetFriendPersonaName(player);
            player4TextObject.SetActive(true);
        } if (!slot4)
        {
            player5Name.text = SteamFriends.GetFriendPersonaName(player);
            player5TextObject.SetActive(true);
        }
    }

}
