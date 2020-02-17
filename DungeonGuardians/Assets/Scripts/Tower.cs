using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER { PLAYER1, PLAYER2 };

//Base class for all types of towers
public class Tower : MonoBehaviour
{
    public enum TOWERTYPE{Arrow,Heal,AOE};
    protected TOWERTYPE type;
    protected PLAYER playerSide;
    protected Player owner;
    protected int range;
    protected int damage;
    protected int maxTargets;
    protected int attackSpeed;
    protected int cost;
    protected GridTile position;
    protected GridManager gridManager;
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

    public void attackEnemiesWithinRange()
    {
        int attacksDone = 0;
        List<Enemy> allEnemies = gridManager.GetEnemiesWithinRange(position, range);
        foreach(Enemy eachEnemy in allEnemies)
        {
            attackEnemy(eachEnemy, damage);
            attacksDone++;
            if(attacksDone == maxTargets)
            {
                break;
            }
        }
    }

    public void attackEnemy(Enemy enemy, int damage)
    {
        enemy.damage(damage, owner);
    }
}
