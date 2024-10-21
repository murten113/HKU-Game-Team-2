using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public SceneSwitcher SceneSwitcher;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("mainPlayer"))
        {
            SceneSwitcher.Setup();
        }
    }
}
