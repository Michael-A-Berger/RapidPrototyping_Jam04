using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Base class for all enemy types
public class Enemy : MonoBehaviour
{
    public enum PLAYER {PLAYER1, PLAYER2 };
    public enum ENEMYTYPE{WEAK,TANKY,FAST};
    public GameObject healthBarHolder;
    public SpriteRenderer healthBar;
    protected ENEMYTYPE type;
    public PLAYER playerSide;
    protected int maxHealth;
    protected int health;
    protected int speed;
    protected int points;
    protected Vector2 position;
    private GridManager gridManager;
    private WaveSpawner waveSpawner;
    private UIScript uiScript;
    private List<GameObject> waypoints;
    private Transform targetWaypoint;
    private int waypointIndex;

    // Start is called before the first frame update
    public void Start()
    {
        waveSpawner = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<WaveSpawner>();
        gridManager = GameObject.FindGameObjectWithTag("Grid Holder").GetComponent<GridManager>();
        uiScript = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIScript>();
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

        UpdateHealthBar();

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        if(health <= 0)
        {
            death(player);
        }
    }

    public void UpdateHealthBar()
    {
        float healthPercent = (float)health / maxHealth;
        healthBarHolder.transform.localScale = new Vector3(healthPercent, 1, 1);
        if (healthPercent > 0.5f)
            healthBar.color = new Color(1f - (healthPercent - 0.5f) / 0.5f, 1f, 0f);
        else
            healthBar.color = new Color(1f, (healthPercent / 0.5f), 0f);
    }

    protected void death(Player player)
    {
        player.AddMoney(5);
        player.AddPoints(points);
        waveSpawner.enemiesList.Remove(gameObject);
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>().PlaySound("Enemy Death");
        Destroy(gameObject,0);
    }

    // Have enemies walk to waypoints
    private void WalkToWaypoints()
    {
        // reached the last waypoint - lose condition
        if (waypointIndex >= waypoints.Count - 1)
        {
            Destroy(this.gameObject);
            uiScript.AllPlayersLose();
        }

        targetWaypoint = waypoints[waypointIndex].transform;
        //Debug.Log(waypointIndex);

        Vector2 dir = (Vector2)(targetWaypoint.position - transform.position);
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        float dist = Vector2.Distance(transform.position, targetWaypoint.position);

        if (dist <= Time.deltaTime * speed) // close enough to start moving on to next waypoint
        {
            transform.position = targetWaypoint.position;
            waypointIndex++;
        }
    }
}
