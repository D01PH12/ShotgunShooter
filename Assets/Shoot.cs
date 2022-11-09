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
    public float switchTime;
    public GameObject nextGun;
    private float lastShootTime;
    private float reloadFinishTime;
    private float switchFinishTime;
    private int ammo;
    private bool reloading = false;
    private bool switching = false;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
    }


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
        } else if (switching) {
            // switching finished
            if (switchFinishTime <= Time.time)
            {
                switching = false;
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
            Destroy(bullet, 2f);
        }
        // switch gun
        if (Input.GetKeyDown(KeyCode.Q))
        {
            reloading = false;
            nextGun.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        switching = true;
        switchFinishTime = Time.time + switchTime;
        // TODO: Play switch animation
        ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
    }
}
