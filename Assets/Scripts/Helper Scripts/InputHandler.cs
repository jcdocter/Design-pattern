using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class InputHandler : MonoBehaviour
{
    public PlayerMovement moveInput;

    public Dictionary<ButtonControl, ICommand> commandDictionary;

   /* public InputHandler(PlayerMovement _playerMovement)
    {
        moveInput = _playerMovement;
    }*/

    public void Set(ButtonControl _buttonControl, ICommand _command)
    {
        commandDictionary.Add(_buttonControl, _command);
    }

    public void HandleInput()
    {
        Debug.Log("Oh no");
        foreach (var keyCommand in commandDictionary)
        {
            Debug.Log("Ooh no");
            if (Gamepad.current.Equals(keyCommand.Key))
            {
                Debug.Log("Oh no no no no");
                keyCommand.Value.Execute();
            }
        }
    }
}
