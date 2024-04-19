using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DynamicSpawning : MonoBehaviour
{
    
    public LayerMask whatIsPlayer; 
    public float InRange, OutRange;
    public bool playerInSightRange, playerOutSightRange;

    public GameObject enemySpawn;
    public Transform[] spawnPoint;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, InRange, whatIsPlayer);
        playerOutSightRange = Physics.CheckSphere(transform.position, OutRange, whatIsPlayer);

        if(!playerInSightRange && !playerOutSightRange) Despawn();
        if(playerInSightRange && !playerOutSightRange)  Spawn();
    }

    private void Spawn()
    {
        Instantiate(enemySpawn, spawnPoint[0].transform.position, Quaternion.identity);
    }
        
        
        
    private void Despawn()
    {
        Destroy(gameObject);
    }

}
