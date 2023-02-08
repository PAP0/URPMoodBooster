using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InstructionScript : MonoBehaviour
{
    public GameObject Instructions;
    public GameObject Menu;
    public GameObject ContinueButton;
    public CanvasGroup ContinueButtonAlpha;
    public CanvasGroup MenuAlpha;
    public Animator MenuMove;
    public float fadeTime = 0.1f;
    public float waitTime;
    private void Start()
    {
        ContinueButton.SetActive(true);
        Menu.SetActive(false);
    }

    public void Continue()
    {
        MenuMove.SetBool("moveMenu", true);
        StartCoroutine(ContinueFadeOut());
        Menu.SetActive(true);
        StartCoroutine(MenuFadeIn());
    }

    public IEnumerator ContinueFadeOut()
    {
        while (ContinueButtonAlpha.alpha > 0)
        {
            ContinueButtonAlpha.alpha -= (fadeTime * Time.deltaTime);
            yield return new WaitForEndOfFrame();
            Menu.SetActive(true);
            StartCoroutine(MenuFadeIn());
        }
    }

    public IEnumerator MenuFadeIn()
    {
        while (MenuAlpha.alpha < 1)
        {
            yield return new WaitForSeconds(waitTime);
            MenuAlpha.alpha += (fadeTime * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
