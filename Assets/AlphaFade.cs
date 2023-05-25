using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaFade : MonoBehaviour
{
    public Image image;
    public Color originalColor;
    public float fadeSpeed = 2f;
    public bool fade = false;

    // Start is called before the first frame update
    void Start()
    {
        originalColor = image.color;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (fade)
        {
            image.color = Color.Lerp(originalColor, new Color(image.color.r, image.color.g, image.color.b, 0f), fadeSpeed * Time.deltaTime);
            StartCoroutine("Fade");
        }



    }

    public IEnumerator Fade()
    {
        yield return new WaitForSeconds(1f);
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);

        fade = false;
    }



}
