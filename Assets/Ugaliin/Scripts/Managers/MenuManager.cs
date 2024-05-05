using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject boyCharacter;
    public GameObject girlCharacter;
    private GameObject selectedCharacterPrefab;

    
    
    
    private void FixedUpdate()
    {
        if (InputManager.GetInstance().GetPausePressed())
        {   
            if (!PauseManager.GetInstance().isPaused)
            {
                PauseMenu();
            }
        }
        else if (InputManager.GetInstance().GetUnpauseButtonPressed())
        {
            if (PauseManager.GetInstance().isPaused)
            {
                UnpauseMenu();
            }
        }
    }
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

    public void PauseMenu()
    {
        PauseManager.GetInstance().Pause();

    }

    public void UnpauseMenu()
    {
        PauseManager.GetInstance().Unpause();
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
