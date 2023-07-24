using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private Transform pfCharacter;
    

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
        }
        Instantiate(pfCharacter, position, Quaternion.identity);
    }    

    
}
