using UnityEngine;

public class enemy_Vision : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.parent.GetComponent<StandartEnemyController>().enemySpotted = true;
        transform.parent.GetComponent<StandartEnemyController>().target = other.gameObject;
    }

}
