using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ComboState
{
    NONE,
    PUNCH_1,
    PUNCH_2,
    PUNCH_3
}

public class PlayerAttack : MonoBehaviour
{
    public static int useSpell;

    public float energyCost = 10;

    public float TeleportSpeed;

    public Transform teleportTarget;
    public GameObject player;

    private PlayerAnimation playerAnimation;
    private PlayerControls controls;

    private ComboState comboState;

    private Spells spells;
    private Vector3 destination;

    private bool TimerToReset;
    private bool canBlink = false;

    private float comboTimer = 0.4f;
    private float currentComboTimer;

    private ParticleSystem trail;

    void Awake()
    {
        controls = new PlayerControls();

        playerAnimation = GetComponent<PlayerAnimation>();

        trail = FindObjectOfType<ParticleSystem>();

        spells = FindObjectOfType<Spells>();

        controls.Gameplay.Attack.performed += ctx => Attack();
        controls.Gameplay.Shoot.performed += _ => Special();
    }

    void Start()
    {
        currentComboTimer = comboTimer;
        comboState = ComboState.NONE;
    }

    void Update()
    {
        ResetComboState();

        if (canBlink)
        {
            var dist = Vector3.Distance(transform.position, destination);
            Debug.Log(dist);

            if(dist > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, destination, Time.deltaTime * TeleportSpeed);
            }
            else
            {
                canBlink = false;
            }
        }
    }

    void Attack()
    {
        // exit if combo is finished
        if(comboState == ComboState.PUNCH_3)
        {
            return;
        }

        comboState++;
        TimerToReset = true;
        currentComboTimer = comboTimer;

        if(comboState == ComboState.PUNCH_1)
        {
            playerAnimation.Attack1();
        }

        if (comboState == ComboState.PUNCH_2)
        {
            playerAnimation.Attack2();
        }

        if (comboState == ComboState.PUNCH_3)
        {
            playerAnimation.Attack3();
        }
    }

    void ResetComboState()
    {
        if (TimerToReset)
        {
            currentComboTimer -= Time.deltaTime;

            if(currentComboTimer <= 0f)
            {
                comboState = ComboState.NONE;

                TimerToReset = false;
                currentComboTimer = comboTimer;
            }
        }
    }

    public void Special()
    {
        if (useSpell == 0 && spells.currentEnergy >= energyCost)
        {
            spells.payEnergy(energyCost);
            Debug.Log("Fire");
            playerAnimation.SpecialAttack();

            Shoot.fire = true;
        }
        else if(useSpell == 1 && spells.currentEnergy >= 25f)
        {
            trail.Play();

            destination = teleportTarget.position;

            canBlink = true;
            spells.payEnergy(25);
            Debug.Log("Teleport");
        }
    }

    void Teleport()
    {
    }

    void OnEnable()
    {
        controls.Gameplay.Enable();
        controls.Gameplay.Shoot.Enable();
    }

    void OnDisable()
    {
        controls.Gameplay.Disable();
        controls.Gameplay.Shoot.Disable();
    }
}
