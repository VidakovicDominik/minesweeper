using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private bool[,] mineLocations;
    private Tile[,] minefield;
    public GameObject tilePrefab;
    public GameObject player;
    public GameObject spotlight;
    public GameObject mainCamera;
    public int sizeX=10;
    public int sizeY=10;
    public int numberOfMines = 20;
    

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
        player=Instantiate(player, new Vector3(1, 1, -1), Quaternion.identity);
        spotlight=Instantiate(spotlight, new Vector3(player.transform.position.x, player.transform.position.y + 3, player.transform.position.z),spotlight.transform.rotation);
        mainCamera.GetComponentInChildren<CinemachineVirtualCamera>().m_Follow = player.transform;
        mainCamera.GetComponentInChildren<CinemachineVirtualCamera>().m_LookAt = player.transform;
        init();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void init()
    {
        mineLocations = new bool[sizeX, sizeY];
        minefield = new Tile[sizeX, sizeY];
        placeMines();
        for (int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3(i*1.02f, 0, j*1.02f*-1), Quaternion.identity).GetComponent<Tile>();
                if (mineLocations[i, j])
                {
                    tile.isMine = true;
                    tile.setText("M");
                }
                if (!mineLocations[i, j])
                {
                    tile.setText(countMines(i, j));
                }
                tile.setCoordinates(i + "," + j);
                minefield[i, j] = tile;
            }
        }
    }

    private void placeMines()
    {
        int minesPlaced = 0;
        while (minesPlaced < numberOfMines)
        {
            int x = UnityEngine.Random.Range(0, sizeX);
            int y = UnityEngine.Random.Range(0, sizeY);

            if (!mineLocations[x,y])
            {
                mineLocations[x,y] = true;
                minesPlaced++;
            }
        }
    }

    private string countMines(int x, int y)
    {
        int counter = 0;
        if (checkMine(x-1,y))
        {
            counter++;
        }
        if (checkMine(x-1, y-1))
        {
            counter++;
        }
        if (checkMine(x-1, y+1))
        {
            counter++;
        }
        if (checkMine(x, y-1))
        {
            counter++;
        }
        if (checkMine(x, y+1))
        {
            counter++;
        }
        if (checkMine(x+1, y))
        {
            counter++;
        }
        if (checkMine(x+1, y-1))
        {
            counter++;
        }
        if (checkMine(x+1, y+1))
        {
            counter++;
        }
        return "" + counter;
    }

    private bool checkMine(int x, int y)
    {
        try
        {
            return mineLocations[x, y];
        }catch(IndexOutOfRangeException e)
        {
            return false;
        }
        return false;
    }
}
