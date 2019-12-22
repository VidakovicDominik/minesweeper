using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    public Canvas settings;
    public Canvas mainMenu;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Awake()
    {
        musicSlider.value = PlayerPrefs.GetFloat("music");
        sfxSlider.value = PlayerPrefs.GetFloat("sfx");
    }

    public void StartGameEasy()
    {
        GameMode.SetLevelLength(100);
        GameMode.SetMineCount(200);
        SceneManager.LoadScene("GameScene");

    }

    public void StartGameMeduim()
    {
        GameMode.SetLevelLength(150);
        GameMode.SetMineCount(400);
        SceneManager.LoadScene("GameScene");
    }

    public void StartGameHard()
    {
        GameMode.SetLevelLength(250);
        GameMode.SetMineCount(700);
        SceneManager.LoadScene("GameScene");
    }

    public void OpenSettings()
    {
        mainMenu.gameObject.SetActive(false);
        settings.gameObject.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenu.gameObject.SetActive(true);
        settings.gameObject.SetActive(false);
        SaveSettings();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("music", musicSlider.value);
        PlayerPrefs.SetFloat("sfx", sfxSlider.value);
    }
}
