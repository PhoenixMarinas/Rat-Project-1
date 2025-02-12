using UnityEngine;

public class CompleteObjectiveUI : MonoBehaviour
{
    public GameObject player;  // Reference to the player
    public GameObject objectiveUI;  // The UI element for the current objective
    public GameObject completedUI;  // The UI element that shows when the objective is completed

    private bool isObjectiveCompleted = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player && !isObjectiveCompleted)
        {
            CompleteObjective();
        }
    }

    void CompleteObjective()
    {
        isObjectiveCompleted = true;

        // Disable the current objective UI (makes the object inactive)
        objectiveUI.SetActive(false);

        // Activate the completed objective UI
        completedUI.SetActive(true);
    }
}
