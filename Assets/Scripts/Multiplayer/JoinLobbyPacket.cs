using UnityEngine;
using Steamworks;
using System.Text;
using TMPro;
using System.Collections;

public class JoinLobbyPacket : MonoBehaviour
{

    public LobbyManagement lm;
    public TMP_InputField inputFieldLobbyID;
    public TMP_InputField inputFieldSteamID;

    private Callback<P2PSessionRequest_t> p2pSessionRequest;
    private Callback<P2PSessionConnectFail_t> p2pSessionConnectFail;

    void Start()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log("Steam loaded correctly.");
            p2pSessionRequest = Callback<P2PSessionRequest_t>.Create(OnP2PSessionRequest);
            p2pSessionConnectFail = Callback<P2PSessionConnectFail_t>.Create(OnP2PSessionConnectFail);
            StartCoroutine(CheckForPackets());
        }
        else
        {
            Debug.Log("Steam didn't load correctly.");
        }
    }

    private void OnP2PSessionRequest(P2PSessionRequest_t request)
    {
        CSteamID remoteID = request.m_steamIDRemote;
        SteamNetworking.AcceptP2PSessionWithUser(remoteID);
    }

    private void OnP2PSessionConnectFail(P2PSessionConnectFail_t failure)
    {
        Debug.Log("P2P session failed with user " + failure.m_steamIDRemote);
    }

    private IEnumerator CheckForPackets()
    {
        while (true)
        {
            GetJoinPacket();
            yield return new WaitForSeconds(0.1f);
        }
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
        uint bytesRead;
        CSteamID steamID;

        if (SteamNetworking.IsP2PPacketAvailable(out uint packetSize))
        {
            byte[] buffer = new byte[packetSize];
            bool result = SteamNetworking.ReadP2PPacket(
                buffer,
                packetSize,
                out bytesRead,
                out steamID,
                0);

            if (result) 
            {
                Debug.Log("Got packet data.");
                string lobbyID = Encoding.UTF8.GetString(buffer, 0, (int)bytesRead);
                if (lobbyID.Equals(lm.lobbyID.ToString()))
                {
                    Debug.Log($"Adding player {steamID} to lobby");
                    lm.AddPlayerToLobby(steamID);
                } else
                {
                    Debug.Log($"ID in packet doesn't match room id. Local:{lm.lobbyID} Recieved: {lobbyID}");
                }
            } else
            {
                Debug.Log("Packet Data invalid");
            }
        }
    }
}

