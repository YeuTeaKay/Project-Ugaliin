using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNM : NetworkManager
{
    public GameObject clientPrefab; // Prefab for clients
    public GameObject hostPrefab;   // Prefab for host

    public override void OnStartServer()
    {
        spawnPrefabs.Clear(); // Clear default spawn prefabs
        spawnPrefabs.Add(clientPrefab); // Add client prefab to spawn list

        base.OnStartServer();
    }

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        GameObject playerPrefab = hostPrefab; // Use host prefab by default

        // Check if the player is the host
        if (conn.connectionId == 0)
        {
            playerPrefab = hostPrefab;
        }
        else
        {
            playerPrefab = clientPrefab;
        }

        GameObject player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
        NetworkServer.AddPlayerForConnection(conn, player);
    }
}
