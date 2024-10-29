using UnityEngine;
using UnityEngine.UI;

public class ChoiceSystem : MonoBehaviour
{
    public GameObject object1; // Assign in inspector
    public GameObject object2; // Assign in inspector
    public GameObject object3; // Assign in inspector
    public GameObject opa1; // Assign in inspector
    public GameObject opa2; // Assign in inspector
    public GameObject opa3; // Assign in inspector


    public Toggle toggle1; // Assign in inspector
    public Toggle toggle2; // Assign in inspector
    public Toggle toggle3; // Assign in inspector

    private void Start()
    {
        // Initialize toggle listeners
        toggle1.onValueChanged.AddListener(delegate { ToggleObject(object1, toggle1); });
        toggle2.onValueChanged.AddListener(delegate { ToggleObject(object2, toggle2); });
        toggle3.onValueChanged.AddListener(delegate { ToggleObject(object3, toggle3); });
        toggle1.onValueChanged.AddListener(delegate { ToggleObject(opa1, toggle1); });
        toggle2.onValueChanged.AddListener(delegate { ToggleObject(opa2, toggle2); });
        toggle3.onValueChanged.AddListener(delegate { ToggleObject(opa3, toggle3); });


        // Set initial state
        ToggleObject(object1, toggle1);
        ToggleObject(object2, toggle2);
        ToggleObject(object3, toggle3);
        ToggleObject(opa1, toggle1);
        ToggleObject(opa2, toggle2);
        ToggleObject(opa3, toggle3);
    }

    private void ToggleObject(GameObject obj, Toggle toggle)
    {
        if (obj != null)
        {
            obj.SetActive(toggle.isOn);
        }
    }
}