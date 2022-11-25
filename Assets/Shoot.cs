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
    public Image reloadCD;
    public Image switchCD;
    private float lastShootTime;
    private float reloadFinishTime;
    private float switchFinishTime;
    private int ammo;
    private bool reloading = false;
    private bool switching = false;
    private AudioSource shootSound;

    // Start is called before the first frame update
    void Start()
    {
        ammo = maxAmmo;
        ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
        shootSound = gameObject.GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {

        // waiting for reload to finish
        if (reloading)
        {
            reloadFinishTime += Time.deltaTime;
            reloadCD.fillAmount = reloadFinishTime / reloadTime;

            // reloading finished
            if (reloadFinishTime >= reloadTime)
            {
                reloadCD.fillAmount = 0;
                ammo = maxAmmo;
                ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
                reloading = false;
            }
        } else if (switching) {
            switchFinishTime += Time.deltaTime;
            switchCD.fillAmount = switchFinishTime / switchTime;
            // switching finished
            if (switchFinishTime >= switchTime)
            {
                switchCD.fillAmount = 0;
                switching = false;
            }
            // Auto-reload starts as soon as switch occurs
            if (ammo == 0)
            {
                reloading = true;
                reloadFinishTime = 0;
                // TODO: Play reload animation
                switchFinishTime = switchTime;
            }
        }
        // reload
        else if (ammo == 0 || Input.GetKeyDown(KeyCode.R))
        {
            reloading = true;
            reloadFinishTime = 0;
            // TODO: Play reload animation
        }
        // shoot
        else if(Input.GetKey(KeyCode.Mouse0) && Time.time > lastShootTime + fireRate) {
            lastShootTime = Time.time;
            GameObject bullet = Instantiate(projectile, spawnPoint.transform.position, cam.transform.rotation);
            shootSound.Play(0);
            bullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * velocity);
            ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + --ammo;
            Destroy(bullet, 2f);
        }
        // switch gun
        if (Input.GetKeyDown(KeyCode.Q))
        {
            reloadCD.fillAmount = 0;
            reloading = false;
            nextGun.SetActive(true);
            gameObject.SetActive(false);
        }
    }
    void OnEnable()
    {
        switching = true;
        switchFinishTime = 0;
        // TODO: Play switch animation
        ammoDisplay.GetComponent<TextMeshProUGUI>().text = "Ammo: " + ammo;
    }
}
