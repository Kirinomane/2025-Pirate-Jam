using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows;

public class GameManager : MonoBehaviour
{

    public Slider Healthbar;
    public Slider MaxHealthbar;
    public Slider Staminabar;
    public Slider MaxStaminabar;

    public bool spotted = false;
    public GameObject player = null;
    public GameObject Shield = null;
    public GameObject target = null;

    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            return;
        }

        instance = this;
        rb = GetComponent<Rigidbody>();
    }

    public void targetSpotted(GameObject spotted)
    {
        //for each enemy in group enemies: target = spotted
        target = spotted;
    }

    public void SwitchToShield()
    {
        Player_controller.player_instance.deactivate();
        Shield.transform.parent = null;
        Shield.GetComponent<shield_controller>().activate();
        CameraFollow.instance.target = Shield.transform;
    }

    public void SwitchToCharacter(GameObject character)
    {
        player = character;
        Player_controller.player_instance.activate(character);
        Shield.transform.parent = character.transform.Find("snap_point").transform;
        character.GetComponent<StandartEnemyController>().deactivate();
        Shield.GetComponent<shield_controller>().deactivate();
        CameraFollow.instance.target = character.transform;
    }

    public void updateHealthbar(float health)
    {
        
        Healthbar.value = health;
        if (health > MaxHealthbar.value)
        {
            MaxHealthbar.value = health;
        }

    }

    public void updateStaminabar(float stamina)
    {
        
        Staminabar.value = stamina;
        if (stamina > MaxStaminabar.value)
        {
            MaxStaminabar.value = stamina;
        }

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MaxHealthbar.value > Healthbar.value)
        {
            if (MaxHealthbar.value - Healthbar.value <= 1f)
            {
                MaxHealthbar.value = Healthbar.value;
            }
            else
            {
                MaxHealthbar.value -= (MaxHealthbar.value - Healthbar.value) * (Time.deltaTime * 2);
            }
        }
        if (MaxStaminabar.value > Staminabar.value)
        {
            if (MaxStaminabar.value - Staminabar.value <= 1f)
            {
                MaxStaminabar.value = Staminabar.value;
            }
            else
            {
                MaxStaminabar.value -= (MaxStaminabar.value - Staminabar.value) * (Time.deltaTime * 2);
            }
        }
    }
}
