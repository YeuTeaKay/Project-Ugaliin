using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    [Header("Character Selection")]
    public GameObject boyCharacter;
    public GameObject girlCharacter;
    private GameObject selectedCharacterPrefab;

    [Header("MainMenu UI")]
    public GameObject mainMenu;
    public GameObject characterSelection;

    public void SelectBoy()
    {
        selectedCharacterPrefab = boyCharacter;
        Debug.Log("Selected Gender: Boy");
        DataPersistenceManager.instance.GetGameData().playerGender = "Boy";

        LoadNextScene();
    }
    public void SelectGirl()
    {
        selectedCharacterPrefab = girlCharacter;
        DataPersistenceManager.instance.GetGameData().playerGender = "Girl";
        Debug.Log("Selected Gender: Girl");

        LoadNextScene();
    }

    public void OnNewGameClicked()
    {
        DataPersistenceManager.instance.NewGame();
        OnCharacterSelect();
    }

    public void OnLoadGameClicked()
    {
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Movement Test");
    }

    public void OnCharacterSelect()
    {
        characterSelection.SetActive(true);
    }

    private void LoadNextScene()
    {
        PlayerCharacterSpawnManager.selectedCharacterPrefab = selectedCharacterPrefab;
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Movement Test");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogWarning("Game Closed");
    }
}
