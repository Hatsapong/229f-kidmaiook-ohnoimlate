using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Start_game()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }     
    
    public void Exit_game()
    {
        Application.Quit();
    }

    public void Credit_game()
    {
        SceneManager.LoadScene(4);
    }
    
}
