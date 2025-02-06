using System;
using UnityEngine;

public class state : MonoBehaviour
{
    virtual public String change_state(string state)
    {
        return state;
    }

    virtual public void state_action()
    {

    }
}
