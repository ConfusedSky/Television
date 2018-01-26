using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Texture2D fadeTexture;
    public float fadeSpeed = 0.2f;
    public int drawDepth = -1000;
    public bool fade = true;

    private float alpha = 1.0f;
    private int fadeDir = -1;

    public delegate void Callback();
    private Callback cb = null;

    void OnGUI()
    {
        if (fade)
        {
            alpha += fadeDir * fadeSpeed * Time.deltaTime;
            alpha = Mathf.Clamp01(alpha);
            if (alpha <= 0 || alpha >= 1)
            {
                fade = false;
                if(cb != null) cb();
            }   

        }
        GUI.color = new Color(0, 0, 0, alpha);

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }

    public void FadeOut(Callback cb)
    {
        this.cb = cb;
        fade = true;
        fadeDir = 1;
        alpha = 0;
    }
}
