using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelExplode : MonoBehaviour
{
    public GameObject explode;
    public float damage;
    public float radius;
    public float scale;

    public void Explode() {
        GameObject boom = Instantiate(explode, gameObject.transform.position, Quaternion.identity);
        boom.transform.localScale = new Vector3(scale, scale, scale);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Destroy(gameObject);

        foreach (var enemy in enemies) {
            if (Vector3.Distance(enemy.transform.position, gameObject.transform.position) < radius) {
                enemy.GetComponent<EnemyAI>().reduceHealth(damage);
            }
        }
        {
                
        }
    }
}
