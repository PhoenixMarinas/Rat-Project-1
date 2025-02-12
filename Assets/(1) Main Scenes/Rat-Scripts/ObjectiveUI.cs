using UnityEngine;

public class ObjectiveUI : MonoBehaviour
{
    public GameObject uiElementToHide;   // Drag and drop the UI element you want to hide
    public GameObject uiElementToShow;   // Drag and drop the UI element you want to show
    public GameObject player;            // Drag and drop the player object

    // Detect when the player enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Hide the current UI element
            uiElementToHide.SetActive(false);

            // Show the new UI element
            uiElementToShow.SetActive(true);
        }
    }
}
