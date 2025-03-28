using UnityEngine;
using UnityEngine.SceneManagement;


namespace LondonPlatform.Core
{
    public class MainMenuManager : MonoBehaviour
    {
        [SerializeField] private GameObject CreditsMenu;
        
        
        public void Play()
        {
            SceneManager.LoadScene("ValouSceneSample");
        }

        public void PlayCinematics()
        {
            SceneManager.LoadScene("CinematicScene");
        }

        public void Credits()
        {
            CreditsMenu.SetActive(true);
        }
        
        
        public void BackToMainMenu()
        {
            CreditsMenu.SetActive(false);
        }
        
        
        public void QuitGame()
        {
            Application.Quit();
        }
        
    }
}
