using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    private int maxHealth;
    public int health;
    private int healthBarValue;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
        healthBarValue = maxHealth;
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
    public void setMaxHealth(int hp)
    {
        maxHealth = hp;
        health = hp;
        healthBarValue = hp;
    }
}
