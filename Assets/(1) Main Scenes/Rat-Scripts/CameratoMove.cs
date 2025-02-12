using UnityEngine;
using Cinemachine;

public class CameratoMove : MonoBehaviour
{
    // Drag the object you want to move (e.g., Cinemachine camera) into this field in the Inspector
    public GameObject objectToMove;

    // Set the new position and rotation for the object
    public Vector3 newPosition;
    public Vector3 newRotation;

    // Drag the Cinemachine Virtual Camera into this field in the Inspector
    public CinemachineVirtualCamera cinemachineCamera;

    // Set the new camera distance
    public float newCameraDistance = 50f;

    // Drag the player GameObject into this field
    public GameObject player;

    // Check if the player has triggered the collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.gameObject == player)
        {
            // Move the object to the new position and rotation
            if (objectToMove != null)
            {
                objectToMove.transform.position = newPosition;
                objectToMove.transform.rotation = Quaternion.Euler(newRotation);
            }

            // Access the Framing Transposer component of the Cinemachine camera
            if (cinemachineCamera != null)
            {
                var framingTransposer = cinemachineCamera.GetCinemachineComponent<CinemachineFramingTransposer>();

                if (framingTransposer != null)
                {
                    // Set the new camera distance
                    framingTransposer.m_CameraDistance = newCameraDistance;
                }
            }
        }
    }
}
