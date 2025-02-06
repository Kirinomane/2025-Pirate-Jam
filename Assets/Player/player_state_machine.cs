using UnityEngine;

public class player_state_machine : MonoBehaviour
{
    GameObject interaction_state;

    public string state_machine(string State)
    {
        interaction_state = transform.Find("player_" + State).gameObject;
        return interaction_state.GetComponent<state_handler>().change_state(State);
    }

    public void state_action(string State)
    {
        interaction_state = transform.Find("player_" + State).gameObject;
        interaction_state.GetComponent<state_handler>().state_action();
    }

}
