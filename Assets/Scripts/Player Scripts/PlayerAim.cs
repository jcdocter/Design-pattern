using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public static bool changeMove = false;

    public float speed = 6f;

    public CharacterController characterController;
    public Transform playerBody;

    public GameObject mainCamera;
    public GameObject aimCamera;

    public GameObject followTransform;

    private Vector3 movePlayer;
    private Vector3 rotatePlayer;

    private PlayerControls controls;

    private bool canAim = false;

    private float xRotation = 0f;


    void Awake()
    {
        controls = new PlayerControls();

        controls.Gameplay.Aim.performed += ctx => canAim = true;
        controls.Gameplay.Aim.canceled += ctx => canAim = false;

        controls.Gameplay.Rotate.performed += ctx => rotatePlayer = ctx.ReadValue<Vector2>();
        controls.Gameplay.Rotate.canceled += ctx => rotatePlayer = Vector2.zero;

        controls.Gameplay.Move.performed += ctx => movePlayer = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movePlayer = Vector2.zero;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (changeMove)
        {
            NewMovement();
        }

        if (canAim)
        {
            mainCamera.SetActive(false);
            aimCamera.SetActive(true);

            changeMove = true;
        }
        else
        {
            mainCamera.SetActive(true);
            aimCamera.SetActive(false);

            changeMove = false;
        }

    }

    void NewMovement()
    {
        xRotation += rotatePlayer.y;
        xRotation = Mathf.Clamp(xRotation, -20f, 20f);

        aimCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * rotatePlayer.x);

        Vector3 move = transform.right * movePlayer.x + transform.forward * movePlayer.y;

        characterController.Move(move * speed * Time.deltaTime);
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
    }
}
