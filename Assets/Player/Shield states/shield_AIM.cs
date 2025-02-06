using System;
using UnityEngine;

public class shield_AIM : state
{

    private shield_controller shield;
    private GameObject arrow;

    private void Start()
    {
        shield = transform.parent.parent.GetComponent<shield_controller>();
        arrow = shield.arrow;
    }

    override public String change_state(string state)
    {
        
        if (shield.input.Player.Throw.WasPressedThisFrame())
        {
            arrow.GetComponent<MeshRenderer>().enabled = false;
            shield.rb.linearVelocity = (shield.transform.Find("Pivot").forward + new Vector3(0f, 0.7f, 0f)) * shield.speed;
            shield.rb.useGravity = true;
            return "FLYING";
        }

        if (shield.velocity != Vector3.zero)
        {
            return state;
        }

        arrow.GetComponent<MeshRenderer>().enabled = false;
        return "IDLE";

    }

    override public void state_action()
    {
        float angle = Mathf.Atan2(shield.velocity.x, shield.velocity.z) * Mathf.Rad2Deg;
        arrow.transform.parent.rotation = Quaternion.Euler(0f, angle, 0f);

    }
}
