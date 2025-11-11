using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JumpScarePop : MonoBehaviour
{
    public Image scareImage;          
    public float popScale = 1.5f;     
    public float popDuration = 0.1f;  

    private Vector3 originalScale;

    void Start()
    {
        if (scareImage == null)
        {
            Debug.LogWarning("Scare image not assigned!");
            return;
        }

       
        originalScale = scareImage.rectTransform.localScale;
        scareImage.gameObject.SetActive(false);
    }

   
    public void TriggerPop()
    {
        StartCoroutine(PopEffect());
    }

    IEnumerator PopEffect()
    {
        scareImage.gameObject.SetActive(true);
        scareImage.rectTransform.localScale = Vector3.zero;

        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / popDuration;
            float scale = Mathf.Lerp(0, popScale, t);
            scareImage.rectTransform.localScale = new Vector3(scale, scale, scale);
            yield return null;
        }

       
        scareImage.rectTransform.localScale = Vector3.one;
    }
}