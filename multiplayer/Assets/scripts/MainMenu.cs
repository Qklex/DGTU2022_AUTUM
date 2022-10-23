using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviourPunCallbacks
{
    public TMP_InputField  NameRoom;
    public TMP_InputField  UserNameInput;
    public GameObject ErrorPanel;
    [SerializeField] GameObject[] characters;
    
    private string room;
    private TypedLobby customLobby = new TypedLobby("customLobby", LobbyType.Default);
    private int _current_character = 0;
    
    void Start()
    {
        PlayerPrefs.SetInt("SelectedCharacter", _current_character);
        PhotonNetwork.JoinLobby(customLobby);
    }
    
    public void CreateRoom()
    {
        room = NameRoom.text;
        if (room.Length > 3)
        {
            RoomOptions roomOptions = new RoomOptions();
            roomOptions.MaxPlayers = 10;
            PhotonNetwork.CreateRoom(room, roomOptions);
        }
        else
        {
            ErrorPanel.SetActive(true);
        }
    }

    public void NextChar()
    {
        if (_current_character == (characters.Length - 1)) return;
        
        characters[_current_character].SetActive(false);
        _current_character++;
        characters[_current_character].SetActive(true);
        
        PlayerPrefs.SetInt("SelectedCharacter", _current_character);
    }
    public void PrevChar()
    {
        if (_current_character == 0) return;

        characters[_current_character].SetActive(false);
        _current_character--;
        characters[_current_character].SetActive(true);
        
        PlayerPrefs.SetInt("SelectedCharacter", _current_character);
    }

    public void JoinRoom()
    {
        room = NameRoom.text;
        if (room.Length > 3)
        {
            PhotonNetwork.JoinRoom(room);
        }
        else
        {
            ErrorPanel.SetActive(true);
        }
    }

    public void SaveName()
    {
        string name = UserNameInput.text;
        PlayerPrefs.SetString("Username", name);
        PhotonNetwork.NickName = name;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
