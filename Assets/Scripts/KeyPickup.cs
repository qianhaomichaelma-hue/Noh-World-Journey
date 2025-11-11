using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public string keyID = "Red Key"; // 钥匙ID，与门对应

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            KeyInventory.AddKey(keyID);
            Destroy(gameObject); // 拾取后销毁钥匙模型
            GetComponent<PickUpSound>()?.PlayPickUpSound();
            Debug.Log("Picked up key: " + keyID);
        }
    }
}

