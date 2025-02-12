using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class ClickableObject : MonoBehaviour
{
    // Flag to enable or disable clicking in the Editor
    [HideInInspector]
    public bool isClickable = true;

    private void OnMouseDown()
    {
        // This will respond to clicks only if isClickable is true
        if (isClickable)
        {
            // Your click handling code here
            Debug.Log("Object clicked: " + gameObject.name);
        }
    }

    private void OnDrawGizmos()
    {
        // Visual representation in the editor
        if (!isClickable)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, Vector3.one);
        }
    }

    private void OnValidate()
    {
        // Automatically apply the clickability state to all children when the value changes
        foreach (Transform child in transform)
        {
            ClickableObject childClickable = child.GetComponent<ClickableObject>();
            if (childClickable != null)
            {
                childClickable.isClickable = isClickable;
            }
        }
    }
}
