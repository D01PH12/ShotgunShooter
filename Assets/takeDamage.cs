using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public int bulletDamage;
    public GameObject healthDisplay;
    public int maxHealth;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthDisplay.GetComponent<HealthDisplay>().setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);

            // TODO: Also indicate this better
            health = health - bulletDamage;
            healthDisplay.GetComponent<HealthDisplay>().health = health;
            if (health <= 0)
            {
                // TODO: Dead
            }
        }
    }
}
