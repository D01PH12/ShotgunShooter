using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Slider soundSlider;
    public Slider musicSlider;
    public Slider sensSlider;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(0);
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetFloat("sound", soundSlider.value);
        PlayerPrefs.SetFloat("music", musicSlider.value);
        PlayerPrefs.SetFloat("sens", sensSlider.value);
        PlayerPrefs.Save();
    }
    public void LoadPrefs()
    {
        soundSlider.value = PlayerPrefs.GetFloat("sound");
        musicSlider.value = PlayerPrefs.GetFloat("music");
        sensSlider.value = PlayerPrefs.GetFloat("sens");
    }

}
