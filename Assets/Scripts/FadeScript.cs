using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeUI;
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    public void StartFade()
    {
        StartCoroutine(FadeOut());//Starts fade
    }
    public IEnumerator FadeOut()
    {
        // Fade in (alpha 0 to 1)
        for (float i = 0; i <= 1.02f; i += 0.02f)
        {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
    public void EndFade()
    {
        StartCoroutine(FadeIn());//End fade
    }
    public IEnumerator FadeIn()
    {
        // fade alpha of an imedge to zero
        for (float i = 1; i >= -0.02f; i -= 0.02f)
        {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }
    }
    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This function is called every time a new scene is loaded
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene Loaded: " + scene.name);

        // Call your desired function here
        EndFade();
    }
}
