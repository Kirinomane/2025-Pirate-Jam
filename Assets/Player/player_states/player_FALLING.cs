using UnityEngine;
using System;

public class player_FALLING : state
{
    override public string change_state(string state)
    {
        if (Player_controller.player_instance.isGrounded)
        {
            //play landing animation?
            return "IDLE";
        }
        
        if (Player_controller.player_instance.input.Player.Throw.WasPressedThisFrame())
        {
            //play throw animation
            return "THROW";
        }

        if (Player_controller.player_instance.input.Player.Attack.WasPressedThisFrame())
        {
            //play attack animation
            return "ATTACK_A";
        }

        return state;
    }
    override public void state_action()
    {
        return;
    }
}
