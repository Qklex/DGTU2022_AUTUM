using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawns;
    [SerializeField] GameObject[] characters;
    private void Awake()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter");
        Vector3 randomPosition = spawns[Random.Range(0, spawns.Length)].transform.localPosition;
        Debug.Log(selectedCharacter);
        Debug.Log(characters[selectedCharacter].name);
        PhotonNetwork.Instantiate(characters[selectedCharacter].name, randomPosition, Quaternion.identity);
    }
}
