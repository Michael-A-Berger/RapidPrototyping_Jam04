using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for all enemy types
public class Enemy : MonoBehaviour
{
    public enum PLAYER {PLAYER1, PLAYER2 };
    public enum ENEMYTYPE{WEAK,TANKY,FAST};
    protected ENEMYTYPE type;
    protected PLAYER playerside;
    protected int health;
    protected int speed;
    protected GridTile position;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveToTile(GridTile tile)
    {
        //Code stub for animation to move
        position.enemiesOnTile.Remove(this);
        tile.enemiesOnTile.Add(this);
    }

    public void autoMove()
    {
        //Find next tile to move to and call moveToTile()
    }

    public void damage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            death();
        }
    }

    protected void death()
    {

    }
}
