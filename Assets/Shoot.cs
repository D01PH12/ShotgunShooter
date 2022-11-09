using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float velocity;
    public float fireRate;
    public int maxAmmo;
    public GameObject cam;
    public GameObject spawnPoint;
    public GameObject ammoDisplay;
    public float reloadTime;
    private float lastShootTime;
    private float reloadFinishTime;
    private int ammo;
    private bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
    }

    public float delay; //This implies a delay of 2 seconds.

    // Update is called once per frame
    void Update()
    {
        // waiting for reload to finish
        if (reloading)
        {
            // reloading finished
            if (reloadFinishTime <= Time.time)
            {
                ammo = maxAmmo;
                ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
                reloading = false;
            }
        }
        // reload
        else if (ammo == 0 || Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
            reloadFinishTime = Time.time + reloadTime;
            // TODO: Play reload animation
        }
        // shoot
        else if(Input.GetKey(KeyCode.Mouse0) && Time.time > lastShootTime + fireRate) {
            lastShootTime = Time.time;
            GameObject bullet = Instantiate(projectile, spawnPoint.transform.position, cam.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * velocity);
            ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + --ammo;
            Destroy(bullet, delay);
        }
    }
}
