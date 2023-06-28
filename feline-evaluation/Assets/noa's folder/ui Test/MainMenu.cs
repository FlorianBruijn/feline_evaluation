using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
    public void GoToSCene(int scenenumber)
    {     
        SceneManager.LoadScene(scenenumber);
    }
    public void QuitApp()
    {
        Application.Quit();
        Debug.Log("Application has quit");
    }
}