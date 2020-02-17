using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public GameObject arrowTowerPrefab;
    public GameObject aoeTowerPrefab;
    public GameObject healTowerPrefab;
    private GridManager gridManager;
    private bool test = false;
    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<GridManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!test)
        {
            GridTile tile = gridManager.GetGridTileAtPos(3, 3);
            Instantiate(arrowTowerPrefab, tile.transform.position, tile.transform.rotation);
            tile = gridManager.GetGridTileAtPos(6, 6);
            Instantiate(healTowerPrefab, tile.transform.position, tile.transform.rotation);
            tile = gridManager.GetGridTileAtPos(8, 2);
            Instantiate(aoeTowerPrefab, tile.transform.position, tile.transform.rotation);
            test = true;
        }
    }

    public void placeArrowTower(GridTile tile)
    {
        Instantiate(arrowTowerPrefab, tile.transform.position, tile.transform.rotation);
    }

    public void placeAoeTower(GridTile tile)
    {
        Instantiate(aoeTowerPrefab, tile.transform.position, tile.transform.rotation);
    }

    public void placeHealTower(GridTile tile)
    {
        Instantiate(healTowerPrefab, tile.transform.position, tile.transform.rotation);
    }


}
