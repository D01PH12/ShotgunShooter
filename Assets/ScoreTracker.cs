using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTracker : MonoBehaviour
{
    private Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        score.text = "Score: " + "0";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ((dataStore.score).ToString());
    }
}
