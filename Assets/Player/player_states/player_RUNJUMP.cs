using UnityEngine;

public class player_RUNJUMP : state
{
    override public string change_state(string state)
    {

        if (Player_controller.player_instance.input.Player.Throw.WasPressedThisFrame())
        {
            return "THROW";
        }

        if (Player_controller.player_instance.input.Player.Attack.WasPressedThisFrame())
        {
            //attack
            return "ATTACK_A";
        }

        if (Player_controller.player_instance.isGrounded)
        {
            float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
            Player_controller.player_instance.rb.linearVelocity = new Vector3(0, tempgrav, 0);
            return "IDLE";
        }

        return state;
    }

    override public void state_action()
    {
        float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
        Player_controller.player_instance.rb.linearVelocity = Vector3.zero;
        Player_controller.player_instance.rb.linearVelocity = (Player_controller.player_instance.velocity * Player_controller.player_instance.run_speed) +
            new Vector3(0, tempgrav, 0);
    }
}