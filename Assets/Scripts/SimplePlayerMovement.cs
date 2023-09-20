using UnityEngine;
using Photon.Pun;
using TMPro;

public class SimplePlayerMovement : MonoBehaviourPunCallbacks {
    [SerializeField] private TextMeshPro tmp;
    
    [SerializeField] float speed = 30f;
    // [SerializeField] float rspeed = 5f;

    private void Start() {
        // photonView.Owner.NickName
        tmp.text = photonView.Owner.NickName;
    }

    private void Update() {
        if (!photonView.IsMine) return;
        

        if (Input.GetKey(KeyCode.A)){
            transform.Translate(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.D)){
            transform.Translate(speed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.W)){
            transform.Translate(0f, speed * Time.deltaTime,0f);
        }

        if (Input.GetKey(KeyCode.S)){
            transform.Translate(0f, -speed * Time.deltaTime,0f);
        }

        // if (Input.GetKey(KeyCode.Q)){
        //     transform.Rotate(0f, -rspeed * Time.deltaTime, 0f);
        // }
        //
        // if (Input.GetKey(KeyCode.E)){
        //     transform.Rotate(0f, rspeed * Time.deltaTime, 0f);
        // }
    }
}