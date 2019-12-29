using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject playerPrefab;
    public GameObject spotlight;
    public GameObject mainCamera;
    private GameObject faceCamera;
    public GameObject playerHolder;
    public GameObject timelineManager;
    public GameObject winScreen;
    public GameObject hudScreen;
    public MinefieldManager minefieldManager;
    private float timer = 120;
    public Text timerText;

    private PlayerController player;

    private bool gameOver = false;

    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    void Start()
    {
        timer = GameMode.GetTime();
        player = Instantiate(playerPrefab, new Vector3(playerHolder.transform.position.x, 1, playerHolder.transform.position.z),
         Quaternion.identity, playerHolder.transform).GetComponent<PlayerController>();
        spotlight = Instantiate(spotlight, new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z), spotlight.transform.rotation);
    }

    void Update()
    {
        if (!gameOver && timer > 0)
        {
            timer -= Time.deltaTime;
            timerText.text = "" + timer;
        }
        else if(!gameOver)
        {
            initGameOver(false);
        }
    }

    public void initGameOver(bool stageCleared)
    {
        gameOver = true;
        player.kill();
        hudScreen.SetActive(false);
        if (stageCleared)
        {
            winScreen.SetActive(true);
        }
        if(!stageCleared)
        {
            timelineManager.GetComponent<PlayableDirector>().Play();
        }
    }

    public GameObject getPlayer()
    {
        return player.gameObject;
    }

    public void setFaceCamera(GameObject camera)
    {
        this.faceCamera = camera;
    }

    public GameObject getFaceCamera()
    {
        return faceCamera;
    }

    #region UI Management
    public void returnToMainMenu()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void restartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    #endregion
}
