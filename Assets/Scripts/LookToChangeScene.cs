using UnityEngine;
using UnityEngine.SceneManagement;

public class LookToChangeScene : MonoBehaviour
{
    [Header("基础设置")]
    public Camera playerCamera;           // 玩家主摄像机
    public string targetTag = "Target";   // 目标物体的 Tag
    public float lookTime = 3f;           // 需要盯着的时间（秒）
    public string nextSceneName = "NextScene"; // 要切换到的场景名

    private float timer = 0f;
    private bool isLooking = false;

    void Update()
    {
        // 从相机正前方向发射一条射线
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out RaycastHit hit, 100f))
        {
            // 命中目标物体
            if (hit.collider.CompareTag(targetTag))
            {
                isLooking = true;
                timer += Time.deltaTime;

                if (timer >= lookTime)
                {
                    Debug.Log($"已注视 {targetTag} {lookTime} 秒，加载场景 {nextSceneName}");
                    SceneManager.LoadScene(nextSceneName);
                }
            }
            else
            {
                ResetLook();
            }
        }
        else
        {
            ResetLook();
        }
    }

    void ResetLook()
    {
        if (isLooking)
        {
            isLooking = false;
            timer = 0f;
        }
    }
}
