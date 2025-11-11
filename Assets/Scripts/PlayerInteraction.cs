using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("相机与射线参数")]
    public Camera playerCamera;
    public float detectRange = 5f;        // 射线长度
    public float castRadius = 0.25f;      // SphereCast 半径
    public LayerMask interactableMask;    // ✅ 可交互层（排除玩家）

    [Header("UI 控制器")]
    public InteractionUI interactionUI;   // ✅ 用于控制提示面板（白色 Panel）

    private IInteract curInteractObj;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    void Update()
    {
        InteractBySphereCast();
    }

    private void InteractBySphereCast()
    {
        Vector3 rayOrigin = playerCamera.transform.position + playerCamera.transform.forward * 0.5f;
        Ray ray = new Ray(rayOrigin, playerCamera.transform.forward);
        RaycastHit hit;

        bool hitSomething = Physics.SphereCast(ray, castRadius, out hit, detectRange, interactableMask);
        Debug.DrawRay(ray.origin, ray.direction * detectRange, hitSomething ? Color.green : Color.red);

        if (hitSomething)
        {
            IInteract tempInteractObj = hit.transform.GetComponent<IInteract>();

            if (tempInteractObj != null)
            {
                // ✅ 显示Panel（扫描成功提示）
                if (interactionUI != null)
                    interactionUI.ShowPanel();

                // ✅ 按 F 交互
                if (Input.GetKeyDown(KeyCode.F))
                {
                    tempInteractObj.OnInteract();
                    Debug.Log("✅ Interacted with: " + hit.collider.name);
                }

                curInteractObj = tempInteractObj;
                return;
            }
        }

        // ❌ 未命中任何可交互物体 → 隐藏Panel
        if (curInteractObj != null)
        {
            curInteractObj = null;
            if (interactionUI != null)
                interactionUI.HidePanel();
        }
    }
}
