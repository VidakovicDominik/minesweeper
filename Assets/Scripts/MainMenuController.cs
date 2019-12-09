using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    void Awake()
    {
        GameMode.staticInstance.GetMineCount();
    }

    public void StartGameEasy()
    {
        GameMode.staticInstance.SetLevelLength(100);
        GameMode.staticInstance.SetMineCount(200);
        SceneManager.LoadScene("GameScene");

    }

    public void StartGameMeduim()
    {
        GameMode.staticInstance.SetLevelLength(150);
        GameMode.staticInstance.SetMineCount(350);
        SceneManager.LoadScene("GameScene");
    }

    public void StartGameHard()
    {
        GameMode.staticInstance.SetLevelLength(250);
        GameMode.staticInstance.SetMineCount(500);
        SceneManager.LoadScene("GameScene");
    }

}
