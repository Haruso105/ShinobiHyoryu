using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class fadein : MonoBehaviour
{
    public Image image;
    public float delay = 2f;
    private void Start()
    {
        if (image != null)
        {
            StartCoroutine(Fadein());
        }
    }
    public IEnumerator Fadein()
    {
        float elapsedTime = 0f;
        Color color = image.color;
        color.a = 0f;
        image.color = color;

        while (elapsedTime < delay)
        {
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / delay);
            image.color = color;
            yield return null;
        }
        color.a = 1f;
        image.color = color;
    }
}