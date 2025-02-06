using System;
using UnityEngine;

public class shield_IDLE : state
{
    private shield_controller shield;
    private GameObject arrow;

    private void Start()
    {
        shield = transform.parent.parent.GetComponent<shield_controller>();
        arrow = shield.arrow;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    override public String change_state(string state)
    {

        if (shield.velocity != Vector3.zero)
        {
            arrow.GetComponent<MeshRenderer>().enabled = true;
            return "AIM";
        }
        else
        {
            return state;
        }

    }

    override public void state_action()
    {

    }
}
