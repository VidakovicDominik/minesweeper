using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinefieldManager : MonoBehaviour
{
    public GameObject tilePrefab;
    private static int sizeX = 20;
    private PlayerController player;
    public GameObject goalWall;

    private Tile[,] minefield;

    // Start is called before the first frame update
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void init()
    {
        bool[,] mineLocations = getMineLocations();
        minefield = new Tile[sizeX, GameMode.GetLevelLength()];
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < GameMode.GetLevelLength(); j++)
            {
                Tile tile = Instantiate(tilePrefab, new Vector3(i * 1.02f, 0, j * 1.02f), Quaternion.identity).GetComponent<Tile>();
                if (mineLocations[i, j])
                {
                    tile.isMine = true;
                    tile.setText("F");
                }
                tile.setCoordinates(new Coordinates(i,j));
                minefield[i, j] = tile;
            }
            if (i == sizeX - 1)
            {
                Instantiate(goalWall, new Vector3(9.7f, 5, GameMode.GetLevelLength() + 2), Quaternion.identity);
            }
        }
        foreach (Tile tile in minefield)
        {
            if (!tile.isMine)
            {
                int neighbouringMines = countNeighbouringMines(tile.coordinates);
                tile.setText("" + neighbouringMines);
                if (neighbouringMines == 0)
                {
                    tile.isLoner = true;
                    tile.setText("");
                }
            }
        }
    }

    public void cascade(Coordinates coordinates)
    {
        foreach (Tile tile in getNeighbouringTiles(coordinates))
        {
            tile.clearField();
            if (tile.isLoner)
            {
                tile.isLoner = false;
                cascade(tile.coordinates);
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

            if (!mineLocations[x, y]&&y!=0)
            {
                mineLocations[x, y] = true;
                minesPlaced++;
            }
        }
        return mineLocations;
    }

    private int countNeighbouringMines(Coordinates coordinates)
    {
        int counter = 0;
        foreach (Tile tile in getNeighbouringTiles(coordinates))
        {
            if (tile.isMine)
            {
                counter++;
            }
        }
        return counter;
    }

    private ArrayList getNeighbouringTiles(Coordinates coordinates)
    {
        int x=coordinates.getX();
        int y=coordinates.getY();

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

    public Tile[,] getMinefield(){
        return minefield;
    }
}
