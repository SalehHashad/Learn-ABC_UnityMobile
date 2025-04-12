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
        {
            Debug.Log("IsMasterClient");
            photonView.RPC("LoadNextLevel", RpcTarget.All);
        }
        else
            Debug.Log("Is Not MasterClient");

    }
    [PunRPC]
    private void LoadNextLevel()
    {
        if (FindObjectOfType<SplashScreenBehaviour>())
        {
            Debug.Log("FindObjectOfType<SplashScreenBehaviour>() Founded");
            PhotonNetwork.LoadLevel(FindObjectOfType<SplashScreenBehaviour>().goToScene);
        }else
            Debug.Log("FindObjectOfType<SplashScreenBehaviour>() not Found");

    }
}
