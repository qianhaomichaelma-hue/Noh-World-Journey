using UnityEngine;
using UnityEngine.UI;

public class InteractionUI : MonoBehaviour
{
    [Header("交互提示面板")]
    public GameObject panel;   // ✅ 拖入你的 Panel（UI Image）

    void Start()
    {
        if (panel != null)
            panel.SetActive(false); // 初始隐藏
    }

    public void ShowPanel()
    {
        if (panel != null)
            panel.SetActive(true);
    }

    public void HidePanel()
    {
        if (panel != null)
            panel.SetActive(false);
    }
}
