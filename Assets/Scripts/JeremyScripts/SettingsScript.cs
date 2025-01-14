using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    private Resolution[] availableResolutions;

    public void FullscreenMode()
    {
        // Toggle between fullscreen and windowed mode
        Screen.fullScreen = !Screen.fullScreen;
        print("Changed screen mode");
    }

    public void SetBorderlessMode()
    {
        // Set screen mode to borderless window
        Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        Screen.fullScreen = true;
        print("Set screen mode to borderless");
    }

    public void SetWindowedMode()
    {
        // Set screen mode to windowed
        Screen.fullScreenMode = FullScreenMode.Windowed;
        Screen.fullScreen = false;
        print("Set screen mode to windowed");
    }

    public void SetExclusiveFullscreen()
    {
        // Set screen mode to exclusive fullscreen
        Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        Screen.fullScreen = true;
        print("Set screen mode to exclusive fullscreen");
    }

    public void ChangeScreenMode(int mode)
    {
        switch (mode)
        {
            case 0: // Borderless
                SetBorderlessMode();
                break;
            case 1: // Windowed
                SetWindowedMode();
                break;
            case 2: // Exclusive Fullscreen
                SetExclusiveFullscreen();
                break;
        }
    }

    public void SetResolution(int width, int height, bool isFullscreen)
    {
        // Set resolution with provided width, height, and fullscreen state
        Screen.SetResolution(width, height, isFullscreen);
        print($"Resolution changed to: {width}x{height}, Fullscreen: {isFullscreen}");
    }

    // This is the final version of SetResolutionByIndex, combining both.
    public void SetResolutionByIndex(int index)
    {
        if (index >= 0 && index < availableResolutions.Length)
        {
            Resolution selectedResolution = availableResolutions[index];
            Screen.SetResolution(selectedResolution.width, selectedResolution.height, Screen.fullScreenMode);
            Debug.Log($"Resolution set to: {selectedResolution.width}x{selectedResolution.height} @ {selectedResolution.refreshRateRatio.numerator / selectedResolution.refreshRateRatio.denominator}Hz");
        }
        else
        {
            Debug.Log("Invalid resolution index");
        }
    }

    private void Start()
    {
        // Get available resolutions
        availableResolutions = Screen.resolutions;

        // Populate the dropdown
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        foreach (Resolution resolution in availableResolutions)
        {
            // Calculate refresh rate with explicit cast
            int refreshRate = (int)(resolution.refreshRateRatio.numerator / resolution.refreshRateRatio.denominator);
            options.Add($"{resolution.width} x {resolution.height} @ {refreshRate}Hz");
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = GetCurrentResolutionIndex();
        resolutionDropdown.RefreshShownValue();

        // Add listener for resolution changes
        resolutionDropdown.onValueChanged.AddListener(SetResolutionByIndex);
    }

    private int GetCurrentResolutionIndex()
    {
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            if (Screen.currentResolution.width == availableResolutions[i].width &&
                Screen.currentResolution.height == availableResolutions[i].height)
            {
                return i;
            }
        }
        return 0; // Default to the first resolution
    }
}

