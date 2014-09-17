using UnityEngine;
using System.Collections;


public enum enFadeType
{
    Fade_Color,
    Fade_Scale,
    Fade_Position,
    Fade_SpriteColor,
    Fade_NGUISprite,
    Fade_NGUITexture,
}

public class EffectFader : MonoBehaviour {
    public delegate void FadeOverDelegate();
    public void Fade(enFadeType fadeType, object targetValue,float step, FadeOverDelegate callback = null)
    {
        switch(fadeType){
            case enFadeType.Fade_Color:
                {
                    StartCoroutine(ToFadeColor((Color)targetValue,step,callback));
                }
                break;
            case enFadeType.Fade_Scale:
                {
                    StartCoroutine(ToFadeScale((Vector3)targetValue,step,callback));
                }
                break;
            case enFadeType.Fade_Position:
                {
                    StartCoroutine(ToFadePosition((Vector3)targetValue,step, callback));
                }
                break;
            case enFadeType.Fade_SpriteColor:
                {
                    StartCoroutine(ToFadeSpriteColor((Color)targetValue,step, callback));
                }
                break;
            case enFadeType.Fade_NGUITexture:
                {
                    StartCoroutine(ToFadeNGUITextureColor((Color)targetValue, step, callback));
                }
                break;
        }
    }

    IEnumerator ToFadeColor(Color targetColor,float step, FadeOverDelegate callback)
    {
        while (renderer.material.color != targetColor)
        {
            renderer.material.color = Color.Lerp(renderer.material.color, targetColor, step);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return 0;
    }

    IEnumerator ToFadeScale(Vector3 targetScale, float step, FadeOverDelegate callback)
    {
        while (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, targetScale, step);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return 0;
    }

    IEnumerator ToFadePosition(Vector3 targetPosition, float step, FadeOverDelegate callback)
    {
        while (transform.localPosition != targetPosition)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, step);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        yield return 0;
    }

    IEnumerator ToFadeSpriteColor(Color targetColor, float step, FadeOverDelegate callback)
    {
        SpriteRenderer render = GetComponent<SpriteRenderer>();
        if (render)
        {
            while (render.material.color != targetColor)
            {
                render.material.color = Color.Lerp(render.material.color, targetColor, step);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            yield return 0;
        }
    }

    IEnumerator ToFadeNGUITextureColor(Color targetColor, float step, FadeOverDelegate callback)
    {
        UITexture texture = GetComponent<UITexture>();
        if (texture)
        {
            //while (texture.color.r != targetColor.r || texture.color.g != targetColor.g || texture.color.b != targetColor.b || texture.color.a != targetColor.a)
            while(Mathf.Abs(texture.alpha - targetColor.a) > 0.01f)
            {
                texture.color = Color.Lerp(texture.color, targetColor, step);
                yield return new WaitForSeconds(Time.deltaTime);
            }
            if (callback != null)
            {
                callback();
            }
            yield return 0;
        }

        

    }
	
}
