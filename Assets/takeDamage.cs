using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class takeDamage : MonoBehaviour
{
    public int bulletDamage;
    public GameObject healthDisplay;
    public Image fadeMask;
    public int maxHealth;
    private int health;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthDisplay.GetComponent<HealthDisplay>().setMaxHealth(maxHealth);
    }

    public IEnumerator Fade(bool fadeOut, bool changeScene, int fadeSpeed = 400)
    {
        Color32 objectColor = fadeMask.color;
        float fadeAmount;

        if (fadeOut)
        {
            while (fadeMask.color.a < 1)
            {
                fadeAmount = (objectColor.a + (fadeSpeed * Time.deltaTime));
                if (fadeAmount > 255)
                    fadeAmount = 255;

                objectColor = new Color32(objectColor.r, objectColor.g, objectColor.b, (byte)fadeAmount);
                fadeMask.color = objectColor;
                yield return null;
            }
        } else
        {
            while (fadeMask.color.a > 0)
            {
                fadeAmount = (objectColor.a - (fadeSpeed * Time.deltaTime));
                if (fadeAmount < 0)
                    fadeAmount = 0;

                objectColor = new Color32(objectColor.r, objectColor.g, objectColor.b, (byte)fadeAmount);
                fadeMask.color = objectColor;
                yield return null;
            }
        }
        if (changeScene)
        {
            SceneManager.LoadScene("DeathScene");
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            // If the player is already dead, don't calculate damage
            if (health > 0)
            {
                health = health - bulletDamage;
                healthDisplay.GetComponent<HealthDisplay>().health = health;

                if (health <= 0)
                {
                    // Fade to black
                    GetComponent<Animator>().enabled = true;
                    StopAllCoroutines();
                    fadeMask.color = new Color32(0, 0, 0, 0);
                    StartCoroutine(Fade(true, true, 400));
                }
                else
                {
                    // Flash screen
                    StopAllCoroutines();
                    fadeMask.color = new Color32(255, 0, 0, 180);
                    StartCoroutine(Fade(false, false, 550));
                }
            }
        }
    }
}
