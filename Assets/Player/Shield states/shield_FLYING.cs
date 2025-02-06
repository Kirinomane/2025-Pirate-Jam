using System;
using UnityEngine;

public class shield_FLYING : state
{
    private shield_controller shield;

    private void Start()
    {
        shield = transform.parent.parent.GetComponent<shield_controller>();
    }

    override public String change_state(string state)
    {
        if (shield.controllableHit) 
        {
            GameManager.instance.SwitchToCharacter(shield.ToControl);
            return "IDLE";
        }

        if (shield.FloorHit)
        {
            shield.rb.linearVelocity = Vector3.zero;
            shield.rb.useGravity = false;
            shield.rb.angularVelocity = Vector3.zero;
            return "IDLE";
        }

        return state;
    }

    override public void state_action()
    {
        
    }
}
