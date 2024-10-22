using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectSelector : MonoBehaviour
{
    private Camera mainCamera;
    private VariablesTurningGrandma selectedObject;
    public Dropdown propertyDropdown;
    public Dropdown secondPropertyDropdown; // Second dropdown
    public Button applyButton;

    void Start()
    {
        mainCamera = Camera.main;
        propertyDropdown.onValueChanged.AddListener(OnDropdownChange);
        secondPropertyDropdown.onValueChanged.AddListener(OnSecondDropdownChange);
        applyButton.onClick.AddListener(OnApplyButtonClick);
        propertyDropdown.gameObject.SetActive(false); // Hide dropdowns initially
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

    void OnDropdownChange(int index)
    {
        // Logic for the first dropdown (if needed)
    }

    void OnSecondDropdownChange(int index)
    {
        // Logic for the second dropdown (if needed)
    }

    void OnApplyButtonClick()
    {
        if (selectedObject == null) return;

        // Apply changes based on the first dropdown
        switch (propertyDropdown.value)
        {
            case 0: // Toggle Property A
                selectedObject.upDirection = true;
                selectedObject.downDirection = false;
                selectedObject.leftDirection = false;
                selectedObject.rightDirection = false;
                break;
            case 1: // Toggle Property A
                selectedObject.downDirection = true;
                selectedObject.leftDirection = false;
                selectedObject.rightDirection = false;
                selectedObject.upDirection = false;
                break;
            case 2: // Toggle Property A
                selectedObject.leftDirection = true;
                selectedObject.rightDirection = false;
                selectedObject.upDirection = false;
                selectedObject.downDirection = false;
                break;
            case 3: // Toggle Property A
                selectedObject.rightDirection = true;
                selectedObject.upDirection = false;
                selectedObject.downDirection = false;
                selectedObject.leftDirection = false;
                break;
        }

        // Apply changes based on the second dropdown
        switch (secondPropertyDropdown.value)
        {
            case 0: // Toggle Property B
                selectedObject.turnClockwise = true;
                break;
            case 1: // Toggle Property B
                selectedObject.turnClockwise = false;
                break;
        }

    }
}
