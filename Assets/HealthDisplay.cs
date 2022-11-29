using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthDisplay : MonoBehaviour
{
    private int maxHealth;
    public int health;
    private int healthBarValue;
    private Image healthBar;
    public TextMeshProUGUI healthText;

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
            if (healthBarValue / (float)maxHealth > 0.75)
            {
                Color green = new Color32(124, 255, 161, 255);
                healthBar.color = green;
                healthText.color = green;
            }
            else if (healthBarValue / (float)maxHealth > 0.50)
            {
                Color yellow = new Color32(255, 247, 81, 255);
                healthBar.color = yellow;
                healthText.color = yellow;
            }
            else if (healthBarValue / (float)maxHealth > 0.25)
            {
                Color orange = new Color32(255, 103, 52, 255);
                healthBar.color = orange;
                healthText.color = orange;
            }
            else
            {
                Color red = new Color32(255, 45, 28, 255);
                healthBar.color = red;
                healthText.color = red;
            }
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
