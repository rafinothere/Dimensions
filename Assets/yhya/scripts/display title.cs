using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class displaytitle: MonoBehaviour
{
    private float alpha;
    public Image textbox;
    private bool showTitle;
    Color updatecolor;
    private float displayTime;

    void Start()
    {
        showTitle = true;
        updatecolor = textbox.color;
        displayTime = 5f;
    }

    void Update()
    {
        if(showTitle == true)
        {
            alpha += 0.01f;
            StartCoroutine(Fade(alpha));
            if (alpha > 1)
            {
                showTitle = false;
            }
        }
        else if(displayTime > 0)
        {
            displayTime -= Time.deltaTime;
        }
        else if(alpha != 0)
        {
            alpha -= 0.01f;
            StartCoroutine(Fade(alpha));
        }
    }


    private IEnumerator Fade(float alpha)
    {
        updatecolor.a = alpha;
        textbox.color = updatecolor;
        yield return new WaitForSeconds(4f);
    }


}
