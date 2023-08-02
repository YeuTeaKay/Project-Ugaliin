using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimHandler : MonoBehaviour
{
    public Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {

    }

    public void AttackMove()
    {
        
        anim.SetInteger("State", 1);
        Debug.Log("Attacked");
        
    }

    public void DefendMove()
    {
        anim.SetInteger("State", 2);
        Debug.Log("Defended");
    }


    
}
