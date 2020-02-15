using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTile : MonoBehaviour
{
    // Public Properties
    public GameObject placedTower = null;
    public Vector2Int gridPos = new Vector2Int(int.MinValue, int.MinValue);
    public bool canPlaceTowers = true;
}
