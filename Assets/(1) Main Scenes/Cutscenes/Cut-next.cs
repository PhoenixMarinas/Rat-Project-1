using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutNext : MonoBehaviour
{
    public Button cutNextButton;

    void Start()
    {
        // Assign the button's onClick event to load the next scene
        cutNextButton.onClick.AddListener(LoadNextScene);
    }

    // Function to load the next scene in the build order
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
