using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static PauseManager instance;

    public bool isPaused { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static PauseManager GetInstance()
    {
        return instance;
    }

    // Start is called before the first frame update
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;

        InputManager.GetInstance().SwitchActionMap("UI");

    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;

        InputManager.GetInstance().SwitchActionMap("Player");
    }
}
