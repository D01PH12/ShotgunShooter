using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class PostScores : MonoBehaviour
{
    public TextMeshProUGUI scores;
    public TextMeshProUGUI names;
    // Start is called before the first frame update
    void Start()
    {
        SaveScoreToLeaderBoard();
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    void SaveScoreToLeaderBoard() {
        string jsonInput = System.IO.File.ReadAllText("./leaderboard.json");
        leaderboardObject[] leaderboard = JsonHelper.FromJson<leaderboardObject>(jsonInput);
        for (int i = 0; i < leaderboard.Length; ++i)
        {
            if (dataStore.score > int.Parse(leaderboard[i].score))
            {
                // TODO: Prompt name; if not entered, break execution
                string name = "placeholder";
                // Walk backward changing scores
                for (int j = leaderboard.Length - 1; j > i; --j)
                {
                    leaderboard[j] = leaderboard[j - 1];
                }
                leaderboard[i] = new leaderboardObject(dataStore.score.ToString(), name);
                Write(JsonHelper.ToJson(leaderboard));
                break;
            }
        }
        scores.text = "Score";
        names.text = "Name";
        for (int i = 0; i < leaderboard.Length; ++i)
        {
            scores.text += "\n" + leaderboard[i].score;
            names.text += "\n" + leaderboard[i].name;
        }
    }
    async void Write(string text)
    {

        await File.WriteAllTextAsync("./leaderboard.json", text);
    }
}

[System.Serializable]
public class leaderboardObject
{
    public string score;
    public string name;

    public leaderboardObject(string inScore, string inName)
    {
        score = inScore;
        name = inName;
    }
}

public static class JsonHelper
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}