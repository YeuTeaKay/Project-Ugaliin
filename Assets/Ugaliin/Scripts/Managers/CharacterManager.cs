using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CharacterManager : MonoBehaviour
{
    public GameObject boyCharacter;
    public GameObject girlCharacter;
    private GameObject selectedCharacterPrefab;
    
    public void SelectBoy()
    {
        selectedCharacterPrefab = boyCharacter;
        LoadNextScene();
    }
    public void SelectGirl()
    {
        selectedCharacterPrefab = girlCharacter;
        LoadNextScene();
        
    }

    private void LoadNextScene()
    {
        PlayerCharacterSpawnManager.selectedCharacterPrefab = selectedCharacterPrefab;
        SceneManager.LoadScene("Movement Test");
    }
}
