using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject inventoryBackpack;
    [SerializeField] private GameObject inventoryBar;
    
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
    }

    public void PauseMenu()
    {
        PauseManager.GetInstance().Pause();
        pauseMenu.SetActive(true);
        inventoryBar.SetActive(false);
        inventoryBackpack.SetActive(false);
    }

    public void BackPack()
    {   
        PauseManager.GetInstance().Pause();
        pauseMenu.SetActive(false);
        inventoryBar.SetActive(false);
        inventoryBackpack.SetActive(true);
    }

    public void UnpauseMenu()
    {
        PauseManager.GetInstance().Unpause();
        pauseMenu.SetActive(false);
        inventoryBar.SetActive(true);
        inventoryBackpack.SetActive(false);
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
