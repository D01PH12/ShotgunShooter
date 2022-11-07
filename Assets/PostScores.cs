using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PostScores : MonoBehaviour
{
    public Text score;
    public Text shots;
    // Start is called before the first frame update
    void Start()
    {
        GameObject data = GameObject.Find("data");
        score.text = "SCORE: " + data.GetComponent<dataStore>().scoreStore.ToString();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("StartScreen");
        }
    }

}
