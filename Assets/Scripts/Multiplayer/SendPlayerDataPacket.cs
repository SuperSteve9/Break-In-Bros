using UnityEngine;
using Steamworks;
using System.Text;

public class SendPlayerDataPacket: MonoBehaviour
{

    private void Start()
    {
        if(SteamManager.Initialized)
        {
            Debug.Log("Steam loaded correctly.");
            LoopThroughFriends();
        } else
        {
            Debug.Log("Steam didn't load correctly.");
        }
    }

    private void Update()
    {
        GetPacket();
    }


    private void SendPacket(CSteamID fsid)
    {
        byte[] data = Encoding.UTF8.GetBytes("Test");

        bool result = SteamNetworking.SendP2PPacket(
            fsid,
            data,
            (uint)data.Length,
            EP2PSend.k_EP2PSendReliable,
            0);

        if (result) 
        {
            Debug.Log($"It was sent to {fsid}");
        } else
        {
            Debug.Log("It was not sent.");
        }
    }

    private void LoopThroughFriends()
    {
        int friendCount = SteamFriends.GetFriendCount(EFriendFlags.k_EFriendFlagImmediate);
        for (int i = 0; i < friendCount; i++) 
        {
            CSteamID friendSteamID = SteamFriends.GetFriendByIndex(i, EFriendFlags.k_EFriendFlagImmediate);
            Debug.Log(friendSteamID);
            SendPacket(friendSteamID);
        }
    }

    private void GetPacket() 
    {
        byte[] buffer = new byte[1024];
        uint bytesRead;
        CSteamID fsid;

        if (SteamNetworking.IsP2PPacketAvailable(out uint packetSize))
        {
            bool result = SteamNetworking.ReadP2PPacket(
                buffer,
                packetSize,
                out  bytesRead,
                out fsid,
                0);

            if (result) 
            {
                string message = Encoding.UTF8.GetString(buffer, 0, (int)bytesRead);
                Debug.Log(message);
            }
        }
    }
}