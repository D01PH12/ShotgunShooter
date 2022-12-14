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
    public leaderboardObject[] leaderboard;
    private int index;
    // Start is called before the first frame update
    void Start()
    {
        // If on win screen. Not death screen
        if (names != null)
        {
            Cursor.lockState = CursorLockMode.None;
            SaveScoreToLeaderBoard();
        } else
        {
            StartCoroutine(ReturnToMainMenuAfterDelay(10.0f));
        }
    }

    void Update() {
        if(scores.gameObject.activeSelf && Input.GetKeyDown(KeyCode.Space)) {
            Cursor.lockState = CursorLockMode.None;
            dataStore.score = 0;
            SceneManager.LoadScene(0);
        }
    }

    void SaveScoreToLeaderBoard() {
        string jsonInput;
        try
        {
            jsonInput = System.IO.File.ReadAllText("./leaderboard.json");
        } catch (IOException)
        {
            jsonInput = "{\"Items\":[{\"score\":\"0\",\"name\":\"-----\"},{\"score\":\"0\",\"name\":\"-----\"},{\"score\":\"0\",\"name\":\"-----\"},{\"score\":\"0\",\"name\":\"-----\"},{\"score\":\"0\",\"name\":\"-----\"}]}";
        }
        leaderboard = JsonHelper.FromJson<leaderboardObject>(jsonInput);
        for (index = 0; index < leaderboard.Length; ++index)
        {
            if (dataStore.score > int.Parse(leaderboard[index].score))
            {
                // If no input is detected, skip to leaderboard
                StartCoroutine(SkipHighscoreAfterDelay(30.0f));
                return;
            }
        }
        // If not on the leaderboard, just show it
        ShowLeaderboard(null);
    }

    public void ShowLeaderboard(TextMeshProUGUI name)
    {
        // Disable input
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;

        // If input, add to leaderboard
        if (name != null && name.text != "")
        {
            // Walk backward changing scores
            for (int j = leaderboard.Length - 1; j > index; --j)
            {
                leaderboard[j] = leaderboard[j - 1];
            }
            leaderboard[index] = new leaderboardObject(dataStore.score.ToString(), name.text);
            Write(JsonHelper.ToJson(leaderboard));
        }

        // Show leaderboard
        scores.text = "Score";
        names.text = "Name";
        for (int i = 0; i < leaderboard.Length; ++i)
        {
            scores.text += "\n" + leaderboard[i].score;
            names.text += "\n" + leaderboard[i].name;
        }
        StartCoroutine(ReturnToMainMenuAfterDelay(45.0f));
    }
    async void Write(string text)
    {

        await File.WriteAllTextAsync("./leaderboard.json", text);
    }
    private IEnumerator ReturnToMainMenuAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        Cursor.lockState = CursorLockMode.None;
        dataStore.score = 0;
        SceneManager.LoadScene(0);
    }

    private IEnumerator SkipHighscoreAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        ShowLeaderboard(null);
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