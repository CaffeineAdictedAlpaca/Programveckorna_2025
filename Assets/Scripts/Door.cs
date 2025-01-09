using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    [SerializeField] string nextScene;
    FadeScript fade;

    private void Start()
    {
        fade = GameObject.FindAnyObjectByType<FadeScript>();
    }
    public virtual void OpenDoor()
    {
        fade.StartFade();
        //SceneManager.LoadScene(nextScene);
    }
}
