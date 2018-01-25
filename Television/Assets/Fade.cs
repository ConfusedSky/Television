using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    Texture2D fadeTexture;
    float fadeSpeed = 0.2f;
    int drawDepth = -1000;

    private float alpha = 1.0f;
    private int fadeDir = -1;

    void OnGUI()
    {

        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(0, 0, 0, alpha);

        GUI.depth = drawDepth;

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
    }
}
