using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIWaypoint : MonoBehaviour
{
    public List<Transform> wayPoint; 
    NavMeshAgent navMeshAgent;
    public int currentWaypointIndex = 0;
    private Quaternion initialRotation;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        initialRotation = transform.rotation;
    }

    void Update()
    {
        Walking();
    }

    private void Walking()
    {

        if (wayPoint.Count == 0)
        {
     
            return;
        }

     
        float distanceToWaypoint = Vector3.Distance(wayPoint[currentWaypointIndex].position, transform.position);

        // Check if the agent is close enough to the current waypoint
        if (distanceToWaypoint <= 2)
        {
         
            currentWaypointIndex = (currentWaypointIndex + 1) % wayPoint.Count;
        }

        // Set the destination to the current waypoint
        navMeshAgent.SetDestination(wayPoint[currentWaypointIndex].position);

        transform.rotation = initialRotation;
    }
}
