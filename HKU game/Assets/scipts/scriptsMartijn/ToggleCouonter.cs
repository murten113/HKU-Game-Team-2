using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToggleCounter : MonoBehaviour
{
    public Toggle[] toggles;  // Array to hold references to the toggles
    private int toggleCount = 0;  // Counter for active toggles

    void Start()
    {
        // Initialize the toggle count text

        // Add listeners to each toggle
        foreach (Toggle toggle in toggles)
        {
            toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(toggle);
            });
        }
    }

    private void ToggleValueChanged(Toggle toggle)
    {
        // Update the toggle count based on the toggle state
        if (toggle.isOn)
        {
            toggleCount++;
        }
        else
        {
            toggleCount--;
        }

        // Update the display text
    }

    public void OnButtonPress()
    {
        SceneManager.LoadScene(toggleCount);
    }


}