using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DynamicSpawning : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public LayerMask whatIsGrounded, whatIsPlayer; 
    public float range; //radius of sphere
    public float InRange, OutRange;
    public bool playerInSightRange, playerOutSightRange;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Third Person").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, InRange, whatIsPlayer);
        playerOutSightRange = Physics.CheckSphere(transform.position, OutRange, whatIsPlayer);

        if(!playerInSightRange && !playerOutSightRange) Spawn();
        if(playerInSightRange && !playerOutSightRange)  Despawn();
    }

    private void Spawn()
    {

    }

    private void Despawn()
    {

    }
}
