using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private PlayerControls controls;

    void Awake()
    {
        instance = this;

        controls = new PlayerControls();

        controls.Gameplay.Menu.performed += ctx => QuitGame();
    }

    private void Start()
    {
        InputHandler inputHandler = new InputHandler();
        inputHandler.Set(Gamepad.current.buttonSouth, new JumpCommand(inputHandler.moveInput));
    }

    public void QuitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
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
