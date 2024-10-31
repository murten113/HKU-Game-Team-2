using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectSelector : MonoBehaviour
{
    private Camera mainCamera;
    private VariablesTurningGrandma selectedObject;
    public Dropdown propertyDropdown;
    public Dropdown secondPropertyDropdown;

    void Start()
    {
        mainCamera = Camera.main;
        propertyDropdown.onValueChanged.AddListener(OnPropertyDropdownChange);
        secondPropertyDropdown.onValueChanged.AddListener(OnSecondDropdownChange);
        propertyDropdown.gameObject.SetActive(false);
        secondPropertyDropdown.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                VariablesTurningGrandma target = hit.collider.GetComponent<VariablesTurningGrandma>();
                if (target != null)
                {
                    selectedObject = target;
                    ShowDropdowns();
                }
            }
        }
    }

    void ShowDropdowns()
    {
        propertyDropdown.gameObject.SetActive(true);
        secondPropertyDropdown.gameObject.SetActive(true);

        propertyDropdown.ClearOptions();
        secondPropertyDropdown.ClearOptions();

        // Add options to the first dropdown
        propertyDropdown.AddOptions(new List<string> { "Up", "Down", "Left", "Right" });

        // Add options to the second dropdown
        secondPropertyDropdown.AddOptions(new List<string> { "Clockwise", "CounterClockwise" });
    }

    void OnPropertyDropdownChange(int index)
    {
        ApplyChanges();
    }

    void OnSecondDropdownChange(int index)
    {
        ApplyChanges();
    }

    void ApplyChanges()
    {
        if (selectedObject == null) return;

        // Apply changes based on the first dropdown
        switch (propertyDropdown.value)
        {
            case 0: // Up
                selectedObject.upDirection = true;
                selectedObject.downDirection = false;
                selectedObject.leftDirection = false;
                selectedObject.rightDirection = false;
                break;
            case 1: // Down
                selectedObject.downDirection = true;
                selectedObject.upDirection = false;
                selectedObject.leftDirection = false;
                selectedObject.rightDirection = false;
                break;
            case 2: // Left
                selectedObject.leftDirection = true;
                selectedObject.rightDirection = false;
                selectedObject.upDirection = false;
                selectedObject.downDirection = false;
                break;
            case 3: // Right
                selectedObject.rightDirection = true;
                selectedObject.upDirection = false;
                selectedObject.downDirection = false;
                selectedObject.leftDirection = false;
                break;
        }

        // Apply changes based on the second dropdown
        switch (secondPropertyDropdown.value)
        {
            case 0: // Clockwise
                selectedObject.turnClockwise = true;
                break;
            case 1: // CounterClockwise
                selectedObject.turnClockwise = false;
                break;
        }
    }
}
