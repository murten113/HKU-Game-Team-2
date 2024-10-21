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

        

    }




}
