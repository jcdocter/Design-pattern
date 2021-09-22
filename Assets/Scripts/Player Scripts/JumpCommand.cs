using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private PlayerMovement player;

    public JumpCommand(PlayerMovement _playerMovement)
    {
        player = _playerMovement;
    }

    public void Execute()
    {
        Jump();
    }

    public virtual void Jump()
    {
        if (player.isGrounded && player.velocity.y < 0f)
        {
            Debug.Log("Jump");
            player.velocity.y = -2f;

            player.velocity.y = Mathf.Sqrt(player.jumpHeight * -2f * player.gravity);
            player.doubleJump = true;

            player.playerAnimation.Jump();
        }
        else if (player.doubleJump)
        {
            Debug.Log("Double Jump");

            player.velocity.y = Mathf.Sqrt(player.jumpHeight * -2f * player.gravity * player.doubleJumpMultiplier);

            player.playerAnimation.DoubleJump();
            player.doubleJump = false;
        }

        player.canJump = false;
    }
}
