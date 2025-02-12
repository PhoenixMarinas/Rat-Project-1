using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TeleportPlayerWithFastFade : MonoBehaviour
{
    public GameObject player; // Drag the player GameObject here
    public GameObject targetLocation; // Drag the target location GameObject
    public CanvasGroup fadeCanvasGroup; // Drag the CanvasGroup here
    public float fadeDuration = 0.5f; // Faster fade-in/out duration
    public float displayDuration = 2.0f; // How long the image stays visible after fade in

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            // Start the fade-in, teleport, and fade-out sequence
            StartCoroutine(FadeAndTeleport());
        }
    }

    private IEnumerator FadeAndTeleport()
    {
        // Fade in
        yield return StartCoroutine(FadeCanvasGroup(1, fadeDuration));

        // Teleport the player to the target location after fade-in
        player.transform.position = targetLocation.transform.position;

        // Wait for the image to stay fully visible for a while
        yield return new WaitForSeconds(displayDuration);

        // Fade out
        yield return StartCoroutine(FadeCanvasGroup(0, fadeDuration));
    }

    private IEnumerator FadeCanvasGroup(float targetAlpha, float duration)
    {
        float startAlpha = fadeCanvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            fadeCanvasGroup.alpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            yield return null;
        }

        fadeCanvasGroup.alpha = targetAlpha;
    }
}
