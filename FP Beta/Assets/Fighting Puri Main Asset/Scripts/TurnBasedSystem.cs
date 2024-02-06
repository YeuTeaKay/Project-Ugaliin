using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

public enum BattleState { START, PLAYER1TURN, PLAYER2TURN, PLAYER1WON, PLAYER2WON }

public class TurnBasedSystem : MonoBehaviour
{
    public bool isNextScene = true;
    public string sceneName;

    [SerializeField]
    public SceneInfo sceneInfo;
    

    public GameObject player1Prefab, player2Prefab;

    Unit player1Unit, player2Unit;

    public BattleHUD player1HUD, player2HUD;


    Animator anim;

    private AudioSource  audioSource;
    private AudioManager audioManager;

    public BattleState state;
    // Start is called before the first frame update

    void Awake() {
        audioSource = GetComponent<AudioSource>();
        audioManager = AudioManager.Instance;
    }

    void Start()
    {
        
        state = BattleState.START;
        
		StartCoroutine(SetupBattle());
        
    }

    // Update is called once per frame
    IEnumerator SetupBattle()
    {
        GameObject player1GO = Instantiate(player1Prefab);
        player1Unit = player1GO.GetComponent<Unit>();
        anim = player1GO.GetComponentInChildren<Animator>(true);


        GameObject player2GO = Instantiate(player2Prefab);
        player2Unit = player2GO.GetComponent<Unit>();

        player1HUD.SetHUD(player1Unit);
        player2HUD.SetHUD(player2Unit);

        yield return new WaitForSeconds(2f);
        state = BattleState.PLAYER1TURN;
        Player1Turn();
    }

    IEnumerator Player1Attack()
    {
        bool isDead = player2Unit.TakeDamage(player1Unit.damage);
        
        player2HUD.SetHP(player2Unit.currentHP);
        Debug.Log("The attack is successful");
    
        anim.SetInteger("State", 1);
        
        yield return new WaitForSeconds(2.5f);
        audioManager.PlaySound("Punch");

    
        if(isDead)
        {
            state = BattleState.PLAYER1WON;
            player2HUD.SetHP(player2Unit.currentHP = 0);
            EndBattle();
        }
        else
        {
            

            anim.SetInteger("State", 0);
    
            state = BattleState.PLAYER2TURN;
            
            player2HUD.SetHP(player2Unit.currentHP);

            Debug.Log("You deal " + player1Unit.damage + " damage!");
            yield return new WaitForSeconds(5f);
            Player2Turn();

        }
    }

    IEnumerator Player2Attack()
    {
        bool isDead = player1Unit.TakeDamage(player2Unit.damage);
        
        player1HUD.SetHP(player1Unit.currentHP);
        Debug.Log("The attack is successful");
    
        anim.SetInteger("State", 1);
        
        yield return new WaitForSeconds(2.5f);
        audioManager.PlaySound("Punch");

    
        if(isDead)
        {
            state = BattleState.PLAYER2WON;
            player1HUD.SetHP(player1Unit.currentHP = 0);
            EndBattle();
        }
        else
        {
            

            anim.SetInteger("State", 0);
    
            state = BattleState.PLAYER1TURN;
            
            player1HUD.SetHP(player1Unit.currentHP);

            Debug.Log("You deal " + player2Unit.damage + " damage!");
            yield return new WaitForSeconds(5f);
            Player1Turn();

        }
    }


    IEnumerator Player1Heal()
    {
        player1Unit.Heal(10);
        audioManager.PlaySound("Heal");

        player1HUD.SetHP(player1Unit.currentHP);
        Debug.Log("You have eaten a kwek kwek!");

        yield return new WaitForSeconds(5f);
        
        state = BattleState.PLAYER2TURN;
        Player2Turn();
    }

    IEnumerator Player2Heal()
    {
        player2Unit.Heal(10);
        audioManager.PlaySound("Heal");

        player2HUD.SetHP(player2Unit.currentHP);
        Debug.Log("You have eaten a kwek kwek!");

        yield return new WaitForSeconds(5f);
        
        state = BattleState.PLAYER1TURN;
        Player1Turn();
    }



    void EndBattle()
    {
        if (state == BattleState.PLAYER1WON)
        {
            Debug.Log("Player 1 have won!");
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }
        else if (state == BattleState.PLAYER2WON)
        {
            Debug.Log("Player 2 have Lost!");
            sceneInfo.isNextScene = isNextScene;
            SceneManager.LoadScene(sceneName);
        }
    }

    void Player1Turn()
    {
        Debug.Log("Player 1 Turn");
    }

    void Player2Turn()
    {
        Debug.Log("Player 2 Turn");
    }


    public void OnAttackButton()
    {
        if (state == BattleState.PLAYER1TURN)
        {
            StartCoroutine(Player1Attack());
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            StartCoroutine(Player2Attack());
        }
    }

    public void OnHealButton()
    {
        if (state == BattleState.PLAYER1TURN)
        {
            StartCoroutine(Player1Heal());
        }
        else if (state == BattleState.PLAYER2TURN)
        {
            StartCoroutine(Player2Heal());
        }
    }  
}
