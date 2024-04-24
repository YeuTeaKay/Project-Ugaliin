using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
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
        SceneManager.LoadScene("OverWorldUgaliin");
    }

    public void Settings()
    {

    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogWarning("Game Closed");
    }


    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
