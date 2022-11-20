using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataStore : MonoBehaviour
{
    public Text score;
    public int scoreStore;
    // Start is called before the first frame update
    void Start()
    {
        score.text = "Score: " + "0";
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + ((scoreStore).ToString());
    }
}
