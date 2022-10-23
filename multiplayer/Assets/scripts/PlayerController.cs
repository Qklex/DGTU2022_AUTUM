  using System;
  using UnityEngine;
  using Photon.Pun;
  using UnityEngine.UI;
  using TMPro;
  using Unity.VisualScripting;

  public class PlayerController : MonoBehaviour
{
    public float m_Speed = 2f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public CharacterController controller;
    public PlayerController scriptPlayerController;
    public GameObject camera;
    public TMP_Text userName;
    
    private bool isGrounded;
    private Animator _animator;
    private Vector3 move;
    private Vector3 velocity;

    private PhotonView _view;
    
    private void Awake()
    {
        _view = GetComponent<PhotonView>();
        
        userName.text = _view.Owner.NickName;
        if (userName.text == "") userName.text = "Player "+PhotonNetwork.CurrentRoom.PlayerCount;
        
        if (_view.IsMine) return;
        
        scriptPlayerController.enabled = false;
        camera.SetActive(false);
    }

    void Start ()
    {
        _animator = GetComponent<Animator> ();
    }

    void FixedUpdate ()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
            velocity.y = -2f;

        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");

        move = transform.right * horizontal + transform.forward * vertical;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        
        _animator.SetBool ("IsWalking", isWalking);
    }

    void OnAnimatorMove ()
    {
        controller.Move(move * m_Speed * Time.deltaTime);
    }
}
