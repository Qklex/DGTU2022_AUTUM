using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class Connection : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
