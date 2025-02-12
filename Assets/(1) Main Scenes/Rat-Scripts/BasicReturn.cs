using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicReturn : MonoBehaviour
{
    // Set the name of the scene you want to switch to in the Inspector
    public string sceneName = "MainMenu";  // Replace with your scene name

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
