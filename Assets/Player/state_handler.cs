using UnityEngine;

public class state_handler : MonoBehaviour
{
    public state script;

    public string change_state(string State)
    {
        return script.change_state(State);
    }

    public void state_action()
    {
        script.state_action();
    }


}
