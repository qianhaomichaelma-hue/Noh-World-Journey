using UnityEngine;

public class LookAtPlayerHorizontal : MonoBehaviour
{

    public Transform player;

    void Update()
    {
        if (player != null)
        {
            
            Vector3 targetPosition = new Vector3(player.position.x, transform.position.y, player.position.z);

            
            transform.LookAt(targetPosition);
        }
    }
}
