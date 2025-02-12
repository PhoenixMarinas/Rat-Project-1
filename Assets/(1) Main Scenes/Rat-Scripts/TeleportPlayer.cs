using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject player; // Drag the player GameObject here
    public GameObject targetLocation; // Drag the target location GameObject (e.g., the trigger cube)

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the assigned player
        if (other.gameObject == player)
        {
            // Teleport the player to the target location's position
            player.transform.position = targetLocation.transform.position;
        }
    }
}
