using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{

    public bool onGround;
    public KeyCode left;
    public KeyCode right;
    public KeyCode jumpButton;

    private Rigidbody _rb;
    private CharacterController _controller;
    private GameObject playerMesh;
    private Animator playerAnim;
    private Vector3 _charMove;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _doubleJumpMultiplier = .5f;
    [SerializeField]
    private float _gravity = 9.8f;
    [SerializeField]
    private float _vSpeed = 0;

    private float _MoveX;
    private bool _canDoubleJump = false;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _controller = GetComponent<CharacterController>();
        playerMesh = transform.GetChild(0).gameObject;
        playerAnim = playerMesh.GetComponent<Animator>();
    }

    void Update()
    {

        onGround = _controller.isGrounded;
        if (onGround)
        {
            playerAnim.SetBool("isJumping", false);

        }

        if (GameController.Instance.State != GameController.GameStates.PLAYING)
            return;

        GetInput();
        _MoveX = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(_MoveX, 0, 0);
        _charMove = direction;
        Vector3 lookDir = new Vector3(_charMove.x, 0.0f, 0.0f);

        _vSpeed -= _gravity * Time.deltaTime;
        _charMove.y = _vSpeed; // include vertical speed in vel
        _controller.Move(_charMove * _speed * Time.deltaTime);
        if (lookDir != Vector3.zero)    
        {
            playerMesh.transform.rotation = Quaternion.LookRotation(lookDir);
        }

        if (_charMove.x != 0)
        {
            playerAnim.SetBool("pMove", true);
        }
        else
        {
            playerAnim.SetBool("pMove", false);
        }

    }
    private void FixedUpdate()
    {
        

    }

    public void GetInput()
    {
        if (Input.GetKeyDown(jumpButton))
        {

            Jump();
        }

        

    }
    public void Jump()
    {
        if (onGround)
        {

            _canDoubleJump = true;

            if (Input.GetKeyDown(jumpButton))
            {
                playerAnim.SetBool("isJumping", true);

                _vSpeed = _jumpForce;

            }
        }
        else
        {

            if (Input.GetKeyDown(jumpButton) && _canDoubleJump)
            {

                _vSpeed = _jumpForce * _doubleJumpMultiplier;
                _canDoubleJump = false;

            }
        }
    }
    


    

}
