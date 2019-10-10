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
                minefield[i, j] = Instantiate(tilePrefab, new Vector3(i*1.1f, 0, j*1.1f), Quaternion.identity).GetComponent<Tile>();
            }
        }
    }
}
