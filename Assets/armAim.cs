using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class armAim : MonoBehaviour
{
    public float mouseSensitivity;
    public Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float Y = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if((cam.transform.eulerAngles.x + (-Y) > 80 && cam.transform.eulerAngles.x + (-Y) < 280)) {
            Y = 0;
        }

        this.gameObject.transform.Rotate(-Y, 0, 0);

    }
}