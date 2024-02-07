using UnityEngine;
using Mirror;

public class CustomNetworkManager : NetworkManager
{
    public GameObject clientPlayerPrefab;

    
    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        // Check if the player is the host (server)
        if (conn.connectionId == 0) 
        {
            // Host uses the default player prefab
            base.OnServerAddPlayer(conn);
        }
        else
        {
            // Other players use the clientPlayerPrefab
            GameObject player = Instantiate(clientPlayerPrefab);
            NetworkServer.AddPlayerForConnection(conn, player);
        }
    }

}
