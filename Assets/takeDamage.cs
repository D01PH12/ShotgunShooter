using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeDamage : MonoBehaviour
{
    public int maxHealth;
    public int bulletDamage;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
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
            health = health - bulletDamage;
            Debug.Log("Health: " + health);
            if (health <= 0)
            {
                // Dead
            }
        }
    }
}
