using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{

    public SceneManager SceneManager;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("mainPlayer"))
        {
            LoadEnd();
        }
    }

    private void LoadEnd()
    {
        SceneManager.LoadScene("KillScreen");
    }
}
