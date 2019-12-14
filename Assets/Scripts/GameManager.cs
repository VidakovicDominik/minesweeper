using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public GameObject tilePrefab;
    public GameObject playerPrefab;
    public GameObject spotlight;
    public GameObject mainCamera;
    public GameObject goalWall;
    public GameObject faceCamera;
    public GameObject playerHolder;
    public GameObject timelineManager;

    private static int sizeX = 20;

    private PlayerController player;
    private Tile[,] minefield;

    private bool gameOver=false;


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
        player = Instantiate(playerPrefab, new Vector3(playerHolder.transform.position.x,1, playerHolder.transform.position.z), Quaternion.identity,playerHolder.transform).GetComponent<PlayerController>();
        spotlight = Instantiate(spotlight, new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z), spotlight.transform.rotation);
        //mainCamera.GetComponent<CinemachineVirtualCamera>().m_Follow = player.transform;
        //mainCamera.GetComponent<CinemachineVirtualCamera>().m_LookAt = player.transform;

        init();
    }

    public void init()
    {
        bool[,] mineLocations = getMineLocations();
        minefield = new Tile[sizeX, GameMode.GetLevelLength()];
        getMineLocations();
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < GameMode.GetLevelLength(); j++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3(i * 1.02f, 0, j * 1.02f), Quaternion.identity).GetComponent<Tile>();
                if (mineLocations[i, j])
                {
                    tile.isMine = true;
                    tile.setText("M");
                }
                tile.setCoordinates(i + "," + j);
                minefield[i, j] = tile;
            }
            if (i == sizeX - 1)
            {
                Instantiate(goalWall, new Vector3(9.7f, 5, GameMode.GetLevelLength() + 2), Quaternion.identity);
            }
        }
        foreach(Tile tile in minefield)
        {
            if (!tile.isMine)
            {
                int neighbouringMines = countNeighbouringMines(int.Parse(tile.coordinates.Split(',')[0]), int.Parse(tile.coordinates.Split(',')[1]));
                tile.setText("" + neighbouringMines);
                if (neighbouringMines == 0)
                {
                    tile.isLoner = true;
                    tile.setText("");
                }
            }
        }
    }

    public void cascade(int x, int y)
    {
        foreach(Tile tile in getNeighbouringTiles(x, y))
        {
            tile.clearField();
            if (tile.isLoner)
            {
                tile.isLoner = false;
                cascade(int.Parse(tile.coordinates.Split(',')[0]), int.Parse(tile.coordinates.Split(',')[1]));
            }
        }
    }

    private bool[,] getMineLocations()
    {
        bool[,] mineLocations = new bool[sizeX, GameMode.GetLevelLength()];

        int minesPlaced = 0;
        while (minesPlaced < GameMode.GetMineCount())
        {
            int x = UnityEngine.Random.Range(0, sizeX);
            int y = UnityEngine.Random.Range(0, GameMode.GetLevelLength());

            if (!mineLocations[x, y])
            {
                mineLocations[x, y] = true;
                minesPlaced++;
            }
        }
        return mineLocations;
    }

    private int countNeighbouringMines(int x, int y)
    {
        int counter = 0;
        foreach (Tile tile in getNeighbouringTiles(x, y))
        {
            if (tile.isMine)
            {
                counter++;
            }
        }
        return counter;
    }

    private ArrayList getNeighbouringTiles(int x, int y)
    {
        ArrayList neighbouringTiles = new ArrayList();
        addTileToList(neighbouringTiles, x - 1, y - 1);
        addTileToList(neighbouringTiles, x - 1, y + 1);
        addTileToList(neighbouringTiles, x - 1, y);
        addTileToList(neighbouringTiles, x, y + 1);
        addTileToList(neighbouringTiles, x, y - 1);
        addTileToList(neighbouringTiles, x + 1, y - 1);
        addTileToList(neighbouringTiles, x + 1, y + 1);
        addTileToList(neighbouringTiles, x + 1, y);
        return neighbouringTiles;
    }

    private void addTileToList(ArrayList list, int x, int y)
    {
        try
        {
            list.Add(minefield[x, y]);
        }
        catch (IndexOutOfRangeException e)
        {
        }
    }

    public void initGameOver()
    {
        gameOver = true;
        player.kill();
        //SceneManager.LoadScene("MainMenuScene");
        timelineManager.GetComponent<PlayableDirector>().Play();
    }

    public GameObject getPlayer()
    {
        return player.gameObject;
    }
}
