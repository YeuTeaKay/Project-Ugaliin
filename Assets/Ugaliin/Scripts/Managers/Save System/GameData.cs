using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerProgress;
    public int badChoicesCounter;
    public int goodChoicesCounter;
    public List<string> inventoryItemNames;
    public Vector3 playerPosition;
    public string playerGender;


    public GameData()
    {
        this.playerProgress = 0;
        this.badChoicesCounter = 0;
        this.goodChoicesCounter = 0;
        this.inventoryItemNames = new List<string>();
        this.playerPosition = new Vector3(0, 0, 0);
        this.playerGender = string.Empty;
    }
}

