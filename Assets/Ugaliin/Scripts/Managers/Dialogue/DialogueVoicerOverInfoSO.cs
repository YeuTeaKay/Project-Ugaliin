using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueVoicerOverInfoSO", menuName = "Audio/DialogueVoicerOverInfoSO", order = 0)]
public class DialogueVoicerOverInfoSO : ScriptableObject 
{
    public string voiceoverID;
    public AudioClip voiceOverAudio;

    public bool stopAudioSource;
}
