using UnityEngine;
using UnityEngine.InputSystem;

public class shield_controller : MonoBehaviour
{
    //possible states:
    // Idle, flying, controlling

    private string State = "IDLE";

    public bool controllableHit = false;
    public bool FloorHit = false;
    public bool active = true;
    public shield_state_machine state_machine;
    public GameObject arrow;
    public GameObject ToControl;

    public Player_Input input = null;
    public Vector3 velocity = Vector3.zero;
    public float drag;
    public float speed = 10f;

    private Collider col;
    private Animator animator;

    [HideInInspector] public Rigidbody rb;

    private void Awake()
    {
        input = new Player_Input();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        rb.linearDamping = drag;
        rb.angularDamping = 0f;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }

    public void deactivate()
    {
        rb.isKinematic = true;
        col.enabled = false;

        transform.position = transform.parent.position;
        transform.rotation = transform.parent.rotation;
        transform.localScale = Vector3.one;

        active = false;
    }

    public void activate()
    {
        rb.isKinematic = false; 
        col.enabled = true;

        transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        active = true;
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;

    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext vec)
    {
        velocity = vec.ReadValue<Vector3>();
    }

    private void OnMovementCancelled(InputAction.CallbackContext vec)
    {
        velocity = Vector3.zero;
    }

    void Update()
    {
        if (active)
        {
            print(State);
            State = state_machine.state_machine(State);
            animator.Play(State);
            state_machine.state_action(State);
            FloorHit = false;
            controllableHit = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" && active)
        {
            StandartEnemyController Econtroll = collision.gameObject.GetComponent<StandartEnemyController>();
            if (Econtroll.health == 1)
            {
                controllableHit = true;
                ToControl = collision.gameObject;
            }
        }
        if (collision.gameObject.tag == "Floor" && active)
        {
            FloorHit = true;
        }
    }
}
