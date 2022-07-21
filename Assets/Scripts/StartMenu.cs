using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Game");
    }
    public void OnQuitButtonClick()
    {
        Application.Quit();
    }
}
