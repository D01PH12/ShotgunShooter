using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    public GameObject explode;

    private void OnTriggerEnter(Collider other) {

        if (other.gameObject.CompareTag("Bullet")) {
            
            Instantiate(explode, gameObject.transform);
            Destroy(gameObject);
        }    
    }
}
