using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class TurnBasedSystem : MonoBehaviour
{

    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;
    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
		SetupBattle();
    }

    // Update is called once per frame
    void SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab);
        playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
    }
}
