using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PLAYER { PLAYER1, PLAYER2 };

//Base class for all types of towers
public class Tower : MonoBehaviour
{
    public enum TOWERTYPE{Arrow,Heal,AOE};
    protected TOWERTYPE type;
    public PLAYER playerSide;
    public Player owner;
    protected int range;
    protected int damage;
    protected int maxTargets;
    protected int attackSpeed;
    protected GridTile position;
    protected GridManager gridManager;
    protected WaveSpawner waveSpawner;
    protected float attackCooldown;
    protected float timeSinceAttack=0;
    // Start is called before the first frame update
    public void Start()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<WaveSpawner>();
    }

    // Update is called once per frame
    public void Update()
    {
        attackEnemiesWithinRange();
    }

    public void placeTower(GridTile tile)
    {
        this.position = tile;
    }

    protected List<Enemy> getEnemiesWithinRange()
    {
        List<Enemy> enemiesInRange = new List<Enemy>();
        List<GameObject> allEnemies = waveSpawner.enemiesList;
        foreach(GameObject enemy in allEnemies)
        {
            Enemy enemyObject = enemy.GetComponent<Enemy>();
            if(Vector3.Distance(transform.position,enemyObject.transform.position) < range)
            {
                enemiesInRange.Add(enemyObject);
            }
        }
        return enemiesInRange;
    }

    public void attackEnemiesWithinRange()
    {
        if (timeSinceAttack >= attackCooldown)
        {
            timeSinceAttack = 0f;
            int attacksDone = 0;
            List<Enemy> validEnemies = getEnemiesWithinRange();
            Debug.Log("ATTACKING");
            Debug.Log(validEnemies.Count);
            foreach (Enemy eachEnemy in validEnemies)
            {
                //if((int)eachEnemy.playerSide != (int)playerSide)
                //{
                attackEnemy(eachEnemy, damage);
                attacksDone++;
                if (attacksDone == maxTargets)
                {
                    break;
                }
                //}
            }
        } else
        {
            timeSinceAttack += Time.deltaTime;
        }
    }

    public void attackEnemy(Enemy enemy, int damage)
    {
        enemy.damage(damage, owner);
    }

    public void BuffTower()
    {
        range += 1;
        attackCooldown -= 1.0f;
        if (attackCooldown < 1.0f) attackCooldown = 1.0f;
    }
    public void DebuffTower()
    {
        range -= 1;
        if (range < 1) range = 1;
        attackCooldown += 1.0f;
    }
}
