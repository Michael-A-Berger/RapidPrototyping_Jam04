using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: Lost Relic Games - https://www.youtube.com/watch?v=u2_O-jQDD6s

public class GridManager : MonoBehaviour
{
    // Public Properties
    public bool debug = false;

    // Private Properties
    [SerializeField]
    private int rows = 16;
    [SerializeField]
    private int cols = 16;
    [SerializeField]
    private float tileSize = 1;
    [SerializeField]
    private List<GridTile> tiles = new List<GridTile>();

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();

        if (debug)
            Debug_Init();
    }

    private void GenerateGrid()
    {
        GameObject p1Tile = (GameObject)Instantiate(Resources.Load("Player1_Tile"));
        GameObject p2Tile = (GameObject)Instantiate(Resources.Load("Player2_Tile"));

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                GameObject tile;

                if (col < 8)
                {
                    tile = Instantiate(p1Tile, transform);
                }
                else
                {
                    tile = Instantiate(p2Tile, transform);
                }

                GridTile tileScript = tile.GetComponent<GridTile>();
                tileScript.gridPos.x = col;
                tileScript.gridPos.y = row;

                tiles.Add(tileScript);

                float posX = col * tileSize;
                float posY = row * -tileSize;

                tile.transform.position = new Vector2(posX, posY);
            }
        }

        Destroy(p1Tile);
        Destroy(p2Tile);

        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;

        // divided by 2 because the pivot point for tiles is in the center
        transform.position = new Vector2(-gridWidth / 2 + tileSize / 2, gridHeight / 2 - tileSize / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (debug)
            Debug_Update();
    }

    // GetGridTileAtPos()
    public GridTile GetGridTileAtPos(int x, int y)
    {
        // Craeting the result to return
        GridTile result = null;

        // Using a lamba predicate to find the correct grid tile
        int index = tiles.FindIndex(t => t.gridPos.x == x && t.gridPos.y == y);
        if (index > -1)
            result = tiles[index];

        // Returning the result
        return result;
    }

    // GetGridSize()
    public Vector2Int GetGridSize()
    {
        return new Vector2Int(rows, cols);
    }

    // Debug_Init()
    private void Debug_Init()
    {
        for (int num = 0; num < tiles.Count; num += 2)
            tiles[num].canPlaceTowers = false;
    }

    // Debug_Update()
    private void Debug_Update()
    {
        for (int num = 0; num < 9; num++)
        {
            if (Input.GetKeyDown((KeyCode)(num + 49)))
            {
                GridTile test = GetGridTileAtPos(num, 0);
                if (test != null)
                    Debug.Log("canPlaceTowers (" + num + ", 0):\t" + test.canPlaceTowers);
            }
        }
    }
}
