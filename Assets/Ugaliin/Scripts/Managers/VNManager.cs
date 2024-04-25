using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Ink.Runtime;
using Ink.UnityIntegration;


public class VNManager : MonoBehaviour
{

    [Header("Parameters")]
    [SerializeField] private float typingSpeed = 0.02f;

    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalsInkFile;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private GameObject dialogueBackground;

    [SerializeField] private GameObject continueButton;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Animator portraitAnimator;
    private Animator LayoutChanger;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public bool dialogueIsPlaying { get; private set; }
    private Story currentStory;
    private bool canContinueToNextLine = false;
    private Coroutine displayCoroutine;
    private static VNManager instance;
    private const string SPEAKER_TAG = "speaker";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";

    private DialogueVAR dialogueVAR;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;
        
        dialogueVAR = new DialogueVAR(globalsInkFile.filePath);
    }

    public static VNManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        dialogueBackground.SetActive(false);

        LayoutChanger = dialogueBox.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }
    }

    private void FixedUpdate()
    {
        if (!dialogueIsPlaying)
        {
            return;
        }

        if (canContinueToNextLine && currentStory.currentChoices.Count == 0 && InputManager.GetInstance().GetContinuePressed())
        {
            ContinueStory();
        }
    }


    public void EnterVNMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);
        dialogueBackground.SetActive(true);

        dialogueVAR.StartListening(currentStory);

        
        speakerName.text = "Blank";
        portraitAnimator.Play("Default");
        LayoutChanger.Play("Layout Default");
        
        ContinueStory();
    }

    

    private IEnumerator ExitVNMode()
    {
        yield return new WaitForSeconds(1f);

        dialogueVAR.StopListening(currentStory);


        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        dialogueBackground.SetActive(false);
        dialogueText.text = "";
    }

    

    private IEnumerator DisplayDialogue(string line)
    {
        dialogueText.text = "";

        continueButton.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;
        bool isAddingRichTextTag = false;

        foreach (char letter in line.ToCharArray())
        {
            if(InputManager.GetInstance().GetContinuePressed())
            {
                dialogueText.text = line;
                break;
            }

            if (letter == '<' || isAddingRichTextTag) 
            {
                isAddingRichTextTag = true;
                dialogueText.text += letter;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else 
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }
        }

        continueButton.SetActive(true);

        DisplayChoices();

        canContinueToNextLine = true;
    }
    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {

            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }
            displayCoroutine = StartCoroutine(DisplayDialogue(currentStory.Continue()));
            

            HandleTags(currentStory.currentTags);
        }
        else
        {
            StartCoroutine(ExitVNMode());
        }
    }

    private void HandleTags(List<string> currentTags)
    {
        foreach (string tag in currentTags)
        {
            string[] splitTag = tag.Split(':');

            if (splitTag.Length != 2)
            {
                Debug.LogError("Tag could not be properly parsed: " + tag);
            }

            string tagKey = splitTag[0].Trim();
            string tagValue = splitTag[1].Trim();

            switch (tagKey)
            {
                case SPEAKER_TAG:
                    speakerName.text = tagValue;
                    break;

                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    break;

                case LAYOUT_TAG:
                    LayoutChanger.Play(tagValue);
                    break;

                default:
                Debug.LogWarning("Tag came in but was not recoginzed: " + tag);
                break;

            }
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if(currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can display. Number of choices: " 
                + currentChoices.Count);
        }

        int i = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[i].gameObject.SetActive(true);
            choicesText[i].text = choice.text;
            i++;
        }
        
        for(int j = i; j < choices.Length; j++)
        {
            choices[j].gameObject.SetActive(false);
        }
        
        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }

    public void MakeChoice(int choiceIndex)
    {   
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            InputManager.GetInstance().RegisterContinuePressed();
            ContinueStory();
        }
        
    }
}
