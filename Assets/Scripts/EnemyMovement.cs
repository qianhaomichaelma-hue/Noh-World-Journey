using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
        }
        
    }

    void Update()
    {
        if (player != null && navMeshAgent != null && navMeshAgent.enabled)
        {
            navMeshAgent.SetDestination(player.position);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<EnemyCollisionSound>()?.PlayScareSound();
            Debug.Log("Player triggered enemy");
        }
    }
}
