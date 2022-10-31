using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class armAim : MonoBehaviour
{
    Vector3 lastMouseCoordinate = Vector3.zero;
    public bool invertMouse;
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
        // First we find out how much it has moved, by comparing it with the stored coordinate.
        //Vector3 mouseDelta = Input.GetAxis("Mouse Y") - lastMouseCoordinate;
        //curr = cam.transform.rotation.y;
        //diff = curr - prev;

        //this.transform.Rotate(diff, 0, 0);

        //this.transform.Rotate(Input.GetAxis("Mouse Y") * mouseSensitivity * ((invertMouse) ? 1 : -1), 0, 0);

        if (Input.GetAxis("Mouse Y") > 0)
        {
            this.transform.Rotate((float)-0.3, 0, 0);
        }

        if (Input.GetAxis("Mouse Y") < 0)
        {
            this.transform.Rotate((float)0.3, 0, 0);
        }

        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
        //prev = curr;
    }
}