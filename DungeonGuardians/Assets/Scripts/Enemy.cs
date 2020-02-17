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
    protected int points;
    protected GridTile position;
    private GridManager gridManager;
    private List<GameObject> waypoints;
    private Transform targetWaypoint;
    private int waypointIndex;

    // Start is called before the first frame update
    void Start()
    {
        gridManager = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<GridManager>();
        waypointIndex = 0;
        waypoints = gridManager.EnemyWaypoints;
    }

    // Update is called once per frame
    void Update()
    {
        WalkToWaypoints();
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

    public void damage(int damage, Player player)
    {
        health -= damage;
        if(health <= 0)
        {
            death(player);
        }
    }

    protected void death(Player player)
    {
        player.AddMoney(15);
        player.AddPoints(points);
    }

    // Have enemies walk to waypoints
    private void WalkToWaypoints()
    {
        targetWaypoint = waypoints[waypointIndex].transform;

        // Debug.Log("Current Waypoint: " + waypointIndex);

        Vector2 dir = new Vector2(targetWaypoint.position.x - transform.position.x, targetWaypoint.position.y - transform.position.y);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector2.Distance(transform.position, targetWaypoint.position) <= 0.1f)
        {
            waypointIndex++;

            if(waypointIndex >= waypoints.Count - 1)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
