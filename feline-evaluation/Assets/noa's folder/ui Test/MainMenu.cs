using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public void GoToSCene()
    {     
        SceneManager.LoadScene(2);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}