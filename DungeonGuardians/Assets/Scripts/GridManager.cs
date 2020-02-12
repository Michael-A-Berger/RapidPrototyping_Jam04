using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference: Lost Relic Games - https://www.youtube.com/watch?v=u2_O-jQDD6s

public class GridManager : MonoBehaviour
{
    [SerializeField]
    private int rows = 16;
    [SerializeField]
    private int cols = 16;
    [SerializeField]
    private float tileSize = 1;

    // Start is called before the first frame update
    void Start()
    {
        GenerateGrid();
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
                    tile = (GameObject)Instantiate(p1Tile, transform);
                }
                else
                {
                    tile = (GameObject)Instantiate(p2Tile, transform);
                }

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
        
    }
}
