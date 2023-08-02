using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class TurnBasedSystem : MonoBehaviour
{

    public string sceneName;
    public bool isNextScene = true;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    public BattleState state;
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
		StartCoroutine(SetupBattle());
    }

    // Update is called once per frame
    IEnumerator SetupBattle()
    {
        GameObject playerGO = Instantiate(playerPrefab);
        playerUnit = playerGO.GetComponent<Unit>();

        GameObject enemyGO = Instantiate(enemyPrefab);
        enemyUnit = enemyGO.GetComponent<Unit>();

        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);
        
        enemyHUD.SetHP(enemyUnit.currentHP);
        Debug.Log("The attack is successful");


        yield return new WaitForSeconds(3f);
    
        if(isDead)
        {
            state = BattleState.WON;
            enemyHUD.SetHP(enemyUnit.currentHP = 0);
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            
            enemyHUD.SetHP(enemyUnit.currentHP);

            Debug.Log("You deal " + playerUnit.damage + " damage!");
            yield return new WaitForSeconds(2f);
            StartCoroutine(EnemyTurn());

           
        }
    }

    IEnumerator EnemyTurn()
    {
        Debug.Log("Enemy turn");

        yield return new WaitForSeconds(1f);

        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
         
        playerHUD.SetHP(playerUnit.currentHP);

        yield return new WaitForSeconds(1f);

        if(isDead)
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }

    }   
    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("Player have won!");
            
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("Player have Lost!");
        }
    }

    void PlayerTurn()
    {
        Debug.Log("Player Turn");
    }


    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerAttack());
    }
}
