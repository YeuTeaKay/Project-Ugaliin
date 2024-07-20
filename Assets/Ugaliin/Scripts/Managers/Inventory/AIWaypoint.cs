using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWaypoint : MonoBehaviour
{
    public List<Transform> wayPoints; 
    NavMeshAgent navMeshAgent;
    public int currentWaypointIndex = 0;
    private Quaternion initialRotation;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialRotation = transform.rotation;

        if (wayPoints.Count > 0)
        {
            // Set an initial random waypoint
            currentWaypointIndex = Random.Range(0, wayPoints.Count);
            navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position);
        }
    }

    void Update()
    {
        Walking();
    }

    private void Walking()
    {

        if (wayPoints.Count == 0)
        {
     
            return;
        }

     
        float distanceToWaypoint = Vector3.Distance(wayPoints[currentWaypointIndex].position, transform.position);

        // Check if the agent is close enough to the current waypoint
        if (distanceToWaypoint <= 2)
        {
            // Select a random waypoint index
            currentWaypointIndex = Random.Range(0, wayPoints.Count);
        }


        Vector3 direction = wayPoints[currentWaypointIndex].position - transform.position;
        // Set the destination to the current waypoint
        navMeshAgent.SetDestination(wayPoints[currentWaypointIndex].position);

        // Determine the rotation based on the direction
        if (direction.x > 0)
        {
            // Rotate 180 degrees on the Y axis
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (direction.x < 0)
        {
            // Maintain 0 rotation on the Y axis
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
