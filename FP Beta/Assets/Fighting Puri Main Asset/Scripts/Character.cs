using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "Base/Character", order = 1)]

public class Character: ScriptableObject {

    public new string name;
    public string description;

    public Sprite artwork;

    public int hp;
    public int sp;
    public int agility;
    public int luck;
    public int strength;
    public int intelligence;

    
}



