using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviourPun
{
    private void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(OnClicked);
    }

    private void OnClicked()
    {
        if (PhotonNetwork.IsMasterClient)
            photonView.RPC("LoadNextLevel", RpcTarget.All);
    }
    [PunRPC]
    private void LoadNextLevel()
    {
        PhotonNetwork.LoadLevel(FindObjectOfType<SplashScreenBehaviour>().goToScene);
    }
}
