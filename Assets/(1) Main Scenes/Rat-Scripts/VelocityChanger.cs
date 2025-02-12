using UnityEngine;

public class VelocityChanger : MonoBehaviour
{
    [Tooltip("The speed to change the player's velocity to when they touch this object.")]
    public float newVelocity = 10f; // You can set this value in the inspector

    // This method detects if the player has touched the object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that collided has the "ThirdPersonController" script
        ThirdPersonController playerController = other.GetComponent<ThirdPersonController>();

        if (playerController != null)
        {
            // Change the player's velocity
            playerController.velocity = newVelocity;
            Debug.Log("Player velocity changed to: " + newVelocity);
        }
    }
}
