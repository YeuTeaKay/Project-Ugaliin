using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNM : NetworkManager
{
    public GameObject player1Prefab;
    public GameObject player2Prefab;

    public override void OnStartServer()
    {
        spawnPrefabs.Add(player1Prefab);
        spawnPrefabs.Add(player2Prefab);
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject playerPrefabToSpawn = player1Prefab;

        // Check if the connection is from the client
        if (conn.identity.netId == 1)  // You may need to adjust this condition based on your network setup
        {
            playerPrefabToSpawn = player2Prefab;
        }

        GameObject player = Instantiate(playerPrefabToSpawn);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
