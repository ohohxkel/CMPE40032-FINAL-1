using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveTitle : MonoBehaviour
{
    public static int wave;
    

    Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        text.canvasRenderer.SetAlpha(0.0f);

    }

    // Update is called once per frame
    void Update()
    {
        text.text = "W A V E    " + wave + "    C O M P L E T E D ";
    }

    void FadeIn()
    {
        text.CrossFadeAlpha(1.0f, 1.5f, false);
    }

    void FadeOut()
    {
        text.CrossFadeAlpha(0.0f, 1.5f, false);
    }

    IEnumerator FadeInOut()
    {
        FadeIn();
        yield return new WaitForSeconds(3.0f);
        FadeOut();
    }


    
}
