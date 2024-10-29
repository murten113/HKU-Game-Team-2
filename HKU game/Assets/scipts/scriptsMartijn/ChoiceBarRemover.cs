using UnityEngine;
using UnityEngine.UI;

public class ChoiceBarRemover : MonoBehaviour
{
    public GameObject uiElement; // Assign your UI element in the inspector

    // This function will be called when the button is clicked
    public void OnButtonClick()
    {
        if (uiElement != null)
        {
            uiElement.SetActive(false); // Turn off the UI element
        }
    }
}
