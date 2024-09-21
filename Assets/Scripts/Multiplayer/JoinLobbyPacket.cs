using UnityEngine;
using Steamworks;
using System.Text;
using TMPro;

public class JoinLobbyPacket : MonoBehaviour
{

    public LobbyManagement lm;
    public TMP_InputField inputFieldLobbyID;
    public TMP_InputField inputFieldSteamID;

    void Start()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log("Steam loaded correctly.");
        }
        else
        {
            Debug.Log("Steam didn't load correctly.");
        }
    }

    private void Update()
    {
        GetJoinPacket();
    }

    public void SendPacket()
    {
        string lobbyID = inputFieldLobbyID.text;
        ulong steamID;

        if (ulong.TryParse(inputFieldSteamID.text, out steamID)) 
        {
            CSteamID fsid = new CSteamID(steamID);
            SendJoinPacket(fsid, lobbyID);
        } else
        {
            Debug.Log("Uh oh you entered the steam id wrong :(");
        }

    }

    private void SendJoinPacket(CSteamID fsid, string lobbyID)
    {
        byte[] data = Encoding.UTF8.GetBytes(lobbyID);

        bool result = SteamNetworking.SendP2PPacket(
            fsid,
            data,
            (uint)data.Length,
            EP2PSend.k_EP2PSendUnreliable,
            0);

        if (result) {
            Debug.Log("Join Request sent!");
        } else
        {
            Debug.Log("An error occured.");
        }
    }

    private void GetJoinPacket()
    {
        byte[] buffer = new byte[1024];
        uint bytesRead;
        CSteamID steamID;

        if (SteamNetworking.IsP2PPacketAvailable(out uint packetSize))
        {
            bool result = SteamNetworking.ReadP2PPacket(
                buffer,
                packetSize,
                out bytesRead,
                out steamID,
                0);

            if (result) 
            {
                string lobbyID = Encoding.UTF8.GetString(buffer, 0, (int)bytesRead);
                if (lobbyID.Equals(lm.lobbyID))
                {
                    lm.AddPlayerToLobby(steamID);
                }
            }
        }
    }
}

