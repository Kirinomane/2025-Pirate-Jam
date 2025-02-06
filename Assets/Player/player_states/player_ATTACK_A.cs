using System;
using UnityEngine;

public class player_ATTACK_A : state
{
    override public string change_state(string state)
    {
        if (Player_controller.player_instance.input.Player.Throw.WasPressedThisFrame())
        {
            GameManager.instance.SwitchToShield();
            GameManager.instance.Shield.GetComponent<Rigidbody>().linearVelocity = GameManager.instance.Shield.transform.forward + new Vector3(0f, 0.7f, 0f)
            * Player_controller.player_instance.throwspeed;
            return "THROW";
        }

        float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
        Player_controller.player_instance.rb.linearVelocity = new Vector3(0, tempgrav, 0);
        return "IDLE";

        //if (animation finished)
        //{
        //return "IDLE";
        //}

        //return state;
    }

    override public void state_action()
    {
        if (Player_controller.player_instance.stamina < 100)
        {
            Player_controller.player_instance.stamina += 10 * Time.deltaTime;
        }

        float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
        Player_controller.player_instance.rb.linearVelocity = Vector3.zero;
        Player_controller.player_instance.rb.linearVelocity = (Player_controller.player_instance.velocity * (Player_controller.player_instance.walk_speed * 0.5f)) +
            new Vector3(0, tempgrav, 0);
    }
}
