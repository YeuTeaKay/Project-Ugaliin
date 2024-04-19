using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string sfxName;
    public AudioClip[] soundClips;

    [Range(0f, 1f)]
    public float volume = 1.0f;
    [Range(0f, 1.5f)]
    public float pitch = 1.0f;
    public Vector2 randomVolumeRange = new Vector2(1.0f, 1.0f);
    public Vector2 randomPitchRange = new Vector2(1.0f, 1.0f);

    private AudioSource soundSource;

    public void SetSource(AudioSource source)
    {
        soundSource = source;
        int randomClip = Random.Range(0, soundClips.Length - 1);
        soundSource.clip = soundClips[randomClip];
    }

    public void Play()
    {
        if(soundClips.Length > 1)
        {
            int randomClip = Random.Range(0, soundClips.Length - 1);
            soundSource.clip = soundClips[randomClip];
        }
        soundSource.volume = volume * Random.Range(randomVolumeRange.x, randomVolumeRange.y);
        soundSource.pitch = pitch * Random.Range(randomPitchRange.x, randomPitchRange.y);
        soundSource.Play();
    }
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    
    [SerializeField] Sound[] sfx;


    void Awake(){
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        for(int i = 0; i < sfx.Length; i++)
        {
            GameObject go = new GameObject("Sound_" + i + "_" + sfx[i].sfxName);
            go.transform.SetParent(transform);
            sfx[i].SetSource(go.AddComponent<AudioSource>());
        }
    }

    public void PlaySound (string name)
    {
        for(int i = 0; i < sfx.Length; i++)
        {
            if(sfx[i].sfxName == name)
            {
                sfx[i].Play();
                return;
            }
        }

        Debug.LogWarning("AudioManager: Sound name not found in list: " + name);
    }
}


