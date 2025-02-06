using UnityEngine;

public class shield_state_machine : MonoBehaviour
{
    GameObject interaction_state;

    public string state_machine(string State)
    {
        interaction_state = GameObject.Find("shield_" + State);
        return interaction_state.GetComponent<state_handler>().change_state(State);
    }

    public void state_action(string State)
    {
        interaction_state = GameObject.Find("shield_" + State);
        interaction_state.GetComponent<state_handler>().state_action();
    }
}
