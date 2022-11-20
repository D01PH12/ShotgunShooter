using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool paused;
    public GameObject options;
    public GameObject gunParent;
    public MouseRotate camH;
    public armAim camV;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            // pause
            if (!paused)
            {
                options.SetActive(true);
                options.GetComponent<MainMenu>().LoadPrefs();
                gunParent.SetActive(false);
                Time.timeScale = 0f;
                Cursor.lockState = CursorLockMode.None;
                camH.enabled = false;
                camV.enabled = false;
                paused = true;
            }
            else
            // unpause
            {
                Unpause();
            }
        }
    }
    public void Unpause()
    {
        options.GetComponent<MainMenu>().SavePrefs();
        options.SetActive(false);
        gunParent.SetActive(true);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        camH.enabled = true;
        camV.enabled = true;
        paused = false;
    }
}
