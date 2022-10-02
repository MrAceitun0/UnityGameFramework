using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Collections.Generic;

public class MenuManagerScript : MonoBehaviour
{
    private const string VoumeReference = "volume";
    public AudioMixer masterAudioMixer;

    Resolution[] availableResolutions;
    public Dropdown resolutionDropdown;

    private void Start()
    {
        availableResolutions = Screen.resolutions;
        List<string> availableResolutionsDisplay = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < availableResolutions.Length; i++)
        {
            availableResolutionsDisplay.Add(availableResolutions[i].width + " x " + availableResolutions[i].height);
            if(availableResolutions[i].width == Screen.currentResolution.width 
                && availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.ClearOptions();
        resolutionDropdown.AddOptions(availableResolutionsDisplay);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void loadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void setVolume(float volume)
    {
        masterAudioMixer.SetFloat(VoumeReference, volume);
    }

    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void setResolution(int resolutionIndex)
    {
        Screen.SetResolution(availableResolutions[resolutionIndex].width, availableResolutions[resolutionIndex].height, Screen.fullScreen);
    }
}