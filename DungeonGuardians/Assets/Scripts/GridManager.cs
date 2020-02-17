﻿using System;
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
    private List<GameObject> grid = new List<GameObject>();
    private List<GameObject> enemyWaypoints = new List<GameObject>();
    public List<GameObject> EnemyWaypoints { get{ return enemyWaypoints; } }

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
        // Manual Attempt - add to enemy waypoint list
        GenerateEnemyWaypointList();

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

                grid.Add(tile);

                // Dynamic Attempt -  add to enemy waypoint list
                // if (col % 5 == 0 && row % 2 == 0)
                //{
                //    enemyWaypoints.Add(tile);
                //    Debug.Log("Column: " + col + "Row: " + row);
                //}
                //else if (col == 15 && row % 2 != 0)
                //{
                //    enemyWaypoints.Add(tile);
                //    Debug.Log("Column: " + col + "Row: " + row);
                //}

                //// Next step need to be able to reverse the order of a row after the vertical transition tile
            }
        }

        Destroy(p1Tile);
        Destroy(p2Tile);

        float gridWidth = cols * tileSize;
        float gridHeight = rows * tileSize;

        // divided by 2 because the pivot point for tiles is in the center
        transform.position = new Vector2(-gridWidth / 2 + tileSize / 2, gridHeight / 2 - tileSize / 2);
    }

    private void GenerateEnemyWaypointList()
    {
        // testing points

        enemyWaypoints.Add(grid[0]);
        enemyWaypoints.Add(grid[15]);
        enemyWaypoints.Add(grid[75]);

        //enemyWaypoints.Add(grid[30]);
        //enemyWaypoints.Add(grid[45]);
        //enemyWaypoints.Add(grid[40]);
        //enemyWaypoints.Add(grid[31]);

        //enemyWaypoints.Add(grid[46]);
        //enemyWaypoints.Add(grid[61]);
        //enemyWaypoints.Add(grid[70]);
        //enemyWaypoints.Add(grid[75]);

        //enemyWaypoints.Add(grid[105]);
        //enemyWaypoints.Add(grid[91]);
        //enemyWaypoints.Add(grid[121]);
        //enemyWaypoints.Add(grid[135]);
        //enemyWaypoints.Add(grid[165]);
        //enemyWaypoints.Add(grid[181]);
        //enemyWaypoints.Add(grid[225]);
        //enemyWaypoints.Add(grid[210]);
        //enemyWaypoints.Add(grid[226]);
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

    public List<Enemy> GetEnemiesWithinRange(GridTile tile, int range)
    {
        List<GridTile> tilesInRange = GetGridTilesWithinRange(tile, range);
        List<Enemy> allEnemiesWithinRange = new List<Enemy>();
        foreach(GridTile eachTile in tilesInRange)
        {
            allEnemiesWithinRange.AddRange(eachTile.enemiesOnTile);
        }
        return allEnemiesWithinRange;
    }

    //Get Tiles within range
    public List<GridTile> GetGridTilesWithinRange(GridTile tile, int range)
    {
        return tiles.FindAll(t => Mathf.Abs(t.gridPos.x - tile.gridPos.x) <= range && Mathf.Abs(t.gridPos.y - tile.gridPos.y) <= range);
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
