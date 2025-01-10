using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoomTracker : MonoBehaviour
{
    [SerializeField]
    private List<string> scenesToShuffle = new List<string>(); // List of scene names to shuffle
    int nextScene;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        if (scenesToShuffle.Count == 0)
        {
            Debug.LogWarning("No scenes added to the list!");
            return;
        }

        // Ensure the last scene is always the last
        string lastScene = scenesToShuffle[scenesToShuffle.Count - 1];
        scenesToShuffle.RemoveAt(scenesToShuffle.Count - 1);

        // Shuffle the rest of the list
        ShuffleScenes();

        // Re-add the last scene at the end of the list
        scenesToShuffle.Add(lastScene);
    }

    // Shuffle the list using the Fisher-Yates algorithm
    private void ShuffleScenes()
    {
        for (int i = scenesToShuffle.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);
            string temp = scenesToShuffle[i];
            scenesToShuffle[i] = scenesToShuffle[randomIndex];
            scenesToShuffle[randomIndex] = temp;
        }

        Debug.Log("Scenes shuffled! Order:");
        foreach (var scene in scenesToShuffle)
        {
            Debug.Log(scene);
        }
    }

    // Load the first scene in the shuffled list
    public void LoadNextScene()
    {
        string firstScene = scenesToShuffle[nextScene];
        Debug.Log("Loading scene: " + firstScene);
        SceneManager.LoadScene(firstScene);
        nextScene++;
    }
}