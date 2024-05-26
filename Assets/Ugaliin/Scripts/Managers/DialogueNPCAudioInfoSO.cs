using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNPCAudioInfoSO", menuName = "Audio/DialogueNPCAudioInfoSO", order = 1)]
public class DialogueNPCAudioInfoSO : ScriptableObject
{
    public string ID;
    public AudioClip[] npcTypingSoundSFXs;

    [Range(1, 5)]
    public int frequencyLevel = 2;
    [Range(-3, 3)]
    public float minPitch = 0.5f;
    public float maxPitch = 3f;
    public bool stopAudioSource;
    
}
