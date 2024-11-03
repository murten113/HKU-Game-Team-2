using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void OnPlayButton ()
    {
        SceneManager.LoadScene("firstTest2 1");
    }

    public void OnQuitButton()
    {
        Application.Quit();
    }

    public void OnTutButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

}
