using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private static bool isFirstSceneLoad = true;

    void Awake()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDestroy()
    {
        // Unsubscribe from the sceneLoaded event to avoid memory leaks
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (isFirstSceneLoad)
        {
            // Skip activation for the first scene load
            //isFirstSceneLoad = false;
            return;
        }

        // Activate all children of this GameObject
        //foreach (Transform child in transform)
        {
           // child.gameObject.SetActive(true);
        }
    }
}
