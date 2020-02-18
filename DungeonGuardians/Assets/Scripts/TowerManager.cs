using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerManager : MonoBehaviour
{

    public GameObject arrowTowerPrefab;
    public GameObject aoeTowerPrefab;
    public GameObject healTowerPrefab;

    public int arrowTowerCost;
    public int aoeTowerCost;
    public int healTowerCost;

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

    }

    public bool placeArrowTower(GridTile tile, Player owner)
    {
        if (!owner.SpendMoney(arrowTowerCost)) return false;
        Vector3 pos = tile.transform.position;
        pos.z -= 0.5f;
        GameObject tower = Instantiate(arrowTowerPrefab, pos, tile.transform.rotation);
        tower.GetComponent<Tower>().owner = owner;
        tower.GetComponent<Tower>().playerSide = owner.player;
        tile.placedTower = tower;
        return true;
    }

    public bool placeAoeTower(GridTile tile, Player owner)
    {
        if (!owner.SpendMoney(aoeTowerCost)) return false;
        Vector3 pos = tile.transform.position;
        pos.z -= 0.5f;
        GameObject tower = Instantiate(aoeTowerPrefab, pos, tile.transform.rotation);
        tower.GetComponent<Tower>().owner = owner;
        tower.GetComponent<Tower>().playerSide = owner.player;
        tile.placedTower = tower;
        return true;
    }

    public bool placeHealTower(GridTile tile, Player owner)
    {
        if (!owner.SpendMoney(healTowerCost)) return false;
        Vector3 pos = tile.transform.position;
        pos.z -= 0.5f;
        GameObject tower = Instantiate(healTowerPrefab, pos, tile.transform.rotation);
        tower.GetComponent<Tower>().owner = owner;
        tower.GetComponent<Tower>().playerSide = owner.player;
        tile.placedTower = tower;
        return true;
    }

    public bool BuffTower(GridTile tile, Player owner)
    {
        if (!owner.SpendMoney(10)) return false;
        tile.placedTower.GetComponent<Tower>().BuffTower();
        return true;
    }

    public bool DebuffTower(GridTile tile, Player owner)
    {
        if (!owner.SpendMoney(10)) return false;
        tile.placedTower.GetComponent<Tower>().DebuffTower();
        return true;
    }
}
