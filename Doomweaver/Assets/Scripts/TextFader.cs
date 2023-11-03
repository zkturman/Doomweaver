using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextFader : MonoBehaviour
{
    [SerializeField]
    protected TextMeshProUGUI textToFade;
    [SerializeField]
    private float fadeDurationInSeconds = 0.5f;
    protected Color originalTextColor;

    protected void Awake()
    {
        if (textToFade == null)
        {
            textToFade = GetComponent<TextMeshProUGUI>();
        }
        originalTextColor = textToFade.color;
        textToFade.color = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.b, 0);
    }

    public void SetText(string textToSet)
    {
        textToFade.text = textToSet;
    }

    public void SetTransparency(float transparencyFactor) 
    {
        textToFade.color = Color.Lerp(originalTextColor, new Color(0, 0, 0, 0), transparencyFactor);
    }

    public void FadeIn()
    {
        StartCoroutine(fadeRoutine(true));
    }

    public void FadeOut()
    {
        StartCoroutine(fadeRoutine(false));
    }

    private IEnumerator fadeRoutine(bool willFadeIn)
    {
        int numberOfSteps = 50;
        int i = 0;
        Color transparentColor = new Color(0, 0, 0, 0);
        while (i < numberOfSteps)
        {
            float stepFactor = (float)i / (float)numberOfSteps;
            if (willFadeIn)
            {
                stepFactor = 1 - stepFactor;
            }
            textToFade.color = Color.Lerp(originalTextColor, transparentColor, stepFactor);
            i++;
            yield return new WaitForSeconds(fadeDurationInSeconds / (float)numberOfSteps);
        }
    }
}
