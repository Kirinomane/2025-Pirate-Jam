using UnityEngine;

public class Enemy_state_machine : MonoBehaviour
{
    GameObject interaction_state;

    public string state_machine(string State)
    {
        interaction_state = transform.Find("enemy_" + State).gameObject;
        return interaction_state.GetComponent<state_handler>().change_state(State);
    }

    public void state_action(string State)
    {
        interaction_state = transform.Find("enemy_" + State).gameObject;
        interaction_state.GetComponent<state_handler>().state_action();
    }

}
