using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseRotate : MonoBehaviour
{

    public float mouseSensitivity;
    public GameObject cam;
    public GameObject camTarget;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float X = Input.GetAxis("Mouse X") * mouseSensitivity;
        float Y = Input.GetAxis("Mouse Y") * mouseSensitivity;
        this.gameObject.transform.Rotate(0, X, 0);

        if(!(cam.transform.eulerAngles.x + (-Y) > 80 && cam.transform.eulerAngles.x + (-Y) < 280)) {
            cam.transform.RotateAround(camTarget.transform.position, cam.transform.right, -Y);
        }

    }
    private void OnEnable()
    {
        mouseSensitivity = PlayerPrefs.GetFloat("sens") * 9;
    }
}
