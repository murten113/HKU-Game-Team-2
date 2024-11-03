using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class ObjectSelector : MonoBehaviour
{
    private Camera mainCamera;
    private VariablesTurningGrandma selectedObject;
    public Dropdown propertyDropdown;
    public Dropdown secondPropertyDropdown;
    private bool isLocked = false;  // Tracks if dropdowns are permanently disabled

    void Start()
    {
        mainCamera = Camera.main;

        // Set up listeners for dropdown changes
        propertyDropdown.onValueChanged.AddListener(OnPropertyDropdownChange);
        secondPropertyDropdown.onValueChanged.AddListener(OnSecondDropdownChange);

        // Hide dropdowns initially
        propertyDropdown.gameObject.SetActive(false);
        secondPropertyDropdown.gameObject.SetActive(false);
    }

    void Update()
    {
        // Lock dropdowns on spacebar press
        if (Input.GetKeyDown(KeyCode.Space) && !isLocked)
        {
            LockDropdowns();
        }

        // Show dropdowns on right-click if not locked
        if (Input.GetMouseButtonDown(1) && !isLocked)
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
        // Show dropdowns and populate options
        propertyDropdown.gameObject.SetActive(true);
        secondPropertyDropdown.gameObject.SetActive(true);

        propertyDropdown.ClearOptions();
        secondPropertyDropdown.ClearOptions();

        propertyDropdown.AddOptions(new List<string> { "Up", "Down", "Left", "Right" });
        secondPropertyDropdown.AddOptions(new List<string> { "Clockwise", "CounterClockwise" });
    }

    void LockDropdowns()
    {
        // Hide and disable dropdowns permanently
        isLocked = true;
        propertyDropdown.gameObject.SetActive(false);
        secondPropertyDropdown.gameObject.SetActive(false);

        propertyDropdown.interactable = false;
        secondPropertyDropdown.interactable = false;
    }

    void OnPropertyDropdownChange(int index)
    {
        if (isLocked) return;  // Prevent changes if locked
        ApplyChanges();
    }

    void OnSecondDropdownChange(int index)
    {
        if (isLocked) return;  // Prevent changes if locked
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
