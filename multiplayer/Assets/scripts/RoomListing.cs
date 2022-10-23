using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour
{
    [SerializeField] private Text _text;

    public RoomInfo RoomInfo { get; private set; }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        Debug.Log(roomInfo);
        RoomInfo = roomInfo;
        _text.text = roomInfo.Name + " " + roomInfo.PlayerCount + "/" + roomInfo.MaxPlayers;
    }
}
