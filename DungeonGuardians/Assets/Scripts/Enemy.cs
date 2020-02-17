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
    protected int maxHealth;
    protected int health;
    protected int speed;
    protected int points;
    protected Vector2 position;
    private GridManager gridManager;
    private WaveSpawner waveSpawner;
    private List<GameObject> waypoints;
    private Transform targetWaypoint;
    private int waypointIndex;

    // Start is called before the first frame update
    public void Start()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<WaveSpawner>();
        gridManager = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<GridManager>();
        waypointIndex = 0;
        if(this.tag == "Enemy1")
        {
            waypoints = gridManager.Enemy1Waypoints;
        }
        if (this.tag == "Enemy2")
        {
            waypoints = gridManager.Enemy2Waypoints;
        }
    }

    // Update is called once per frame
    public void Update()
    {
        WalkToWaypoints();

        position = transform.position;
    }

    public void moveToTile(GridTile tile)
    {
        //Code stub for animation to move
        //position.enemiesOnTile.Remove(this);
        //tile.enemiesOnTile.Add(this);
    }

    public void autoMove()
    {
        //Find next tile to move to and call moveToTile()
    }

    public void damage(int damage, Player player)
    {
        health -= damage;
        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health <= 0)
        {
            death(player);
        }
    }

    protected void death(Player player)
    {
        player.AddMoney(15);
        player.AddPoints(points);
        waveSpawner.enemiesList.Remove(gameObject);
        Destroy(gameObject,0);
    }

    // Have enemies walk to waypoints
    private void WalkToWaypoints()
    {
        // reached the last waypoint - lose condition
        if (waypointIndex >= waypoints.Count - 1)
        {
            Destroy(this.gameObject);
        }

        targetWaypoint = waypoints[waypointIndex].transform;
        //Debug.Log(waypointIndex);

        Vector2 dir = (Vector2)(targetWaypoint.position - transform.position);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        float dist = Vector2.Distance(transform.position, targetWaypoint.position);

        if (dist <= 0.006f) // close enough to move on to next waypoint
        {
            waypointIndex++;
        }
    }
}
