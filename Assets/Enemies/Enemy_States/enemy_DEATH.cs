using System;
using UnityEngine;

public class enemy_DEATH : state
{
    override public String change_state(string state)
    {
        return state;
    }

    override public void state_action()
    {
        //ragdoll
        //remove the corpse after a while
    }
}
