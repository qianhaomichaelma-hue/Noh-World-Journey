using UnityEngine;

public class PickUpSound : MonoBehaviour
{
    public AudioClip pickUpSound;
    [Range(0f, 1f)] public float volume = 1f;
    public bool playAtPlayer = false;


    public void PlayPickUpSound()
    {
        Debug.Log("PlayPickUpSound triggered");

        Vector3 playPosition = playAtPlayer && Camera.main != null
            ? Camera.main.transform.position
            : transform.position;

        AudioSource.PlayClipAtPoint(pickUpSound, playPosition, volume);
    }
}
