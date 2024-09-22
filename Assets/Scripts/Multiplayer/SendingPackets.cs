using Steamworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SendingPackets : MonoBehaviour
{
    private void Start()
    {
        if(SteamManager.Initialized)
        {
            Debug.Log("It loaded");
        } else
        {
            Debug.Log("It didn't");
        }
    }

    public void SendJoinPacket(CSteamID fsid, ulong lobbyID)
    {
        byte[] data = BitConverter.GetBytes(lobbyID);

        bool result = SteamNetworking.SendP2PPacket(
            fsid,
            data,
            (uint)data.Length,
            EP2PSend.k_EP2PSendUnreliableNoDelay,
            0);

        if (result)
        {
            Debug.Log("Join Request sent!");
        }
        else
        {
            Debug.Log("An error occured.");
        }
    }

    public void SendLobbyCountPacket(CSteamID fsid, int count)
    {
        byte[] data = BitConverter.GetBytes(count);
        bool result = SteamNetworking.SendP2PPacket(
            fsid,
            data,
            (uint)data.Length,
            EP2PSend.k_EP2PSendUnreliableNoDelay,
            0);

        if (result)
        {
            Debug.Log("Join Request sent!");
        }
        else
        {
            Debug.Log("An error occurred.");
        }
    }


}
