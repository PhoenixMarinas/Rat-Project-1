using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene(1); // Load the scene with build index 1
    }
    public void Level2()
    {
        SceneManager.LoadScene(2); // Load the scene with build index 2
    }

    public void Level3()
    {
        SceneManager.LoadScene(3); // Load the scene with build index 3
    }
    public void Level4()
    {
        SceneManager.LoadScene(4); // Load the scene with build index 4
    }
    public void Level5()
    {
        SceneManager.LoadScene(5); // Load the scene with build index 5
    }

    public void Level6()
    {
        SceneManager.LoadScene(6); // Load the scene with build index 6
    }

    public void Level7()
    {
        SceneManager.LoadScene(7); // Load the scene with build index 7
    }

    public void Level8()
    {
        SceneManager.LoadScene(8); // Load the scene with build index 8
    }

    public void Level9()
    {
        SceneManager.LoadScene(9); // Load the scene with build index 9
    }

    public void Level10()
    {
        SceneManager.LoadScene(10); // Load the scene with build index 10
    }


    public void Intro()
    {
        SceneManager.LoadScene(0); // Start Menu
    }

    public void restartlevel()
    {
        Time.timeScale = 1;  // Reset time scale to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
