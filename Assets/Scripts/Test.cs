using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    [Tooltip("List of scene names to scramble. Ensure all scenes are added to the Build Settings.")]
    public List<string> sceneNames = new List<string>();

    [Tooltip("Indices of scenes in the list that should not be scrambled.")]
    public List<int> fixedIndices = new List<int>();

    public List<string> scrambledScenes;

    void Start()
    {
        // Scramble the scene list while preserving fixed indices.
        scrambledScenes = ScrambleScenes(sceneNames, fixedIndices);

        if (scrambledScenes.Count > 0)
        {

        }
        else
        {
            Debug.LogError("Scene list is empty or invalid.");
        }
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene(scrambledScenes[0]);
    }

    private List<string> ScrambleScenes(List<string> scenes, List<int> fixedIndices)
    {
        // Create a copy of the list to avoid modifying the original.
        List<string> scrambled = new List<string>(scenes);

        // Create a list of indices that can be scrambled.
        List<int> scrambleIndices = new List<int>();
        for (int i = 0; i < scenes.Count; i++)
        {
            if (!fixedIndices.Contains(i))
            {
                scrambleIndices.Add(i);
            }
        }

        // Shuffle the indices that can be scrambled.
        for (int i = 0; i < scrambleIndices.Count; i++)
        {
            int randomIndex = Random.Range(i, scrambleIndices.Count);

            // Swap the scenes at the scrambled indices.
            int tempIndex = scrambleIndices[i];
            scrambleIndices[i] = scrambleIndices[randomIndex];
            scrambleIndices[randomIndex] = tempIndex;

            string tempScene = scrambled[scrambleIndices[i]];
            scrambled[scrambleIndices[i]] = scrambled[scrambleIndices[randomIndex]];
            scrambled[scrambleIndices[randomIndex]] = tempScene;
        }

        return scrambled;
    }
}
