using UnityEngine;
using Unity.Cinemachine;

public class EnemySpawnCinematicTriggerV3 : MonoBehaviour
{
    [Header("触发设置")]
    public string playerTag = "Player";
    public float cinematicDuration = 3f;
    public bool onlyOnce = true;

    [Header("事件镜头（Cinemachine 3.x）")]
    public CinemachineCamera eventCam;

    [Header("敌人生成设置")]
    public GameObject enemyPrefab;  // 只拖 Project 中的 prefab
    public Transform spawnPoint;

    private bool triggered = false;
    private int originalPriority;

    private void Awake()
    {
        if (eventCam != null)
            originalPriority = eventCam.Priority;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (triggered) return;
        if (!other.CompareTag(playerTag)) return;

        triggered = true;
        StartCoroutine(PlayCinematicThenSpawn());
    }

    private System.Collections.IEnumerator PlayCinematicThenSpawn()
    {
        // 切换到过场镜头
        if (eventCam != null)
            eventCam.Priority = 100;

        // 生成敌人
        if (enemyPrefab && spawnPoint)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            enemy.name = "SpawnedEnemy";
            Debug.Log("Enemy spawned at " + spawnPoint.position);

            var agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
            if (agent != null && !agent.enabled)
            {
                agent.enabled = true;
                Debug.Log("✅ NavMeshAgent re-enabled after spawn");
            }
        }

        // 等待几秒（播放过场）
        yield return new WaitForSeconds(cinematicDuration);

        // 切回玩家镜头
        if (eventCam != null)
            eventCam.Priority = originalPriority;

        if (onlyOnce)
            gameObject.SetActive(false);
    }
}
