using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance { get; private set; }
    [SerializeField] CharacterController controller;
    [SerializeField] Camera cam;
    Vector3 hor, ver, camF, camR;
    [SerializeField] float moveSpeed, jumpForce, gravity;
    public bool isGrounded, isFalling, isMoving, canControll;
    float x, z;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        controller = GetComponent<CharacterController>();
        cam = transform.GetChild(1).GetComponent<Camera>();
        canControll = true;


    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        isFalling = !isGrounded && ver.sqrMagnitude > 0.1f;
        isMoving = isGrounded && hor.sqrMagnitude > 0.1f;
        if (canControll)
        {
            HandleInput();
            HandleMove();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                HandleJump();
            }
        }
        HandelGravity();
    }

    void HandleInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        camF = cam.transform.forward;
        camR = cam.transform.right;

        camF.y = 0;
        camR.y = 0;

        hor = (x * camR + z * camF).normalized;
    }
    void HandleMove()
    {
        if (hor.sqrMagnitude > 0.1f)
        {
            Quaternion Rota = Quaternion.LookRotation(hor);
            transform.rotation = Quaternion.Slerp(transform.rotation, Rota, moveSpeed * Time.deltaTime);
        }
        controller.Move(hor * moveSpeed * Time.deltaTime);
    }
    void HandelGravity()
    {
        if (isGrounded)
        {
            if (ver.y < 0)
            {
                ver.y = -2f;
            }
        }
        else
        {
            ver.y -= gravity * Time.deltaTime;
        }
        controller.Move(ver * Time.deltaTime);
    }
    void HandleJump()
    {
        if (canControll)
        {
            ver.y = jumpForce;
        }
    }
}
