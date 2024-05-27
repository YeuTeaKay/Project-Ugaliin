using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueVoicerOverInfoSO", menuName = "Audio/DialogueVoicerOverInfoSO", order = 0)]
public class DialogueVoicerOverInfoSO : ScriptableObject 
{
    public string voiceoverID;
    public AudioClip[] voiceOverAudio;

    [Range(1, 5)]
    public int frequencyLevel = 2;
   
    [Range(-3, 3)]
    public float minPitch = 0.5f;
    public float maxPitch = 3f;

    public bool stopAudioSource;
}
