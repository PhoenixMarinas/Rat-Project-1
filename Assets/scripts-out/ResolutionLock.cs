using UnityEngine;

public class ResolutionLock : MonoBehaviour
{
    private void Start()
    {
        // Set resolution to 1280x720 and force windowed mode
        Screen.SetResolution(1280, 720, false);
    }
}
