using System;
using UnityEngine;

public class enemy_WALK : state
{
    override public String change_state(string state)
    {

        //if (Vector3.Distance(transform.parent.parent.position, GameManager.instance.target.transform.position) <= 5f)
        //{
            //play attack animation
        //    return "ATTACK";
        //}


        return state;
    }

    override public void state_action()
    {

    }
}
