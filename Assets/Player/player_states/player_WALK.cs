using System;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.Rendering.DebugUI;

public class player_WALK : state
{

    override public string change_state(string state)
    {
        if (Player_controller.player_instance.input.Player.Throw.WasPressedThisFrame())
        {
            //throw
            float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
            Player_controller.player_instance.rb.linearVelocity = new Vector3(0, tempgrav, 0);
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
            //attack
            return "ATTACK_A";
        }

        if (Player_controller.player_instance.input.Player.Sprint.IsPressed() && Player_controller.player_instance.velocity != Vector3.zero)
        {
            return "RUN";
        }

        if (Player_controller.player_instance.velocity != Vector3.zero)
        {
            //walk
            return "WALK";
        }
        else
        {
            float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
            Player_controller.player_instance.rb.linearVelocity = new Vector3(0, tempgrav, 0);
            return "IDLE";
        }
    }

    override public void state_action()
    {
        if (Player_controller.player_instance.stamina < 100)
        {
            Player_controller.player_instance.stamina += 10 * Time.deltaTime;
        }

        float targetAngle = Mathf.Atan2(Player_controller.player_instance.rb.linearVelocity.x, Player_controller.player_instance.rb.linearVelocity.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref Player_controller.player_instance.turnSmoothVelocity, Player_controller.player_instance.rotation_speed);
        Player_controller.player_instance.player.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
        Player_controller.player_instance.rb.linearVelocity = Vector3.zero;
        Player_controller.player_instance.rb.linearVelocity = (Player_controller.player_instance.velocity * Player_controller.player_instance.walk_speed) +
            new Vector3(0,tempgrav,0);
    }
}
