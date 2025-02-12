using UnityEngine;

public class Objective_destroy : MonoBehaviour
{
    public GameObject uiElementToDestroy; // Drag and drop the UI element you want to destroy
    public GameObject uiElementToShow;    // Drag and drop the UI element you want to show
    public GameObject player;             // Drag and drop the player object

    // Detect when the player enters the trigger collider
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Destroy the current UI element
            Destroy(uiElementToDestroy);

            // Show the new UI element
            uiElementToShow.SetActive(true);
        }
    }
}