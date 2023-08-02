using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    public enum stateSpawn { SPAWNING, WAITING, COUNTING, FINISHED};

    [System.Serializable] // Make it so you can see it in the inspector
    public class Wave
    {
        public string name;
        public Transform[] enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private  int nextWave = 0;
    
    public Transform[] spawnPoints;
    public float timeBetweenWave = 5f; //Default 5 Secs
    private float waveCountdown; //Default 0 sec

    public stateSpawn state = stateSpawn.COUNTING;

    private float searchCD = 1f;
    void Start()
    {
        waveCountdown = timeBetweenWave;

        if (spawnPoints.Length == 0)
        {
            Debug.Log("No Spawn Points Found!");
        }

              if(state == stateSpawn.WAITING) // Check if enemy is still alive
        {
            if(!EnemyisAlive()) //Begin a new round
            {
                WaveComplete();
            }
            else
            {
                return;
            }
        }
        
        if (waveCountdown <= 0) // Checks if the spawner is spawning
        {
            // Spawn the wave
            if (state != stateSpawn.SPAWNING)
            {
                StartCoroutine( SpawnWave( waves[ nextWave]));
            }
        }
        else
        { 
            waveCountdown -= Time.deltaTime; // Subract until it hits 0
        }

       
    }
    void Update()
    {   
        if(state == stateSpawn.WAITING) // Check if enemy is still alive
        {
            if(!EnemyisAlive()) //Begin a new round
            {
                WaveComplete();
            }
            else
            {
                return;
            }
        }
        
        if (waveCountdown <= 0) // Checks if the spawner is spawning
        {
            // Spawn the wave
            if (state != stateSpawn.SPAWNING)
            {
                StartCoroutine( SpawnWave( waves[ nextWave]));
            }
        }
        else
        { 
            waveCountdown -= Time.deltaTime; // Subract until it hits 0
        }

        if(state==stateSpawn.FINISHED)
        {
            return;
        }
    }

    void WaveComplete()
    {
        Debug.Log("Wave Completed!");

        state = stateSpawn.COUNTING;
        waveCountdown = timeBetweenWave;

        if(nextWave + 1 > waves.Length - 1)
        {
            state=stateSpawn.FINISHED;
            Debug.Log("Game Over!");
        }
        else
        {
            nextWave++;
        }
        
    }

    bool EnemyisAlive() // Check if enemy is still alive
    {   
        searchCD -= Time.deltaTime;
        if (searchCD <= 0f)
        {
            searchCD = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave (Wave Ewave)
    {
        //Spawns the enemy
        Debug.Log("Spawning wave: " + Ewave.name);
        state = stateSpawn.SPAWNING;
        
        for (int i = 0; i < Ewave.count; i++) // Amount Enemy
        {
            SpawnEnemy (Ewave.enemy[Random.Range(0,Ewave.enemy.Length)]);
            yield return new WaitForSeconds( 1f/Ewave.rate);
        }
        
        state = stateSpawn.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform Fenemy)
    {
        
        Debug.Log("Spawning Enemy: " + Fenemy.name);
        Transform enemySP = spawnPoints[ Random.Range (0, spawnPoints.Length)];
        Instantiate( Fenemy, enemySP.position, enemySP.rotation);
    }
}
