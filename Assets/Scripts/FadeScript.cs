using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image fadeImage;
    public GameObject fadeUI;
    public void StartFade()
    {
        StartCoroutine(FadeOut());//Starts fade
    }
    public IEnumerator FadeOut()
    {
        // Fade in (alpha 0 to 1)
        for (float i = 0; i <= 1.02f; i += 0.02f)
        {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void EndFade()
    {
        StartCoroutine(FadeIn());//End fade
    }
    public IEnumerator FadeIn()
    {
        // fade alpha of an imedge to zero
        for (float i = 1; i >= -0.02f; i -= 0.02f)
        {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
