using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float doubleJumpMultiplier = 3.5f;

    public float groundDistance = 0.4f;

    public float speed = 6f;
    public float smoothTime = 0.1f;

    public bool isGrounded;

    public bool canJump;
    public bool doubleJump = false;

    public InputHandler inputHandler;
    public LayerMask groundMask;

    public Transform camera;
    public Transform groundCheck;

    public CharacterController characterController;
    public PlayerAnimation playerAnimation;

    public Vector3 velocity;

    private PlayerControls controls;

    private Vector3 movePlayer;
    private float turnSmoothVelocity;

    void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();

        //inputHandler = new InputHandler();

        controls = new PlayerControls();

        controls.Gameplay.Move.performed += ctx => movePlayer = ctx.ReadValue<Vector2>();
        controls.Gameplay.Move.canceled += ctx => movePlayer = Vector2.zero;
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Vector3 move = new Vector3(movePlayer.x, 0f,movePlayer.y).normalized;

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);

        if(move.magnitude >= 0.1f)
        {
            if (!PlayerAim.changeMove)
            {
                float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + camera.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, smoothTime);

                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDirectionForward = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

                if (Spells.canMove)
                {
                    characterController.Move(moveDirectionForward.normalized * speed * Time.deltaTime);
                }
            }
            playerAnimation.Walk(true);
        }
        else
        {
            playerAnimation.Walk(false);
        }
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
