using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    public GameObject player;
    public GameObject projectile;
    public float velocity;
    public float shootRange;
    public float delay;
    public float rof;
    float lastShot;
    public Collider blueBullet;
    public float startHealth;
    public float spreadAngle;
    float health;
    public int points;
    public Text txt;
    

    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        txt.text = "Score: " + "0";
    }

    // Update is called once per frame
    void Update() 
    {
        
        float dist = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if(dist < shootRange && lastShot > 60000/rof) {
            this.gameObject.transform.LookAt(player.transform.position + new Vector3(0f, 0.5f, 0f));
            Vector3 randomVector = new Vector3(UnityEngine.Random.Range(-spreadAngle, spreadAngle), UnityEngine.Random.Range(-spreadAngle, spreadAngle), UnityEngine.Random.Range(-spreadAngle, spreadAngle));
            GameObject bullet = Instantiate(projectile, this.gameObject.transform.position, this.gameObject.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce((this.gameObject.transform.forward + randomVector) * velocity);
            Destroy(bullet, delay);
            lastShot = 0;
        }

        lastShot += Time.deltaTime * 1000;
    }

    public void reduceHealth(float damage)
    {
        health = health - damage;
        if (health <= 0.01)
        {
            this.gameObject.transform.Translate(0, -200, 0);
            txt.text = "Score: " + ((int.Parse(txt.text.Split()[1]) + points).ToString());
        }
    }
}
