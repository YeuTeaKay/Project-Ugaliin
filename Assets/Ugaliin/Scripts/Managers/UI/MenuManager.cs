using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inventoryBackpack;
    [SerializeField] private GameObject inventoryBar;
    [SerializeField] private GameObject settingsUI;
    [SerializeField] private GameObject controlTips;

    
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

    private void Start()
    {
        pauseMenu.SetActive(false);
        inventoryBar.SetActive(true);
        inventoryBackpack.SetActive(false);
        settingsUI.SetActive(false);
        controlTips.SetActive(true);
    }

    public void PauseMenu()
    {
        PauseManager.GetInstance().Pause();
        pauseMenu.SetActive(true);
        inventoryBar.SetActive(false);
        inventoryBackpack.SetActive(false);
        settingsUI.SetActive(false);
        controlTips.SetActive(false);
    }

    public void BackPack()
    {   
        PauseManager.GetInstance().Pause();
        pauseMenu.SetActive(false);
        inventoryBar.SetActive(false);
        inventoryBackpack.SetActive(true);
        settingsUI.SetActive(false);
        controlTips.SetActive(false);
    }

    public void SettingsMenu()
    {
        settingsUI.SetActive(true);
        pauseMenu.SetActive(false);
        inventoryBar.SetActive(false);
        inventoryBackpack.SetActive(false);
    }

    public void UnpauseMenu()
    {
        PauseManager.GetInstance().Unpause();
        pauseMenu.SetActive(false);
        inventoryBar.SetActive(true);
        inventoryBackpack.SetActive(false);
        settingsUI.SetActive(false);
        controlTips.SetActive(true);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.LogWarning("Game Closed");
    }
    
}
