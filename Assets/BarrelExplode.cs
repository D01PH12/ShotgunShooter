using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    public GameObject explode;
    public float scale;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Bullet")) {

            
            GameObject boom = Instantiate(explode, gameObject.transform.position, Quaternion.identity);
            boom.transform.localScale = new Vector3(scale, scale, scale);
            Destroy(gameObject);
        }    
    }
}
