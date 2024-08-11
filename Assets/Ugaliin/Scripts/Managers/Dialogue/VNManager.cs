    using System.Collections;
    using System.Collections.Generic;
    using TMPro;
    using UnityEngine;
    using UnityEngine.EventSystems;
    using Ink.Runtime;
    using SimpleAudioManager;

    public class VNManager : MonoBehaviour, IDataPersistance
    {
    //MARK: VNManager Params
    [Header("Parameters")]
    [SerializeField] private float typingSpeed = 0.02f;

    //MARK: Globals Variables
    [Header("Load Globals JSON")]
    [SerializeField] private TextAsset loadGlobalsJSON;

    [Header("Main UI")]
    [SerializeField] private GameObject MainUIPanel;

    //MARK: Dialogue UI Variables
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private Animator dialogueBackground;

    [SerializeField] private GameObject continueButton;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI speakerName;
    [SerializeField] private Animator portraitAnimator;
    private Animator LayoutChanger;

    //MARK: Dialogue Audio & SFX
    [Header("Dialogue Audio & SFX")]
    [SerializeField] private DialogueNPCAudioInfoSO defaultNPCAudioInfo;
    [SerializeField] private DialogueNPCAudioInfoSO[] audioNPCInfos;
    [SerializeField] private DialogueVoicerOverInfoSO defaultVoicerOverInfo;
    [SerializeField] private DialogueVoicerOverInfoSO[] voicerOverInfos;
    [SerializeField] private GameObject voicePrefab;
    private DialogueNPCAudioInfoSO currentNPCAudioInfo;

    private DialogueVoicerOverInfoSO currentVoicerOverInfo;
    private Dictionary<string, DialogueNPCAudioInfoSO> audioNPCInfoDictionary;

    private Dictionary<string, DialogueVoicerOverInfoSO> voicerOverInfoDictionary;
    
    public AudioSource audioSource;

    //MARK: Choice UI Variables
    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;
    public bool dialogueIsPlaying { get; private set; }
    private Story currentStory;
    private bool canContinueToNextLine = false;
    private Coroutine displayCoroutine;
    private static VNManager instance;

    //MARK: Ink Tags
    private const string SPEAKER_TAG = "speaker";
    private const string BACKGROUND_TAG = "background";
    private const string PORTRAIT_TAG = "portrait";
    private const string LAYOUT_TAG = "layout";
    private const string NPC_Tag = "npc";
    private const string VO_Tag = "voiceover";

    private DialogueVAR dialogueVAR;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Input Manager in the scene.");
        }
        instance = this;

        dialogueVAR = new DialogueVAR(loadGlobalsJSON);
        audioSource = this.gameObject.AddComponent<AudioSource>();
        currentNPCAudioInfo = defaultNPCAudioInfo;
    }

    public static VNManager GetInstance()
    {
        return instance;
    }

    private void Start()
    {
        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);
        

        LayoutChanger = dialogueBox.GetComponent<Animator>();

        choicesText = new TextMeshProUGUI[choices.Length];
        int i = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[i] = choice.GetComponentInChildren<TextMeshProUGUI>();
            i++;
        }

        InitializeNPCAudioInfoDictionary();
        InitializeVOAudioInfoDictionary();

        
    }
    
    private void InitializeNPCAudioInfoDictionary() 
    {
        audioNPCInfoDictionary = new Dictionary<string, DialogueNPCAudioInfoSO>();
        audioNPCInfoDictionary.Add(defaultNPCAudioInfo.ID, defaultNPCAudioInfo);
        foreach (DialogueNPCAudioInfoSO audioInfo in audioNPCInfos) 
        {
            audioNPCInfoDictionary.Add(audioInfo.ID, audioInfo);
        }
    }

    private void InitializeVOAudioInfoDictionary()
    {
        voicerOverInfoDictionary = new Dictionary<string, DialogueVoicerOverInfoSO>();
        voicerOverInfoDictionary.Add(defaultVoicerOverInfo.voiceoverID, defaultVoicerOverInfo);
        foreach (DialogueVoicerOverInfoSO audioinfo in voicerOverInfos)
        {
            voicerOverInfoDictionary.Add(audioinfo.voiceoverID, audioinfo);
        }
    }

    private void SetCurrentNPCAudioInfo(string ID) 
    {
        DialogueNPCAudioInfoSO audioInfo = null;
        audioNPCInfoDictionary.TryGetValue(ID, out audioInfo);
        if (audioInfo != null) 
        {
            this.currentNPCAudioInfo = audioInfo;
        }
        else 
        {
            Debug.LogWarning("Failed to find audio info for id: " + ID);
        }
    }

    private void SetCurrentVOAudioInfo(string voiceoverID)
    {
        DialogueVoicerOverInfoSO audioVOInfo = null;
        voicerOverInfoDictionary.TryGetValue(voiceoverID, out audioVOInfo);
        if (audioVOInfo != null)
        {
            this.currentVoicerOverInfo = audioVOInfo;
        }
        else
        {
            Debug.LogWarning("Failed to find the Voice Over audio for id: " + voiceoverID);
        }
    }


    private void Update()
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

    //MARK: Enter Dialogue
    public void EnterVNMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialogueBox.SetActive(true);
        MainUIPanel.SetActive(false);

        dialogueVAR.StartListening(currentStory);

        Manager.instance.PlaySong(1);
        speakerName.text = "Blank";
        dialogueBackground.Play("Background_Default");
        portraitAnimator.Play("Default");
        LayoutChanger.Play("Layout Default");

        ContinueStory();
    }

    //MARK: Exit Dialogue
    private IEnumerator ExitVNMode()
    {
        StopVoiceOverSound();

        yield return new WaitForSeconds(1f);

        dialogueVAR.StopListening(currentStory);
        DataPersistenceManager.instance.SaveGame();

        Manager.instance.StopSong(1);
        Manager.instance.PlaySong(0);

        dialogueIsPlaying = false;
        dialogueBox.SetActive(false);

        MainUIPanel.SetActive(true);
        dialogueText.text = "";
    }

    //MARK: Display Dialogue
    private IEnumerator DisplayDialogue(string line)
    {
        dialogueText.text = line;
        dialogueText.maxVisibleCharacters = 0;

        continueButton.SetActive(false);
        HideChoices();

        canContinueToNextLine = false;
        bool isAddingRichTextTag = false;
         
        PlayVoiceOverSound(currentVoiceClipName);

        foreach (char letter in line.ToCharArray())
        {
            if (InputManager.GetInstance().GetContinuePressed())
            {
                dialogueText.maxVisibleCharacters = line.Length;
                break;
            }

            if (letter == '<' || isAddingRichTextTag)
            {
                isAddingRichTextTag = true;
                if (letter == '>')
                {
                    isAddingRichTextTag = false;
                }
            }
            // if not rich text, add the next letter and wait a small time
            else
            {
                
                PlayNPCSound(dialogueText.maxVisibleCharacters);
                dialogueText.maxVisibleCharacters++;
                yield return new WaitForSeconds(typingSpeed);
            }
        }
        


        continueButton.SetActive(true);

        DisplayChoices();

        canContinueToNextLine = true;
    }

    private void PlayNPCSound(int currentDisplayCharacterCount)
    {   
        AudioClip[] npcTypingSFXs = currentNPCAudioInfo.npcTypingSFXs;
        int frequencyLevel = currentNPCAudioInfo.frequencyLevel;
        float minPitch = currentNPCAudioInfo.minPitch;
        float maxPitch = currentNPCAudioInfo.maxPitch;
        bool stopAudioSource = currentNPCAudioInfo.stopAudioSource;
        float volume = currentNPCAudioInfo.volume;

        if(currentDisplayCharacterCount % frequencyLevel == 0)
        {
            if(stopAudioSource)
            {
                audioSource.Stop();
            }
            int randomIndex = Random.Range(0, npcTypingSFXs.Length);
            AudioClip soundClip = npcTypingSFXs[randomIndex];
    
            audioSource.pitch = Random.Range(minPitch, maxPitch);
            audioSource.PlayOneShot(soundClip, volume); // Use the volume here
        }
    }


    private string currentVoiceClipName = string.Empty;
    private void PlayVoiceOverSound(string voiceClipName)
    {
        AudioClip voiceOverAudioClip = currentVoicerOverInfo.voiceOverAudio;
        bool voiceOverstopAudioSource = currentVoicerOverInfo.stopAudioSource;
    
        if (voiceOverAudioClip != null)
        {
            // Get the AudioSource component from the instantiated prefab
            AudioSource voiceAudioSource = voicePrefab.GetComponent<AudioSource>();

            if (voiceOverstopAudioSource)
            {
                voiceAudioSource.Stop();
            }

            // Set the pitch and play the audio clip
            voiceAudioSource.pitch = 1f;
            voiceAudioSource.PlayOneShot(voiceOverAudioClip);
        }
        else
        {
            Debug.LogWarning("Voice clip not found: " + voiceClipName);
        }
    }

    private void StopVoiceOverSound()
    {
        // Get the AudioSource component from the instantiated prefab
        AudioSource voiceAudioSource = voicePrefab.GetComponent<AudioSource>();
        if (voiceAudioSource.isPlaying)
        {
            voiceAudioSource.Stop();
        }
    }

    public void SetVoiceVolume(float volume)
    {
        if (voicePrefab != null)
        {
            AudioSource voiceAudioSource = voicePrefab.GetComponent<AudioSource>();
            if (voiceAudioSource != null)
            {
                voiceAudioSource.volume = volume;
            }
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (currentNPCAudioInfo != null)
        {
            currentNPCAudioInfo.volume = volume;
        }
    }


    //MARK: Hide Choices
    private void HideChoices()
    {
        foreach (GameObject choiceButton in choices)
        {
            choiceButton.SetActive(false);
        }
    }

    //MARK: Continue Story
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {

            if (displayCoroutine != null)
            {
                StopCoroutine(displayCoroutine);
            }
            string nextLine = currentStory.Continue();
            HandleTags(currentStory.currentTags);
            displayCoroutine = StartCoroutine(DisplayDialogue(nextLine));
            
        }
        else
        {
            StartCoroutine(ExitVNMode());
        }
    }

    //MARK: Handling Ink Tags
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

                case BACKGROUND_TAG:
                    dialogueBackground.Play(tagValue);
                    Debug.Log("Background Animator: " + tagValue);
                    break;
    
                case PORTRAIT_TAG:
                    portraitAnimator.Play(tagValue);
                    Debug.Log("Portrait Animator: " + tagValue);
                    break;

                case LAYOUT_TAG:
                    LayoutChanger.Play(tagValue);
                    Debug.Log("Layout Changer: " + tagValue);
                    break;

                case NPC_Tag:
                    SetCurrentNPCAudioInfo(tagValue);
                    break;
                case VO_Tag:
                    SetCurrentVOAudioInfo(tagValue);
                    currentVoiceClipName = tagValue;
                    break;
                


                default:
                    Debug.LogWarning("Tag came in but was not recoginzed: " + tag);
                    break;

            }
        }
    }

    //MARK: Display Choices
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can display. Number of choices: "
                + currentChoices.Count);
        }

        for (int i = 0; i < choices.Length; i++)
        {
            if (i < currentChoices.Count)
            {
                choices[i].gameObject.SetActive(true);
                choicesText[i].text = currentChoices[i].text;
            }
            else
            {
                choices[i].gameObject.SetActive(false);
            }
        }

        StartCoroutine(SelectFirstChoice());
    }

    //MARK: Player Choice
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        if (currentStory.currentChoices.Count > 0)
        {
            EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
        }
    }

    //MARK: Handle Choice Selection
    public void MakeChoice(int choiceIndex)
    {
        if (canContinueToNextLine)
        {
            currentStory.ChooseChoiceIndex(choiceIndex);
            InputManager.GetInstance().RegisterContinuePressed();
            ContinueStory();
        }

    }

    //MARK: Getting the Ink Variables
    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogueVAR.VAR.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("Ink Variable was found to be null: " + variableName);
        }
        return variableValue;
    }


    public void LoadData(GameData data)
    {
        dialogueVAR.VAR["playerProgress"] = new Ink.Runtime.IntValue(data.playerProgress);
        dialogueVAR.VAR["badChoicesCounter"] = new Ink.Runtime.IntValue(data.badChoicesCounter);
        dialogueVAR.VAR["goodChoicesCounter"] = new Ink.Runtime.IntValue(data.goodChoicesCounter);
        dialogueVAR.VAR["BarangayHallEnd"] = new Ink.Runtime.BoolValue(data.BarangayHallEnd);
        dialogueVAR.VAR["TitaHouseEnd"] = new Ink.Runtime.BoolValue(data.TitaHouseEnd);
        dialogueVAR.VAR["NearbyHouseEnd"] = new Ink.Runtime.BoolValue(data.NearbyHouseEnd);
        dialogueVAR.VAR["EndGame"] = new Ink.Runtime.BoolValue(data.EndGame);
        dialogueVAR.VAR["FiestaEnding"] = new Ink.Runtime.BoolValue(data.FiestaEnding);
        dialogueVAR.VAR["Ending"] = new Ink.Runtime.StringValue(data.Ending);
    }
    
    public void SaveData(GameData data)
    {
        if (dialogueVAR.VAR.ContainsKey("playerProgress"))
        {
            data.playerProgress = (int)((Ink.Runtime.IntValue)dialogueVAR.VAR["playerProgress"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("badChoicesCounter"))
        {
            data.badChoicesCounter = (int)((Ink.Runtime.IntValue)dialogueVAR.VAR["badChoicesCounter"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("goodChoicesCounter"))
        {
            data.goodChoicesCounter = (int)((Ink.Runtime.IntValue)dialogueVAR.VAR["goodChoicesCounter"]).value;
        }
        if (dialogueVAR.VAR.ContainsKey("BarangayHallEnd"))
        {
            data.BarangayHallEnd = (bool)((Ink.Runtime.BoolValue)dialogueVAR.VAR["BarangayHallEnd"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("TitaHouseEnd"))
        {
            data.TitaHouseEnd = (bool)((Ink.Runtime.BoolValue)dialogueVAR.VAR["TitaHouseEnd"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("NearbyHouseEnd"))
        {
            data.NearbyHouseEnd = (bool)((Ink.Runtime.BoolValue)dialogueVAR.VAR["NearbyHouseEnd"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("EndGame"))
        {
            data.EndGame = (bool)((Ink.Runtime.BoolValue)dialogueVAR.VAR["EndGame"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("FiestaEnding"))
        {
            data.FiestaEnding = (bool)((Ink.Runtime.BoolValue)dialogueVAR.VAR["FiestaEnding"]).value;
        }

        if (dialogueVAR.VAR.ContainsKey("Ending"))
        {
            data.Ending = (string)((Ink.Runtime.StringValue)dialogueVAR.VAR["Ending"]).value;
        }



        Debug.Log("Saved playerProgress: " + data.playerProgress);
        Debug.Log("Saved badChoicesCounter: " + data.badChoicesCounter);
        Debug.Log("Saved goodChoicesCounter: " + data.goodChoicesCounter);
    }

    public void SetVariableState(string variableName, Ink.Runtime.Object value)
    {
        dialogueVAR.VAR[variableName] = value;
    }
}
