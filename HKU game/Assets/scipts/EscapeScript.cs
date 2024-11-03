using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeSwitcher : MonoBehaviour
{
    [Header("Settings")]
    public KeyCode switchKey = KeyCode.Space;  // Key to trigger the scene switch, adjustable in Inspector
    public string targetSceneName;             // Name of the target scene, adjustable in Inspector

    void Update()
    {
        // Check if the specified key is pressed
        if (Input.GetKeyDown(switchKey))
        {
            // Ensure the target scene name is valid before switching
            if (!string.IsNullOrEmpty(targetSceneName))
            {
                SceneManager.LoadScene(targetSceneName);
            }
            else
            {
                Debug.LogWarning("Target scene name is not set.");
            }
        }
    }
}
