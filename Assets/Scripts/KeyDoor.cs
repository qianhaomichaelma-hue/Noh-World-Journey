using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public string requiredKey = "Red Key";
    public Animator doorAnimator;
    private bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpen) return;
        if (!other.CompareTag("Player")) return;

        if (KeyInventory.HasKey(requiredKey))
        {
            OpenDoor();
        }
        else
        {
            Debug.Log("This door is locked. Key required: " + requiredKey);
        }
    }

    void OpenDoor()
    {
        isOpen = true;
        if (doorAnimator != null)
        {
            doorAnimator.SetTrigger("Open");
        }
        else
        {
            Debug.LogWarning("Animator not assigned to door.");
        }
    }
}