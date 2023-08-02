using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    public int unitLevel;

    public int damage;

    public int maxHP;
    public int currentHP;
    
    public bool TakeDamage(int _dmg)
    {
        currentHP -= _dmg;

        if (currentHP <= 0)
            return true;
        else
            return false;

    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP > maxHP)
            currentHP = maxHP;
    }
    public bool DamageReductionTaken(int dmgRT)
    {
        
        int reducedDamage = dmgRT / 2;
        
        currentHP -= reducedDamage;

        if (currentHP <= 0)
            return true;
        else
            return false;
    }


}
