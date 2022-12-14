using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMover : MonoBehaviour
{
    // reference to the waypoint system
    [SerializeField] private Waypoints waypoints;

    [SerializeField] private float moveSpeed = 1f;

    [SerializeField] private float distanceThreshold = 0.1f;

    // current waypoint target that the object is moving towards
    private Transform currentWaypoint;

    // trigger event handlers
    public GameObject triggerBoss;
    public float triggerRange;
    public GameObject player;
    bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        // set initial position to the first waypoint
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.position = currentWaypoint.position;

        // waypoint to next target
        currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
        transform.LookAt(player.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, triggerBoss.transform.position) < triggerRange)
        {
            move = true;
        }
        if(move == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint.position, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, currentWaypoint.position) < distanceThreshold)
            {
                currentWaypoint = waypoints.GetNextWaypoint(currentWaypoint);
                transform.LookAt(player.transform);
            }
        }

    }
}
