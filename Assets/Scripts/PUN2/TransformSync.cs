using Photon.Pun;
using UnityEngine;

public class TransformSync : MonoBehaviourPun, IPunObservable
{
    void Update()
    {
        if (photonView.IsMine) // If this is the local player, allow movement
        {
            transform.position += new Vector3(0, 0, Time.deltaTime); // Example movement
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting) // Sending transform data
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else // Receiving transform data
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();
        }
    }
}
