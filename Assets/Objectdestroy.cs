using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object is the player
        if (other.gameObject == player)
        {
            // Destroy this object when the player touches it
            Destroy(gameObject);
        }
    }
}
