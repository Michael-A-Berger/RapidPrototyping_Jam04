using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for all types of towers
public abstract class Tower : MonoBehaviour
{
    public enum TOWERTYPE{Arrow,Heal,AOE};
    protected TOWERTYPE type;
    protected int range;
    protected int damage;
    protected int maxTargets;
    protected int attackSpeed;
    protected GridTile position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void placeTower(GridTile tile)
    {
        this.position = tile;
    }
}
