using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{

    public NavMeshAgent agent; 
    public float range; //radius of sphere
    public float speedRun = 9;
    public Transform player;
    public string sceneName; //Transition to the other scene

    public Transform centrePoint; //centre of the area the agent wants to move around in

    public LayerMask whatIsSpawnArea, whatIsPlayer; 

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {   
        Transform whatIsSpawnArea = centrePoint;
        player = GameObject.Find("Third Person").transform;
        agent = GetComponent<NavMeshAgent>();
    }
    

    // Update is called once per frame
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if(!playerInSightRange && !playerInAttackRange) Wandering();
        if(playerInSightRange && !playerInAttackRange)  ChasePlayer();
 
    }

    private void Wandering ()
    {
        if(agent.remainingDistance <= agent.stoppingDistance) //done with path
        {
            Vector3 point;
            if (RandomPoint(centrePoint.position, range, out point)) //pass in our centre point and radius of area
            {
                Debug.DrawRay(point, Vector3.up, Color.blue, 1.0f); //so you can see with gizmos
                agent.SetDestination(point);
            }
        }
    }

       bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {

        Vector3 randomPoint = center + Random.insideUnitSphere * range; //random point in a sphere 
        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas)) //documentation: https://docs.unity3d.com/ScriptReference/AI.NavMesh.SamplePosition.html
        { 
            result = hit.position;
            return true;
        }

        result = Vector3.zero;
        return false;
    }
    private void ChasePlayer ()
    {
        agent.SetDestination(player.position);
        Move(speedRun);

    }


    void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneName);
            Destroy(gameObject);
        }

    }

    void Move(float speed)
    {
        agent.speed = speed;
    }

    
}

