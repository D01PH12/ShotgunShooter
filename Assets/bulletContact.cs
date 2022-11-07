using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class bulletContact : MonoBehaviour
{
    public float damage;
    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        child = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            collision.gameObject.GetComponent<EnemyAI>().reduceHealth(damage);
            Destroy(gameObject);
        } else if (!collision.gameObject.CompareTag("Player"))
        {
            // TODO: Play particle effect of hitting the ground
            // TODO: Make noise
            Destroy(gameObject);
        }
    }
}
