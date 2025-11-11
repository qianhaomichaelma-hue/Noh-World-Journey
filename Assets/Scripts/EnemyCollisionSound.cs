using UnityEngine;

public class EnemyCollisionSound : MonoBehaviour
{
    public AudioClip jumpScareSound;
    [Range(0f, 1f)] public float volume = 1f;
    public bool playAtPlayer = false;


    public void PlayScareSound()
    {
        Debug.Log("PlayScareSound triggered");

        Vector3 playPosition = playAtPlayer && Camera.main != null
            ? Camera.main.transform.position
            : transform.position;

        AudioSource.PlayClipAtPoint(jumpScareSound, playPosition, volume);
    }
}