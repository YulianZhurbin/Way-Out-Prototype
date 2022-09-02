using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalScreenController : MonoBehaviour
{
    [SerializeField] GameObject finalSentence;
    [SerializeField] GameObject title;

    private void OnEnable()
    {
        StartCoroutine(ShowSentence());
    }

    private IEnumerator ShowSentence()
    {
        yield return new WaitForSeconds(1.5f);
        finalSentence.SetActive(true);
        StartCoroutine(ShowTitle());
    }

    private IEnumerator ShowTitle()
    {
        yield return new WaitForSeconds(1.5f);
        title.SetActive(true);
    }
}
