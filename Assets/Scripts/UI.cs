using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    // The name of the child GameObject to activate
    [SerializeField]
    private string childNameToActivate;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Find the child by name
        Transform childTransform = transform.Find(childNameToActivate);

        if (childTransform != null)
        {
            // Activate the child GameObject
            childTransform.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Child GameObject with name '{childNameToActivate}' not found under '{gameObject.name}'.");
        }
    }
}
