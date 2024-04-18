using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Ink.Runtime;

public class VNManager : MonoBehaviour
{

    [Header("Dialogue UI")]

    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TextMeshProUGUI dialogueText;

    public bool dialogueIsPlaying { get; private set; }
    private Story currentStory;
    private static VNManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
    }

    public static VNManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (InputManager.GetInstance().GetContinuePressed())
        {
            ContinueStory();
        }
    }


    public void EnterVNMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitVNMode()
    {
        yield return new WaitForSeconds(1f);
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        dialogueText.text = "";
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            dialogueText.text = currentStory.Continue();
        }
        else
        {
            StartCoroutine(ExitVNMode());
        }
    }


}
