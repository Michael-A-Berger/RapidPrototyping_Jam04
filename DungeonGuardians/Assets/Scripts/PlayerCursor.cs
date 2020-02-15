using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCursor : MonoBehaviour
{
    // Public Properties
    public GridManager gridManager = null;
    [Range(1,4)]
    public int playerNum = 1;
    public bool usingController = false;

    // Private Properties
    private GameObject cursor = null;

    // Start()
    void Start()
    {
        // IF the grid manager is null, complain about it
        if (gridManager == null)
        {
            Debug.LogError("\"gridManager\" was not set!");
        }

        // Getting the child cursor object
        cursor = transform.Find("Cursor").gameObject;

        // Starting the wait coroutine so that the GridManager can create the grid
        StartCoroutine(WaitToStart());
    }

    // WaitToStart()
    IEnumerator WaitToStart()
    {
        yield return new WaitForSeconds(0.01f);
        SetCursorStart();
    }

    // SetCursorStart()
    public void SetCursorStart()
    {
        Vector2Int gridSize = gridManager.GetGridSize();
        switch (playerNum)
        {
            case 1:
                PlaceCursorAtPos(0, 0);
                break;
            case 2:
                PlaceCursorAtPos(gridSize.x - 1, 0);
                break;
            case 3:
                PlaceCursorAtPos(0, gridSize.y - 1);
                break;
            case 4:
                PlaceCursorAtPos(gridSize.x - 1, gridSize.y - 1);
                break;
            default:
                Debug.LogError("Case for Player "+playerNum+" in SetCursorStart() is not defined!");
                break;
        }
    }

    // PlaceCursorAtPos()
    public void PlaceCursorAtPos(int x, int y)
    {
        GridTile tileScript = gridManager.GetGridTileAtPos(x, y);
        cursor.transform.position = tileScript.gameObject.transform.position;
        cursor.transform.Translate(0.0f, 0.0f, -1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
