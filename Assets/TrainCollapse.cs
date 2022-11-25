using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCollapse : MonoBehaviour
{

    public GameObject trigger;
    public float triggerRange;
    public GameObject player;
    public AudioSource slide;

    void Start() {
        slide = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, trigger.transform.position) < triggerRange) {
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            slide.Play(0);
        }
    }
}
