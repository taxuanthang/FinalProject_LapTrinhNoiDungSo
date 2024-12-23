using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneButtonManager : MonoBehaviour
{
    public Button[] buttons; // Array to store 5 buttons
    public string[] sceneNames; // Array of scene names to load

    void Start()
    {
        // Validate that the number of buttons matches the number of scenes
        if (buttons.Length != sceneNames.Length)
        {
            Debug.LogError("The number of buttons must match the number of scene names.");
            return;
        }

        // Assign onClick listeners to each button
        for (int i = 0; i < buttons.Length; i++)
        {
            int index = i; // Capture the index to avoid closure issues
            buttons[i].onClick.AddListener(() => LoadScene(sceneNames[index]));
        }
    }

    void LoadScene(string sceneName)
    {
        // Load the specified scene
        Debug.Log($"Loading scene: {sceneName}");
        SceneManager.LoadScene(sceneName);
    }
}
