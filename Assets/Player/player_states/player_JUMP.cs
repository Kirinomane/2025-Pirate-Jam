using UnityEngine;

public class player_JUMP : state
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

        if (Player_controller.player_instance.input.Player.Attack.WasPressedThisFrame())
        {
            //attack
            return "ATTACK_A";
        }

        if (Player_controller.player_instance.isGrounded && Player_controller.player_instance.rb.linearVelocity.y < 0)
        {
            float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
            Player_controller.player_instance.rb.linearVelocity = new Vector3(0, tempgrav, 0);
            return "IDLE";
        }

        return state;
    }
    override public void state_action()
    {
        float targetAngle = Mathf.Atan2(Player_controller.player_instance.rb.linearVelocity.x, Player_controller.player_instance.rb.linearVelocity.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref Player_controller.player_instance.turnSmoothVelocity, Player_controller.player_instance.rotation_speed);
        Player_controller.player_instance.player.transform.rotation = Quaternion.Euler(0f, angle, 0f);

        float tempgrav = Player_controller.player_instance.rb.linearVelocity.y;
        Player_controller.player_instance.rb.linearVelocity = Vector3.zero;
        Player_controller.player_instance.rb.linearVelocity = (Player_controller.player_instance.velocity * Player_controller.player_instance.walk_speed) +
            new Vector3(0, tempgrav, 0);
    }
}
