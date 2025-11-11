using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class PickUps : MonoBehaviour
{
    private int count;

    public GameObject portal;

    public TextMeshProUGUI countText;

    public GameObject winTextObject;
    public GameObject loseTextObject;

    public Image messageImage;

    public float popScale = 1.5f;     
    public float popDuration = 0.1f;  

    private Vector3 originalScale;


    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {

            other.gameObject.SetActive(false);

            GetComponent<PickUpSound>()?.PlayPickUpSound();
            Debug.Log("Picked Up!");
        }

        count = count + 1;

        SetCountText();

        if (other.gameObject.CompareTag("Enemy"))
        {

            Destroy(gameObject);

            FindFirstObjectByType<JumpScarePop>().TriggerPop();
            loseTextObject.gameObject.SetActive(true);
            loseTextObject.GetComponent<TextMeshProUGUI>().text = "YOU ARE DEAD!";






        }

    }

    

    void Start()
    {

        count = 0;

        SetCountText();

        winTextObject.SetActive(false);
        loseTextObject.SetActive(false);
        portal.SetActive(false);

        messageImage.gameObject.SetActive(false);

    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString() + "/12";

        if (count >= 12)
        {
            winTextObject.SetActive(true);

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // 逐个销毁
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            portal.SetActive(true);


        }
    }
}
