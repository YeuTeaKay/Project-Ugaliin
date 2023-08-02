using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform playerPrefab;
    [SerializeField] private Transform enemyPrefab;

    

    private void Awake() {
        SpawnCharacter(true);
        SpawnCharacter(false);
    }

    private void  SpawnCharacter (bool isPlayerTeam)
    {
        Vector3 position;
        if (isPlayerTeam)
        {
            position = new Vector3(0, 0, 30);
        }
        else
        {
            position = new Vector3(+55, 0, 30);
            playerPrefab.localScale = new Vector3(-43, 43, 43);
        }
        Instantiate(playerPrefab, position, Quaternion.identity);
    }    

    
}
