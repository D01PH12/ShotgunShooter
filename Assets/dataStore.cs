using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dataStore : MonoBehaviour
{
    public Text score;
    public Text shots;
    public int scoreStore;
    public int shotsStore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreStore = int.Parse(score.text.Split()[1]);
        shotsStore = int.Parse(shots.text.Split()[1]);
    }
}
