using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class armAim : MonoBehaviour
{
    private float mouseSensitivity;
    public Camera cam;
    public MouseRotate sens;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        mouseSensitivity = sens.mouseSensitivity * 0.8f;
        float Y = Input.GetAxis("Mouse Y") * mouseSensitivity;

        if((cam.transform.eulerAngles.x + (-Y) > 80 && cam.transform.eulerAngles.x + (-Y) < 280)) {
            Y = 0;
        }

        this.gameObject.transform.Rotate(-Y, 0, 0);

    }
}