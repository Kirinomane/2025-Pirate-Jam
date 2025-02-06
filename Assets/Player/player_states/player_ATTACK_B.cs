using System;
using UnityEngine;

public class player_ATTACK_B : state
{
    override public string change_state(string state)
    {
        if (true) //on animation finished
        {
            return "IDLE";
        }
        //return state;
    }
    override public void state_action()
    {

    }
}
