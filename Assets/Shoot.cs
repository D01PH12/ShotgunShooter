using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    public float velocity;
    public float fireRate;
    public GameObject cam;
    public GameObject spawnPoint;
    public Text shots;
    private float lastShootTime;

    // Start is called before the first frame update
    void Start()
    {
        shots.text = "Score: " + "0";
    }

    public float delay; //This implies a delay of 2 seconds.

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey(KeyCode.Mouse0) && Time.time > lastShootTime + fireRate) {
            lastShootTime = Time.time;
            GameObject bullet = Instantiate(projectile, spawnPoint.transform.position, cam.transform.rotation);
            bullet.GetComponent<Rigidbody>().AddForce(cam.transform.forward * velocity);
            shots.text = "SHOTS: " + ((int.Parse(shots.text.Split()[1]) + 1).ToString());
            Destroy(bullet, delay);
        }
        
    }
}
