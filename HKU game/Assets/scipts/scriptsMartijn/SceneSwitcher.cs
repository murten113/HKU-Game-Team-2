using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{

    public GameObject gameObj;
    public EndCount EndCount;

    public void Setup()
    {
        EndCount.WriteEnd();
        gameObj.SetActive(true);
    }



    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
