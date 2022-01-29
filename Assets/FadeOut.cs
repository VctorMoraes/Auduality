using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public Image fade;

    public Player player;

    void Awake()
    {
        fade.color = new Color32(0,0,0,255);
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color c = fade.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.01f)
        {
            c.a = alpha;
            fade.color = c;
            yield return new WaitForSeconds(.006f);
        }
        
        player.playable = true;
    }
}
