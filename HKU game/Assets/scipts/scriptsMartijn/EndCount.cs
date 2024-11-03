using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCount : MonoBehaviour
{
    public collectibleCount counter;
    TMPro.TMP_Text text;

    void Awake()
    {
        text = GetComponent<TMPro.TMP_Text>();
    }

    public void WriteEnd()
    {
        text = GetComponent<TMPro.TMP_Text>();
        text.text = $"You've achieved {counter.count} milestone('s) in your life";
    }
}
