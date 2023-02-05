using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{    
    public void ExitGame()
    {
        Application.Quit();
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        PlayerMouse.currentMode = PlayerMouse.BuildMode.TRANSITION;
    }
    public void HowToPLay()
    {
        SceneManager.LoadScene(4);
    }

    public void Credit()
    {
        SceneManager.LoadScene(5);
    }
}
