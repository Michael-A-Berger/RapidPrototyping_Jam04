using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GridManager gridManager;
    private List<GameObject> waypoints;
    private Transform targetWaypoint;
    private int waypointIndex;
    [SerializeField]
    private float speed = 2f;

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
