using UnityEngine;
using Steamworks;
using TMPro;
using System.Collections;
using System;

public class JoinLobbyPacket : MonoBehaviour
{

    public LobbyManagement lm;
    public SendingPackets sp;
    public TMP_InputField inputFieldLobbyID;
    public TMP_InputField inputFieldSteamID;

    private Callback<P2PSessionRequest_t> p2pSessionRequest;
    private Callback<P2PSessionConnectFail_t> p2pSessionConnectFail;

    void Start()
    {
        if (SteamManager.Initialized)
        {
            Debug.Log("Steam loaded correctly.");
            var relayStatus = SteamNetworkingUtils.GetRelayNetworkStatus(out SteamRelayNetworkStatus_t status);
            Debug.Log($"Using relay: {status.m_eAvail}");
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
            yield return null;
        }
    }

    public void SendPacket()
    {
        ulong lobbyID;
        ulong steamID;

        if (ulong.TryParse(inputFieldSteamID.text, out steamID)) 
        {
            CSteamID fsid = new CSteamID(steamID);
            if (ulong.TryParse(inputFieldLobbyID.text, out lobbyID))
            {
                sp.SendJoinPacket(fsid, lobbyID);
            }
            else
            {
                Debug.Log("Uh oh you entered the lobby id in wrong :skull:");
            }
        } else
        {
            Debug.Log("Uh oh you entered the steam id wrong :(");
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
                int lobbyID = BitConverter.ToInt32(buffer, 0);
                if (lobbyID == lm.lobbyID)
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

