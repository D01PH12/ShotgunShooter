using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public int maxHealth;
    private int health;
    private int healthBarValue;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthBarValue = maxHealth;
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        // Drain healthbar not instantly
        if (healthBarValue > health)
        {
            healthBarValue -= 2;
        }
        healthBar.fillAmount = healthBarValue / (float) maxHealth;
    }

    public void takeDamage(int damage)
    {
        // TODO: Also indicate this better
        health = health - damage;
        Debug.Log(health);
        if (health <= 0)
        {
            // TODO: Dead
        }
    }
}
