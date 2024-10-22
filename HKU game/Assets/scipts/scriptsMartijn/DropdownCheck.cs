using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DropdownCheck : MonoBehaviour
{
    public VariablesTurningGrandma Grandma;

    [SerializeField] public TMP_Dropdown dropdownPoint;
    [SerializeField] public TMP_Dropdown dropdownDirec;

    public void GetDropdownVal()
    {

        int pickedEntryIndexPoint = dropdownPoint.value;
        int pickedEntryIndexDirec = dropdownDirec.value;

        if (pickedEntryIndexPoint == 0)
        {
            Grandma.upDirection = true;
        }
        if (pickedEntryIndexPoint == 1)
        {
            Grandma.downDirection = true;
        }
        if (pickedEntryIndexPoint == 2)
        {
            Grandma.leftDirection = true;
        }
        if (pickedEntryIndexPoint == 3)
        {
            Grandma.rightDirection = true;
        }
        if (pickedEntryIndexDirec == 0)
        {
            Grandma.leftDirection = true;
        }
        if (pickedEntryIndexDirec == 1)
        {
            Grandma.rightDirection = true;
        }
    }




}
