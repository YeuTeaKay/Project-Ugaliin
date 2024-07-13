using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using SimpleAudioManager;

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
    public GameObject settingsUI;

    public GameObject tutorialMenu;


    public void Awake()
    {
        MainMenuUI();
        Manager.instance.PlaySong(0);
    }

    private void Start()
    {
        if (!DataPersistenceManager.instance.HasGameData())
        {
            continueGameButton.interactable = false;
        }

        
    }
    public void SelectBoy()
    {
        DataPersistenceManager.instance.NewGame();
        selectedCharacterPrefab = boyCharacter;
        Debug.Log("Selected Gender: Boy");
        DataPersistenceManager.instance.GetGameData().playerGender = "Boy";

        LoadNextScene();
    }
    public void SelectGirl()
    {
        DataPersistenceManager.instance.NewGame();
        selectedCharacterPrefab = girlCharacter;
        DataPersistenceManager.instance.GetGameData().playerGender = "Girl";
        Debug.Log("Selected Gender: Girl");

        LoadNextScene();
    }

    public void OnNewGameClicked()
    {
        
        TutorialMenu();
    }

    public void TutorialMenu()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
        settingsUI.SetActive(false);        
        characterSelection.SetActive(false);
    }

    public void SettingsMenu()
    {

        settingsUI.SetActive(true);
        mainMenu.SetActive(false);
        characterSelection.SetActive(false);
        tutorialMenu.SetActive(false);
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
        tutorialMenu.SetActive(false);
        characterSelection.SetActive(true);
        mainMenu.SetActive(false);
        settingsUI.SetActive(false);
        
    }

    private void LoadNextScene()
    {
        PlayerCharacterSpawnManager.selectedCharacterPrefab = selectedCharacterPrefab;
        DataPersistenceManager.instance.SaveGame();
        SceneManager.LoadSceneAsync("Movement Test");
    }

    public void MainMenuUI()
    {
        mainMenu.SetActive(true);
        characterSelection.SetActive(false);
        settingsUI.SetActive(false);
        tutorialMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogWarning("Game Closed");
    }
}
