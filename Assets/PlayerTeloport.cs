using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeloport : MonoBehaviour
{
    public Transform teleportDestination;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.position = teleportDestination.position;
        }
    }
}
