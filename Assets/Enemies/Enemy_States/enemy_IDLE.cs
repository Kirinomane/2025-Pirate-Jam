using System;
using UnityEngine;

public class enemy_IDLE : state
{

    private float boredom = 3f;
    private bool bored = false;

    override public String change_state(string state)
    {

        if (GameManager.instance.spotted)
        {
            transform.parent.parent.GetComponent<StandartEnemyController>().enemySpotted = true;
            //transform.parent.parent.GetComponent<StandartEnemyController>().Path_destination = GameManager.instance.target.transform;
            //switch to walk animation
            return "WALK";
        }

        if (bored)
        {
            // transform.parent.parent.GetComponent<StandartEnemyController>().Path_destination = random walkable point near you
            return "WALK";
        }

        if (transform.parent.parent.GetComponent<StandartEnemyController>().enemySpotted)
        {
            //transform.parent.parent.GetComponent<StandartEnemyController>().Path_destination = GameManager.instance.target.transform;
            return "WALK";
        }

        return state;
    }

    override public void state_action()
    {

        boredom -= Time.deltaTime;
        if (boredom <= 0) 
        {
            //find random point via path system and walk there
        }
    }
}
