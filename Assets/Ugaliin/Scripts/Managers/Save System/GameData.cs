using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    public int playerProgress;
    public List<string> inventoryItemNames;
    public Vector3 playerPosition;


    public GameData()
    {
        this.playerProgress = 0;
        this.inventoryItemNames = new List<string>();
        this.playerPosition = new Vector3(0, 0, 0);


    }
}

