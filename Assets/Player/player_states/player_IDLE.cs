using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class player_IDLE : state
{
    override public string change_state(string state)
    {


        if (Player_controller.player_instance.input.Player.Throw.WasPressedThisFrame())
        {
            //start throw animation
            GameManager.instance.SwitchToShield();
            GameManager.instance.Shield.GetComponent<Rigidbody>().linearVelocity = GameManager.instance.Shield.transform.forward + new Vector3(0f, 0.7f, 0f)
            * Player_controller.player_instance.throwspeed;
            return "THROW";
        }

        if (Player_controller.player_instance.input.Player.Jump.WasPressedThisFrame() && Player_controller.player_instance.stamina > 15)
        {
            //start Jump animation
            Player_controller.player_instance.useStamina(15);
            Player_controller.player_instance.rb.linearVelocity += new Vector3(0, Player_controller.player_instance.jump_force, 0);
            return "JUMP";
        }

        if (Player_controller.player_instance.input.Player.Attack.WasPressedThisFrame())
        {
            //start attack animation
            return "ATTACK_A";
        }

        if (Player_controller.player_instance.input.Player.Sprint.IsPressed() && Player_controller.player_instance.velocity != Vector3.zero && Player_controller.player_instance.stamina > 5)
        {
            return "RUN";
        }

        if (Player_controller.player_instance.velocity != Vector3.zero)
        {
            // start walk animation
            return "WALK";
        }

        return state;
    }
    override public void state_action()
    {
        if (Player_controller.player_instance.stamina < 100)
        {
            Player_controller.player_instance.stamina += 10 * Time.deltaTime;
        }
    }
}
