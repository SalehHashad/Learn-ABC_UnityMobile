using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string targetRoomName;
    [SerializeField] bool roomFound = false;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon servers
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        Debug.Log("Connected to Photon Master Server");
        
    }
    public override void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby, waiting for room...");
        if (IsPC())
        {
            Debug.Log("PC");
            StartCoroutine(WaitingForRoomCreating());
        }
        else
        {
            Debug.Log("Quest");
            PhotonNetwork.JoinOrCreateRoom(targetRoomName, new RoomOptions { MaxPlayers = 10 }, TypedLobby.Default);
        }
    }
    IEnumerator WaitingForRoomCreating()
    {
        Debug.Log("WaitingForRoomCreating");
        while (!roomFound)
        {
            Debug.Log("Waiting for Creating Room");
            yield return new WaitForSeconds(1f);
        }
        Debug.Log($"roomFound {roomFound}");
        PhotonNetwork.JoinRoom(targetRoomName);
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        Debug.Log($"Received room list update. Total rooms: {roomList.Count}");

        foreach (RoomInfo room in roomList)
        {
            Debug.Log($"Found Room: {room.Name} | Players: {room.PlayerCount}/{room.MaxPlayers}");
            if (room.Name == targetRoomName && room.PlayerCount > 0) // Ensure the room has players
            {
                Debug.Log($"Room '{targetRoomName}' found, attempting to join...");
                roomFound = true;
                break;
            }
        }
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        //SpawnPlayer();
    }

    void SpawnPlayer()
    {
        PhotonNetwork.Instantiate("NetworkedObject", Vector3.zero, Quaternion.identity);
    }
    bool IsPC()
    {
        return Application.platform == RuntimePlatform.WindowsPlayer ||
               Application.platform == RuntimePlatform.WindowsEditor ||
               Application.platform == RuntimePlatform.LinuxPlayer ||
               Application.platform == RuntimePlatform.OSXPlayer;
    }


}
