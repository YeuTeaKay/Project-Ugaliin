using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class TurnBasedSystem : MonoBehaviour
{
    public bool isNextScene = true;
    public string sceneName;

    [SerializeField]
    public SceneInfo sceneInfo;
    

    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    Unit playerUnit;
    Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    Animator anim;

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
        anim = playerGO.GetComponentInChildren  <Animator>(true);


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
        anim.SetInteger("State", 1);

        yield return new WaitForSeconds(3f);
    
        if(isDead)
        {
            state = BattleState.WON;
            enemyHUD.SetHP(enemyUnit.currentHP = 0);
            EndBattle();
        }
        else
        {

            anim.SetInteger("State", 0);
    
            state = BattleState.ENEMYTURN;
            
            enemyHUD.SetHP(enemyUnit.currentHP);

            Debug.Log("You deal " + playerUnit.damage + " damage!");
            yield return new WaitForSeconds(3f);
            StartCoroutine(EnemyTurn());

        }
    }


    IEnumerator PlayerHeal()
    {
        playerUnit.Heal(10);

        playerHUD.SetHP(playerUnit.currentHP);
        Debug.Log("You have eaten a kwek kwek!");

        yield return new WaitForSeconds(5f);
        
        state = BattleState.ENEMYTURN;
        StartCoroutine(EnemyTurn());
    }

    IEnumerator PlayerDefend()
    {
        bool isDead = playerUnit.DamageReductionTaken(enemyUnit.damage);
        
        playerHUD.SetHP(playerUnit.currentHP);
        anim.SetInteger("State", 2);

        yield return new WaitForSeconds(5f);
        

        if(isDead)
        {   
            
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            anim.SetInteger("State", 0);
            state = BattleState.PLAYERTURN;
            Debug.Log("You have Defeneded an attack");
            PlayerTurn();
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
            Debug.Log("You have been dealed " + enemyUnit.damage + " damage!");
            PlayerTurn();
        }

    }   

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            Debug.Log("Player have won!");
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }
        else if (state == BattleState.LOST)
        {
            Debug.Log("Player have Lost!");
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
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

    public void OnDefendButton()
    {
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerDefend());
    }

    public void OnHealButton()
    {
        if (state != BattleState.PLAYERTURN)
        return;

        StartCoroutine(PlayerHeal());
    }

    

    
}
