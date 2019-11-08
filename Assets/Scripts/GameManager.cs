using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    private Tile[,] minefield;
    public GameObject tilePrefab;
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
        init();
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void init()
    {
        minefield = new Tile[sizeX, sizeY];
        for(int i = 0; i < sizeX; i++)
        {
            for(int j = 0; j < sizeY; j++)
            {
                minefield[i, j] = Instantiate(tilePrefab, new Vector3(i*1.02f, 0, j*1.02f), Quaternion.identity).GetComponent<Tile>();
            }
        }
    }

    private void placeMines()
    {
        int minesPlaced = 0;
        while (minesPlaced < numberOfMines)
        {
            int x = Random.Range(0, sizeX);
            int y = Random.Range(0, sizeY);

            if (minefield[y,x].getType().Equals(TileType.MINE))
            {
                minefield[y,x] = new Tile(TileType.MINE);
                minesPlaced++;
            }
        }
    }

    private void fillWarningTiles()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                if (!minefield[i, j].getType().Equals(TileType.MINE))
                {

                }
            }
        }
}
