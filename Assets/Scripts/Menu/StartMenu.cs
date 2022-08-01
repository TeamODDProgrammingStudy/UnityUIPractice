using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
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
}
