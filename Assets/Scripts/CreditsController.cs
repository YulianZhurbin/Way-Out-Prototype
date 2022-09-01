using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CreditsController : MonoBehaviour
{
    [SerializeField] GameObject[] lines;
    [SerializeField] float fadeTime = 1.0f;
    [SerializeField] float showTime = 2.0f;

    TMP_Text curLineText;
    private int curLineIndex = 0;

    private void OnEnable()
    {
        curLineIndex = 0;
        StartCoroutine(MakeLineVisible());
    }

    private void OnDisable()
    {
        Debug.Log("OnDisable()");
        lines[curLineIndex].SetActive(false);
    }

    private IEnumerator MakeLineVisible()
    {
        lines[curLineIndex].SetActive(true);
        curLineText = lines[curLineIndex].GetComponent<TMP_Text>();

        curLineText.alpha = 0;

        while(curLineText.alpha < 1)
        {
            yield return new WaitForEndOfFrame();
            curLineText.alpha += Time.deltaTime / fadeTime;
        }

        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        if(curLineIndex > lines.Length - 3)
        {
            yield return new WaitForSeconds(showTime * 2);
        }
        else
        {
            yield return new WaitForSeconds(showTime);
        }

        StartCoroutine(MakeLineInvisible());
    }

    private IEnumerator MakeLineInvisible()
    {
        curLineText.alpha = 1;

        while (curLineText.alpha > 0)
        {
            yield return new WaitForEndOfFrame();
            curLineText.alpha -= Time.deltaTime / fadeTime;
        }

        lines[curLineIndex].SetActive(false);

        curLineIndex++;

        if(curLineIndex >= lines.Length - 1)
        {
            Debug.Log("end");
            StopAllCoroutines();
        }

        StartCoroutine(MakeLineVisible());
    }
}
