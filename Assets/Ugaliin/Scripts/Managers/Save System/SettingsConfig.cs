using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SettingsConfig
{
    public float voiceVolume;
    public float ostVolume;
    public int resolutionIndex;

    public SettingsConfig()
    {
        voiceVolume = 1.0f;
        ostVolume = 1.0f;
        resolutionIndex = 0;
    }
}
