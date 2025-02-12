using UnityEngine;
using System.Collections;

public class physcheck : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (animator != null)
        {
            // Uncheck Animate Physics by setting it to false
            animator.animatePhysics = false;

            // Recheck Animate Physics after a small delay
            StartCoroutine(RecheckAnimatePhysics());
        }
        else
        {
            Debug.LogWarning("No Animator component found on this object.");
        }
    }

    private IEnumerator RecheckAnimatePhysics()
    {
        yield return null;  // Wait for the next frame

        // Recheck Animate Physics by setting it to true
        animator.animatePhysics = true;
    }
}
