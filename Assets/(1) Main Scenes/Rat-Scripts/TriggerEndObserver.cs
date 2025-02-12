using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndObserver : MonoBehaviour
{
    public Transform player;
    public GameEnding gameEnding;  // Reference to the GameEnding script or object

    bool m_IsPlayerInRange;

    void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.transform == player)
        {
            m_IsPlayerInRange = true;
            gameEnding.CaughtPlayer();  // Trigger the game-ending behavior
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Optional: If you want to detect when the player leaves the range
        if (other.transform == player)
        {
            m_IsPlayerInRange = false;
        }
    }
}
