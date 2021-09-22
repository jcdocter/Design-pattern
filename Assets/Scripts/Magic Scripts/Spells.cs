using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spells : MonoBehaviour
{
    public static bool canMove = true;

    public float ChargeSpeed = 2f;
    public float MaxEnergy = 100f;
    public float currentEnergy;

    public MagicBar magicBar;

    public GameObject TeleportTarget;
    public RawImage spellImage;
    public Texture[] spellTexture;

    private PlayerControls controls;

    private PlayerAnimation playerAnimation;

    private bool canChargeEnery = false;

    private int currentSpell = 0;

    void Awake()
    {
        playerAnimation = FindObjectOfType<PlayerAnimation>();

        controls = new PlayerControls();

        controls.Gameplay.Switchforward.performed += ctx => NextSpell();
        controls.Gameplay.Switchback.performed += ctx => PerviousSpell();

        controls.Gameplay.Charge.performed += ctx => canChargeEnery = true;
        controls.Gameplay.Charge.canceled += ctx => canChargeEnery = false;
    }

    void Start()
    {
        //start with index 0 texture
        spellImage.texture = spellTexture[currentSpell];
    }

    void Update()
    {
        if (canChargeEnery) {
            playerAnimation.Charge(true);
            canMove = false;
            ChargeMagic();
        }
        else
        {
            canMove = true;
            playerAnimation.Charge(false);
        }

        switch (currentSpell)
        {
            case 0:
                TeleportTarget.SetActive(false);
            break;

            case 1:
                TeleportTarget.SetActive(true);
            break;
        }

        PlayerAttack.useSpell = currentSpell;
    }

    public void NextSpell()
    {
        // change spell
        currentSpell++;

        // reset spell to 0
        if (currentSpell > spellTexture.Length - 1)
        {
            currentSpell = 0;
        }

        spellImage.texture = spellTexture[currentSpell];
    }

    public void PerviousSpell()
    {
        // change spell
        currentSpell--;

        // reset to last spell
        if(currentSpell < 0)
        {
            currentSpell = spellTexture.Length - 1;
        }
  

        spellImage.texture = spellTexture[currentSpell];
    }

    void ChargeMagic()
    {
        currentEnergy += Time.deltaTime * ChargeSpeed;

        if(currentEnergy > 100)
        {
            playerAnimation.Charge(false);
            currentEnergy = MaxEnergy;
        }

        magicBar.SetEnergy(currentEnergy);
    }

    public void payEnergy(float payAmount)
    {
        currentEnergy -= payAmount;

        if(currentEnergy < 0)
        {
            currentEnergy = 0;
        }

        magicBar.SetEnergy(currentEnergy);
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
