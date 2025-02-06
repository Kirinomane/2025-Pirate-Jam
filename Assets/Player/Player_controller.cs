using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player_controller : MonoBehaviour
{
    private string State = "IDLE";

    public GameObject player;

    public Player_Input input = null;
    public Vector3 velocity = Vector3.zero;
    public float walk_speed = 10f;
    public float run_speed = 15f;
    public float jump_force = 10f;
    public float rotation_speed = 0.1f;
    public float throwspeed = 15f;
    public bool isGrounded;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public Transform snap_point = null;
    public float turnSmoothVelocity;

    public float health = 100f;
    public float stamina = 100f;

    private Transform groundcheck;
    private bool active = false;

    [HideInInspector] public Rigidbody rb = null;
    [HideInInspector] public static Player_controller player_instance;

    [SerializeField] player_state_machine state_machine;

    private void Awake()
    {
        if (player_instance != null && player_instance != this)
        {
            Destroy(this);
            return;
        }

        player_instance = this;
        input = new Player_Input();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    public void activate(GameObject hit)
    {
        player = hit;
        rb = hit.GetComponent<Rigidbody>();
        state_machine = hit.GetComponentInChildren<player_state_machine>();
        snap_point = hit.transform.Find("snap_point").transform;
        groundcheck = hit.transform.Find("Groundcheck").transform;
        active = true;
    }

    public void deactivate()
    {
        active = false;
        player = null;
        rb = null;
        state_machine = null;
        snap_point = null;
        groundcheck = null;
    }

    private void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            //change state to puppet defeated or something
        }
    }

    public void useStamina(float amount)
    {
        stamina -= amount;
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

    private bool GroundCheck()
    {
        return Physics.CheckSphere(groundcheck.position, groundDistance, groundMask);
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            isGrounded = GroundCheck();


            print("player active");
            print(State);

            State = state_machine.state_machine(State);

            if (!active)
            {
                return;
            }

            state_machine.state_action(State);

            GameManager.instance.updateHealthbar(health);
            GameManager.instance.updateStaminabar(stamina);
        }
    }
}
