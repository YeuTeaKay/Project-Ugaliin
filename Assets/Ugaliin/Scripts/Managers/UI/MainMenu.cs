using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : Menu 
{
    [Header("Buttons")]
    [SerializeField] private Button continueGameButton;

    [Header("Character Selection")]
    public GameObject boyCharacter;
    public GameObject girlCharacter;
    private GameObject selectedCharacterPrefab;

    [Header("MainMenu UI")]
    public GameObject mainMenu;
    public GameObject characterSelection;


    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }
    }
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
        GameData loadedData = DataPersistenceManager.instance.GetGameData();

        if (loadedData.playerGender == "Boy")
        {
            selectedCharacterPrefab = boyCharacter;
        }
        else if (loadedData.playerGender == "Girl")
        {
            selectedCharacterPrefab = girlCharacter;
        }
        else
        {
            Debug.LogError("No valid gender found in saved data.");
            return;
        }

        PlayerCharacterSpawnManager.selectedCharacterPrefab = selectedCharacterPrefab;
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
