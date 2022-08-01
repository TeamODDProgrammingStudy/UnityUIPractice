using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class GameMenu : MonoBehaviour
    {
        public void Open()
        {
            gameObject.SetActive(true);
        }
        public void Close()
        {
            gameObject.SetActive(false);
        }

        public void ReturnToStartMenu()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
