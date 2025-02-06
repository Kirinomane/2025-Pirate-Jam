using System;
using UnityEngine;

public class player_THROW : state
{
    override public string change_state(string state)
    {
        //on animation finished: Go to ko state


        return "IDLE";
    }
    override public void state_action()
    {

    }
}
