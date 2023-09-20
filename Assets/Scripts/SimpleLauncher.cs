using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.UI;

public class SimpleLauncher : MonoBehaviourPunCallbacks {
    public PhotonView playerPrefab;

    public Button startBtn;
    public GameObject nicknameInput;
    public TMP_InputField playerNickname;

    public override void OnEnable() {
        base.OnEnable();
        startBtn.onClick.AddListener(StartGame);
    }

    public override void OnDisable() {
        base.OnDisable();
        startBtn.onClick.RemoveListener(StartGame);
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    public override void OnConnectedToMaster() {
        Debug.Log("Connected to Master");
        PhotonNetwork.JoinRandomOrCreateRoom();
    }

    public override void OnJoinedRoom() {
        Debug.Log("Joined a room.");
        PhotonNetwork.Instantiate(playerPrefab.name, Vector3.zero, Quaternion.identity);
    }

    public void StartGame() {
        PhotonNetwork.NickName = playerNickname.text;
        PhotonNetwork.ConnectUsingSettings();
        nicknameInput.SetActive(false);
    }
}