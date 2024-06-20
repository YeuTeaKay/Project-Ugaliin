using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterSpawnManager : MonoBehaviour
{
    public static GameObject selectedCharacterPrefab;
    [SerializeField] private Transform SpecialSpawnPoint;
    private static PlayerCharacterSpawnManager instance;



    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
            Destroy(gameObject);
        }
        instance = this;

    }

    private void Start()
    {
        SpawnCharacter();
    }

    private void SpawnCharacter()
    {
       if (selectedCharacterPrefab != null)
        {
            Instantiate(selectedCharacterPrefab, SpecialSpawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Selected character prefab is not set.");
        }
    }

}
