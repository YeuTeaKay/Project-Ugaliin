using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class SettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Slider volumeVoiceSlider;
    public Slider volumeOSTSlider;
    public Slider volumeSFXSlider;

    private List<Resolution> availableResolutions;

    void Start()
    {
        // Define the specific resolutions you want to support
        availableResolutions = new List<Resolution>
        {
            new Resolution { width = 1280, height = 720, refreshRateRatio = new RefreshRate { numerator = 60, denominator = 1 } },
            new Resolution { width = 1920, height = 1080, refreshRateRatio = new RefreshRate { numerator = 60, denominator = 1 } },
            new Resolution { width = 3840, height = 2160, refreshRateRatio = new RefreshRate { numerator = 60, denominator = 1 } }
        };

        List<string> options = new List<string>();

        // Clear any existing options in the dropdown
        resolutionDropdown.ClearOptions();

        // Create a list of options formatted as "Width x Height"
        int currentResolutionIndex = 0;
        for (int i = 0; i < availableResolutions.Count; i++)
        {
            string option = $"{availableResolutions[i].width} x {availableResolutions[i].height}";
            options.Add(option);

            // Check if this resolution is the currently set resolution
            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        // Add the options to the dropdown and set the current resolution as the default selected option
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // Add a listener to handle when the user selects a new resolution
        resolutionDropdown.onValueChanged.AddListener(delegate { SetResolution(resolutionDropdown.value); });

        volumeVoiceSlider.onValueChanged.AddListener(SetVoiceVolume);
        volumeVoiceSlider.value = AudioListener.volume;

        volumeOSTSlider.onValueChanged.AddListener(SetOSTVolume);
        volumeOSTSlider.value = SimpleAudioManager.Manager.instance.maxVolume;

        volumeSFXSlider.onValueChanged.AddListener(SetSFXVolume);
        volumeVoiceSlider.value = AudioListener.volume;

        // Automatically set the resolution to 1920x1080
        SetResolutionTo1920x1080();
    }

    // This method is called whenever the user selects a new resolution from the dropdown
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = availableResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
    }

    // This method sets the resolution to 1920x1080
    private void SetResolutionTo1920x1080()
    {
        foreach (var resolution in availableResolutions)
        {
            if (resolution.width == 1920 && resolution.height == 1080)
            {
                Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreenMode, resolution.refreshRateRatio);
                resolutionDropdown.value = availableResolutions.IndexOf(resolution);
                resolutionDropdown.RefreshShownValue();
                break;
            }
        }
    }

    public void SetFullscreen()
    {
        Screen.fullScreenMode = Screen.fullScreenMode == FullScreenMode.FullScreenWindow ? FullScreenMode.Windowed : FullScreenMode.FullScreenWindow;
    }
    
    public void SetVoiceVolume(float volume)
    {
        // Set the global volume
        VNManager vnManager = VNManager.GetInstance();
        if (vnManager != null)
        {
            vnManager.SetVoiceVolume(volume);
        }
    }

    public void SetOSTVolume(float volume)
    {
        SimpleAudioManager.Manager.instance.SetVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        VNManager vnManager = VNManager.GetInstance();
        if (vnManager != null)
        {
            vnManager.SetSFXVolume(volume);
        }
    }
}
