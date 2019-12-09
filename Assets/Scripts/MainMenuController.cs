using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    void Awake()
    {
        GameMode.GetMineCount();
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
        GameMode.SetMineCount(350);
        SceneManager.LoadScene("GameScene");
    }

    public void StartGameHard()
    {
        GameMode.SetLevelLength(250);
        GameMode.SetMineCount(500);
        SceneManager.LoadScene("GameScene");
    }

}
