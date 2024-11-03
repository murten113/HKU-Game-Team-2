using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillMenu : MonoBehaviour
{
    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene(3);
    }

}
