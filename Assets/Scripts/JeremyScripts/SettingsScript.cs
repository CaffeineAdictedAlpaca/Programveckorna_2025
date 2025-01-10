using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsScript : MonoBehaviour
{
    public void FullscreenMode()
    {
        Screen.fullScreen = !Screen.fullScreen; // Toggle fullscreen mode
        print("Changed screenmode");
    }


}
