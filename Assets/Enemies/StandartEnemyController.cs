using UnityEngine;

public class StandartEnemyController : MonoBehaviour
{
    private string State = "IDLE";

    public int health = 3;
    public float updateTimer = 3f;

    public Transform Path_destination;


    public GameObject target;
    public bool enemySpotted = false;

    [HideInInspector] public Rigidbody rb = null;
    [HideInInspector] public Collider col;
    [SerializeField] Enemy_state_machine state_machine;

    public bool active = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
    }

    public void activate()
    {
        active = true;
    }

    public void deactivate()
    {
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            print("enemy active");
            State = state_machine.state_machine(State);
            state_machine.state_action(State);
            updateTimer -= Time.deltaTime;
            if (updateTimer <= 0)
            {
                updateTimer = 3f;

            }
        }
    }
}
