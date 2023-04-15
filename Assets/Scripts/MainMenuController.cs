using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame(int x)
    {
        SceneManager.LoadScene(x);
    }

    public void Options()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
