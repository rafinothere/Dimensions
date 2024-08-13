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
        //when scene first loaded this makes sure title displayed
        showTitle = true;
        //used to change alpha of title
        updatecolor = textbox.color;
        //how long title displayed for
        displayTime = 5f;
    }

    void Update()
    {
        if(showTitle == true)
        { 
            //fades in the title
            alpha += 0.01f;
            StartCoroutine(Fade(alpha));
            if (alpha > 1)
            {
                showTitle = false;
            }
        }
        else if(displayTime > 0)
        {
            //redues amiy
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
        //updates alpha of title and waits for 4 frames
        updatecolor.a = alpha;
        textbox.color = updatecolor;
        yield return new WaitForSeconds(4f);
    }


}
