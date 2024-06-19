using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerProgress;
    public List<string> inventoryItemNames;


    public GameData()
    {
        this.playerProgress = 0;
        this.inventoryItemNames = new List<string>();

    }
}

