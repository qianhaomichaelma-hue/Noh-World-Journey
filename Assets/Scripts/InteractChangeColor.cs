using UnityEngine;

public class InteractChangeColor : MonoBehaviour, IInteract
{
    public Material material;     // ✅ 新增字段，用来指定材质
    public Color[] colors;        // 固定颜色组
    private int currentIndex = 0;

    public string Description()
    {
        return "Press F to change color";
    }

    public void OnInteract()
    {
        if (colors.Length == 0) return;
        if (material == null)
        {
            Debug.LogError("❌ Material not assigned on " + gameObject.name);
            return;
        }

        // 切换颜色
        material.color = colors[currentIndex];
        Debug.Log("🎨 Color changed to " + colors[currentIndex]);

        // 下一个颜色索引
        currentIndex = (currentIndex + 1) % colors.Length;
    }

    void Start()
    {
        // 如果没有手动指定材质，自动获取当前Renderer的材质
        if (material == null)
        {
            Renderer r = GetComponent<Renderer>();
            if (r != null) material = r.material;
        }
    }
}