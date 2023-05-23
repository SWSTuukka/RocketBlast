using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphaFade : MonoBehaviour
{
    public Image image;
    public float fadeSpeed = 0.3f;
    public bool fade = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(fade)
        {
            StartCoroutine("Fade");
        }
        

    }

    public IEnumerator Fade()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
        image.color = Color.Lerp(image.color, new Color(image.color.r, image.color.g, image.color.b, 0f), fadeSpeed * Time.deltaTime);
        yield return new WaitForSeconds(0.5f);
        fade = false;
    }



}
