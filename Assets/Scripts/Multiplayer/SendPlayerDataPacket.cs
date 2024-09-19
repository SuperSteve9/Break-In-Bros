using Steamworks;
using TMPro;
using UnityEngine;

public class SendPlayerDataPacket : MonoBehaviour
{
    string name;
    public TMP_Text text;
    public TMP_Text text2;
    public TMP_Text text3;
    void Start()
    {
        if (SteamManager.Initialized)
        {
            name = SteamFriends.GetPersonaName();
            text.text = $"Name: {name}";
        }
        text3.text = "Waiting for packet..";

        GetSteamIDFromName();

    }

    public void SendPacket(CSteamID recpient)
    {
        byte[] data = System.Text.Encoding.UTF8.GetBytes($"{SteamFriends.GetPersonaName()} says hello!");

        bool success = SteamNetworking.SendP2PPacket(
            recpient,
            data,
            (uint)data.Length,
            EP2PSend.k_EP2PSendReliable,
            0);

        if (success)
        {
            Debug.Log("It was sent");
        }
        else
        {
            Debug.Log("Something went wrong lmao");
        }
    }

    private void Update()
    {
        uint packetSize;

        while (SteamNetworking.IsP2PPacketAvailable(out packetSize))
        {
            byte[] buffer = new byte[packetSize];
            uint bytesRead;
            CSteamID sender;

            if (SteamNetworking.ReadP2PPacket(buffer, packetSize, out bytesRead, out sender))
            {
                string message = System.Text.Encoding.UTF8.GetString(buffer);
                text3.text = $"Recieved packet message {message} from {sender}";
            }
        }
    }

    private void GetSteamIDFromName()
    {
        int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
        text2.text = $"Friend Count: {friendCount}";

        for (int i = 0; i < friendCount; i++)
        {
            CSteamID friendSteamID = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
            string friendName = SteamFriends.GetFriendPersonaName(friendSteamID);
            Debug.Log(friendName);
            SendPacket(friendSteamID);
        }
    }
}