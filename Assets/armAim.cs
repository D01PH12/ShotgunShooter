using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class armAim : MonoBehaviour
{

    Vector3 lastMouseCoordinate = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // First we find out how much it has moved, by comparing it with the stored coordinate.
        Vector3 mouseDelta = Input.mousePosition - lastMouseCoordinate;

        if (mouseDelta.y > 0)
        {
            this.transform.Rotate(-1, 0, 0);
        }

        if (mouseDelta.y < 0)
        {
            this.transform.Rotate(1, 0, 0);
        }

        // Then we store our mousePosition so that we can check it again next frame.
        lastMouseCoordinate = Input.mousePosition;
    }
}